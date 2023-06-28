using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;

namespace Server
{
    public class ClientHandler
    {
        Socket socket;
        List<ClientHandler> clients;
        CommunicationHelper helper;
        public CommunicationHelper Helper { get => helper; }
        public string User { get; set; }
        public event EventHandler OdjavljenKlijent;
        public ClientHandler(Socket socket, List<ClientHandler> clients)
        {
            this.socket = socket;
            this.clients = clients;
            helper = new CommunicationHelper(socket);
        }

        internal void Stop()
        {
            if(socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Dispose();
                socket = null;
            }
            OdjavljenKlijent?.Invoke(this, EventArgs.Empty);
        }

        internal void HandleRequests()
        {
            Request request;
            try
            {
                while ((request = helper.Receive<Request>()).Operations != Operations.EndCommunication)
                {
                    Response response;
                    try
                    {
                        response = CreateResponse(request);
                    }
                    catch (Exception ex)
                    {
                        response = new Response
                        {
                            IsSuccessful = false,
                            MessageText = ex.Message
                        };
                    }
                    helper.Send(response);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Stop();
            }
        }

        private Response CreateResponse(Request request)
        {
            Response response = new Response();
            switch (request.Operations)
            {
                case Operations.Login:
                    response = Login((User)request.RequestObject);
                    break;
                case Operations.Poruka:
                    response = VratiPoruku((Poruka)request.RequestObject);
                    break;
            }
            return response;
        }

        private Response VratiPoruku(Poruka poruka)
        {
            return new Response
            {
                IsSuccessful = true,
                ResponseObject = new Poruka {
                    TekstPoruke = poruka.TekstPoruke.ToUpper()
                }
            };
        }

        private Response Login(User user)
        {
            bool postoji = false;
            foreach (ClientHandler client in clients)
            {
                if(client.User == user.Username)
                {
                    postoji = true;
                }
            }
            Response response;
            if (!postoji)
            {
                User = user.Username;
                response = new Response
                {
                    IsSuccessful = true,
                    ResponseObject = user
                };
            }
            else
            {
                response = new Response
                {
                    IsSuccessful = false,
                    MessageText = "User vec postoji"
                };
            }
            return response;
        }
    }
}
