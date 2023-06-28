using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorisnickiInterfejs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool semafor = false;
            try
            {
                while (!semafor)
                {
                    FrmLogin frmLogin = new FrmLogin();
                    if (frmLogin.ShowDialog() == DialogResult.OK)
                    {
                        frmLogin.Dispose();
                        Application.Run(new FrmPoruke());
                    }
                    else
                    {
                        semafor = true;
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
