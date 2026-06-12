using System;
using System.Windows.Forms;

namespace Pruebas
{
    static class Program
    {
        [STAThread]
        static async System.Threading.Tasks.Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Inicializa Supabase globalmente al arrancar
                await ConexionDB.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al conectar con la base de datos: " + ex.Message);
            }

            Application.Run(new Form1());
        }
    }
}

