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
    public partial class FrmPoruke : Form
    {
        public FrmPoruke()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                TekstPoruke = txtPoruka.Text
            };
            Request request = new Request
            {
                Operations = Operations.Poruka,
                RequestObject = poruka
            };
            try
            {
                poruka = Communication.Instance.SendRequest<Poruka>(request);
                rbPoruke.AppendText(poruka.TekstPoruke + '\n');
                txtPoruka.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
