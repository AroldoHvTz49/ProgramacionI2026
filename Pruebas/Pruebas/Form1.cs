using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Supabase; // Extension de Supabase para C#

namespace Pruebas
{
    public partial class Form1 : Form
    {
        // Tus credenciales reales de Supabase
        private string url = "https://hfxdxkvngvljnsljhymy.supabase.co"; // Supabase URL
        private string key = "sb_publishable_PVkoX7XBOcwTM6_0CpH21A_96R5c0bQ"; // Supabase Key
        private Supabase.Client supabase; // Cliente de Supabase para manejar la conexión y operaciones

        public Form1()
        {
            InitializeComponent();

            // 1. Configurar las columnas de tu DataGridView
            Tabla_Clientes.ColumnCount = 4; // Definimos cuántas columnas tendrá la tabla
            Tabla_Clientes.Columns[0].Name = "ID";
            Tabla_Clientes.Columns[1].Name = "Nombre";
            Tabla_Clientes.Columns[2].Name = "Edad";
            Tabla_Clientes.Columns[3].Name = "Teléfono";

            Tabla_Clientes.AllowUserToAddRows = false; // Evitamos filas manuales, se llenan desde la BD

            // 2. INSTANCIAR EL CLIENTE AQUÍ
            var options = new SupabaseOptions { AutoConnectRealtime = true };
            supabase = new Supabase.Client(url, key, options);
        }

        // 3. ESTE ES EL MÉTODO QUE TU DISEÑADOR REALMENTE DISPARA AL ARRANCAR
        private async void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Inicializar formalmente la conexión asíncrona
                await supabase.InitializeAsync();

                // Cargar los registros existentes apenas abre el programa
                await CargarDatosDesdeSupabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con Supabase: " + ex.Message);
            }
        }

        // 4. Modificamos tu botón con 'async' para operaciones en la nube
        private async void btn_Click_Prueba_Click(object sender, EventArgs e)
        {
            string nombre = Nombre.Text.Trim(); // Tomamos el valor del textbox y lo limpiamos de espacios
            int.TryParse(Edad.Text.Trim(), out int edad); // Intentamos convertir el texto a número, si falla edad será 0
            string telefono = Telefono.Text.Trim(); // Tomamos el valor del textbox y lo limpiamos de espacios

            // Validaciones
            if (!string.IsNullOrWhiteSpace(nombre) && edad > 0 && !string.IsNullOrWhiteSpace(telefono))
            {
                try
                {
                    // Creamos el objeto con la estructura de la base de datos
                    var nuevoCliente = new Cliente
                    {
                        NombreCl = nombre, // Toma el valor del textbox y lo envía a la clase cliente
                        EdadCl = edad,
                        TelefonoCl = telefono
                    };

                    // ENVIAR A SUPABASE
                    await supabase.From<Cliente>().Insert(nuevoCliente);

                    MessageBox.Show("Guardado en la base de datos");

                    // Limpiar campos
                    Nombre.Clear();
                    Edad.Clear();
                    Telefono.Clear();

                    // Dejar el cursor en el primer campo para una nueva entrada
                    Nombre.Focus();

                    // Recargar la tabla para mostrar los datos frescos de la BD (incluyendo el ID real)
                    await CargarDatosDesdeSupabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("No se ha ingresado ningún nombre.");
                    Nombre.Focus();
                }
                else if (edad <= 0)
                {
                    MessageBox.Show("La edad debe ser un número positivo.");
                    Edad.Focus();
                }
                else if (string.IsNullOrWhiteSpace(telefono))
                {
                    MessageBox.Show("No se ha ingresado ningún número de teléfono.");
                    Telefono.Focus();
                }
            }
        }

        // 5. Función auxiliar para leer los datos reales de la nube
        private async System.Threading.Tasks.Task CargarDatosDesdeSupabase()
        {
            // Limpiamos las filas viejas de la interfaz
            Tabla_Clientes.Rows.Clear();

            // Traemos todos los registros ordenados por ID
            var resultado = await supabase.From<Cliente>().Order("id_cl", Postgrest.Constants.Ordering.Ascending).Get();
            List<Cliente> listaClientes = resultado.Models; // Aquí tenemos la lista real de clientes desde Supabase

            // Llenamos el DataGridView fila por fila con la info real
            foreach (var cliente in listaClientes)
            {
                Tabla_Clientes.Rows.Add(cliente.IdCl, cliente.NombreCl, cliente.EdadCl, cliente.TelefonoCl);
            }
        }
    }
}

