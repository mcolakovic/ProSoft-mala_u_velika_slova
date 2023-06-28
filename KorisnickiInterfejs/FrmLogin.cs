using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Common;

namespace KorisnickiInterfejs
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };
            Request request = new Request
            {
                Operations = Operations.Login,
                RequestObject = user
            };
            try
            {
                Communication.Instance.Connect();
                user =  Communication.Instance.SendRequest<User>(request);
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
