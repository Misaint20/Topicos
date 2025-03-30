using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoBaseDatos1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar el formulario de conexión
            ConexionForm conexionForm = new ConexionForm();
            if (conexionForm.ShowDialog() == DialogResult.OK)
            {
                // Una vez establecida la conexión, se abre el formulario principal
                Application.Run(new DBManager());
            }
            else
            {
                // Si la conexión falla o se cancela, se cierra la aplicación
                Application.Exit();
            }
        }
    }
}
