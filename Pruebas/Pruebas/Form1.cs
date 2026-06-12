using System;
using System.Collections.Generic;
using System.Linq; // IMPORTANTE: Agrega esta línea arriba para activar las búsquedas
using System.Windows.Forms;


namespace Pruebas
{
    public partial class Form1 : Form
    {
        // 1. VARIABLE GLOBAL: Almacena los datos temporalmente para el buscador en tiempo real
        private List<Cliente> listaClientesGlobal = new List<Cliente>();

        // 2. VARIABLE GLOBAL: Recuerda qué fila seleccionó el usuario al pulsar "..."
        private int filaSeleccionadaIndex = -1;

        public Form1()
        {
            InitializeComponent();

            Tabla_Clientes.ColumnCount = 4;
            Tabla_Clientes.Columns[0].Name = "ID";
            Tabla_Clientes.Columns[1].Name = "Nombre";
            Tabla_Clientes.Columns[2].Name = "Edad";
            Tabla_Clientes.Columns[3].Name = "Teléfono";

            // 3. COLUMNA DE BOTÓN: Creamos el botón "..." para cada registro
            DataGridViewButtonColumn columnaBoton = new DataGridViewButtonColumn();
            columnaBoton.Name = "Opciones";
            columnaBoton.HeaderText = "Acciones";
            columnaBoton.Text = "Opciones";
            columnaBoton.UseColumnTextForButtonValue = true; // Hace que todos los botones muestren "..."
            columnaBoton.Width = 60;
            Tabla_Clientes.Columns.Add(columnaBoton);

            Tabla_Clientes.AllowUserToAddRows = false;
            Tabla_Clientes.ReadOnly = true;

            // Hacemos que seleccione la fila completa al hacer clic en el botón
            Tabla_Clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ajustamos el tamaño de las columnas para que se vean bien
            Tabla_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Detecta cuando el usuario hace clic en el botón "..."
            Tabla_Clientes.CellContentClick += Tabla_Clientes_CellContentClick;
        }

        private async void Form1_Load_1(object sender, EventArgs e) // Carga los datos desde Supabase al abrir la pantalla
        {
            try
            {
                await CargarDatosDesdeSupabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private async void btn_Click_Prueba_Click(object sender, EventArgs e)// Evento del botón para guardar o actualizar el cliente
        {
            string nombre = Nombre.Text.Trim();
            int.TryParse(Edad.Text.Trim(), out int edad);
            string telefono = Telefono.Text.Trim();

            if (!string.IsNullOrWhiteSpace(nombre) && edad > 0 && !string.IsNullOrWhiteSpace(telefono))
            {
                try
                {
                    var nuevoCliente = new Cliente
                    {
                        NombreCl = nombre,
                        EdadCl = edad,
                        TelefonoCl = telefono
                    };

                    // EVALUAMOS SI EL BOTÓN TIENE UN ID GUARDADO (MODO EDICIÓN)
                    if (btn_Click_Prueba.Tag != null) // Si el "Tag" del botón no es nulo, significa que estamos editando un cliente existente
                    {
                        nuevoCliente.IdCl = Convert.ToInt32(btn_Click_Prueba.Tag); // Asignamos el ID al objeto para que sepa cuál registro actualizar

                        // Enviamos actualización a Supabase
                        await ConexionDB.Supabase.From<Cliente>().Update(nuevoCliente);
                        MessageBox.Show("Cliente modificado con éxito");

                        btn_Click_Prueba.Tag = null; // Quitamos el modo edición
                    }
                    else// Si el "Tag" es nulo, significa que es un nuevo cliente y debemos insertarlo
                    {
                        await ConexionDB.Supabase.From<Cliente>().Insert(nuevoCliente);
                        MessageBox.Show("Guardado en la base de datos");
                    }

                    Nombre.Clear();
                    Edad.Clear();
                    Telefono.Clear();
                    Nombre.Focus();

                    await CargarDatosDesdeSupabase();// Refresca los datos desde la nube automáticamente para mostrar el nuevo registro o los cambios realizados
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos: " + ex.Message);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(nombre)) { MessageBox.Show("No se ha ingresado ningún nombre."); Nombre.Focus(); }
                else if (edad <= 0) { MessageBox.Show("La edad debe ser un número positivo."); Edad.Focus(); }
                else if (string.IsNullOrWhiteSpace(telefono)) { MessageBox.Show("No se ha ingresado ningún número de teléfono."); Telefono.Focus(); }
            }
        }

        private async System.Threading.Tasks.Task CargarDatosDesdeSupabase() // Lee los registros de clientes desde la nube y los muestra en la tabla, además de guardarlos en la lista global para el buscador
        {
            // USAMOS LA CONEXIÓN GLOBAL
            var resultado = await ConexionDB.Supabase.From<Cliente>().Order("id_cl", Postgrest.Constants.Ordering.Ascending).Get();

            // Guardamos el resultado en la lista global en memoria
            listaClientesGlobal = resultado.Models;

            // Mandamos los datos a dibujar en la pantalla
            MostrarClientesEnTabla(listaClientesGlobal);
        }

        // FUNCIÓN AUXILIAR: Dibuja las filas dinámicamente según la lista que reciba
        private void MostrarClientesEnTabla(List<Cliente> lista)
        {
            Tabla_Clientes.Rows.Clear();
            foreach (var cliente in lista)
            {
                Tabla_Clientes.Rows.Add(cliente.IdCl, cliente.NombreCl, cliente.EdadCl, cliente.TelefonoCl);
            }
        }

        private void btn_IrProductos_Click(object sender, EventArgs e)
        {
            FormProductos pantallaProductos = new FormProductos(); // Crea una instancia de la pantalla de productos
            pantallaProductos.Show(); // Muestra la pantalla de productos
            this.Hide(); // Oculta l{
                         // a pantalla actual (Form1)
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Asegura que toda la aplicación se cierre cuando se cierra esta ventana
        }

        // DETECTOR DE CLIC EN EL BOTÓN "Opciones"
        private void Tabla_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Valida que el clic sea en una fila real y pertenezca a la columna "Opciones"
            if (e.RowIndex >= 0 && Tabla_Clientes.Columns[e.ColumnIndex].Name == "Opciones")
            {
                filaSeleccionadaIndex = e.RowIndex; // Guarda el índice de la fila seleccionada para usarlo en las opciones del menú

                // Abre el menú flotante exactamente donde tienes el cursor del mouse
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e) //Buscador en tiempo real que filtra
        {
            string busqueda = txt_Buscar.Text.Trim().ToLower(); // Convertimos a minúscula

            // Si limpias la barra, vuelve a mostrar todos los registros originales
            if (string.IsNullOrEmpty(busqueda))
            {
                MostrarClientesEnTabla(listaClientesGlobal);
                return;
            }

            // Filtra localmente sin tocar el internet (Busca coincidencia en ID, Nombre o Teléfono)
            var filtrados = listaClientesGlobal.Where(c =>
                c.IdCl.ToString().Contains(busqueda) ||
                (c.NombreCl != null && c.NombreCl.ToLower().Contains(busqueda)) ||
                (c.TelefonoCl != null && c.TelefonoCl.Contains(busqueda))
            ).ToList();

            // Actualiza la cuadrícula con el filtro
            MostrarClientesEnTabla(filtrados);
        }

        //btn visualizar toda info del cliente seleccionado en un MessageBox
        private void visualizarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionadaIndex >= 0)
            {
                var fila = Tabla_Clientes.Rows[filaSeleccionadaIndex]; // Obtiene la fila seleccionada usando el índice guardado

                MessageBox.Show($"DATOS COMPLETOS DEL CLIENTE\n\n" +
                                $"ID único: {fila.Cells["ID"].Value}\n" +
                                $"Nombre: {fila.Cells["Nombre"].Value}\n" +
                                $"Edad: {fila.Cells["Edad"].Value} años\n" +
                                $"Teléfono: {fila.Cells["Teléfono"].Value}",
                                "Consulta del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //btn para editar el cliente seleccionado
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionadaIndex >= 0)
            {
                var fila = Tabla_Clientes.Rows[filaSeleccionadaIndex]; // Obtiene la fila seleccionada usando el índice guardado

                // Regresa los datos de la fila a los TextBox de registro
                Nombre.Text = fila.Cells["Nombre"].Value.ToString();
                Edad.Text = fila.Cells["Edad"].Value.ToString();
                Telefono.Text = fila.Cells["Teléfono"].Value.ToString();

                // Guardamos el ID del cliente en el "Tag" del botón para que sepa que debe ACTUALIZAR al presionar
                btn_Click_Prueba.Tag = fila.Cells["ID"].Value;

                MessageBox.Show("Modifique los campos de texto y presione el botón Guardar para actualizar.");
                Nombre.Focus();
            }
        }

        //btn para eliminar el cliente seleccionado
        private async void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionadaIndex >= 0)
            {
                var fila = Tabla_Clientes.Rows[filaSeleccionadaIndex]; // Obtiene la fila seleccionada usando el índice guardado
                int idCliente = Convert.ToInt32(fila.Cells["ID"].Value); // Obtiene el ID del cliente para eliminarlo de la base de datos
                string nombreCliente = fila.Cells["Nombre"].Value.ToString(); // Solo para mostrar el nombre en la confirmación de eliminación

                DialogResult seguro = MessageBox.Show($"¿Deseas eliminar permanentemente a: {nombreCliente}?",
                "Confirmación requerida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (seguro == DialogResult.Yes)
                {
                    try
                    {
                        // Eliminación física en la nube de Supabase
                        await ConexionDB.Supabase.From<Cliente>().Where(c => c.IdCl == idCliente).Delete();
                        MessageBox.Show("Registro borrado con éxito.");
                        // Refresca los datos desde la nube automáticamente
                        await CargarDatosDesdeSupabase();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al intentar eliminar: " + ex.Message);
                    }
                }
            }
        }

        private void btn_IrVentas_Click(object sender, EventArgs e)
        {
            FormVentas pantallaProductos = new FormVentas(); // Crea una instancia de la pantalla de productos
            pantallaProductos.Show(); // Muestra la pantalla de productos
            this.Hide(); // Oculta la pantalla actual
        }
    }
}