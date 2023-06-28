﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket serverSocket;
        List<ClientHandler> clients = new List<ClientHandler>();
        bool isRunning = false;
        public List<ClientHandler> Clients { get => clients; }

        public void Start()
        {
            if (!isRunning)
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
                serverSocket.Listen(5);
                isRunning = true;
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                serverSocket.Dispose();
                serverSocket = null;
                foreach (ClientHandler client in clients)
                {
                    client.Stop();
                }
                isRunning = false;
            }
        }

        public void HandleClients()
        {
            try
            {
                while (true)
                {
                    Socket clientSocket = serverSocket.Accept();
                    ClientHandler handler = new ClientHandler(clientSocket, clients);
                    clients.Add(handler);
                    handler.OdjavljenKlijent += Handler_OdjavljenKlijent;
                    Thread klijentskaNit = new Thread(handler.HandleRequests);
                    klijentskaNit.IsBackground = true;
                    klijentskaNit.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Handler_OdjavljenKlijent(object sender, EventArgs e)
        {
            clients.Remove((ClientHandler)sender);
        }
    }
}
