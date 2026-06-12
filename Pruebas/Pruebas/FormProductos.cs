using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pruebas
{
    public partial class FormProductos : Form
    {
        private List<Producto> listaProductosGlobal = new List<Producto>();

        private int filaSeleccionadas = -1;
        public FormProductos()
        {
            InitializeComponent();

            // Configurar columnas del DataGridView de productos
            Tabla_Productos.ColumnCount = 4;
            Tabla_Productos.Columns[0].Name = "ID";
            Tabla_Productos.Columns[1].Name = "Nombre";
            Tabla_Productos.Columns[2].Name = "Precio";
            Tabla_Productos.Columns[3].Name = "Stock";

            DataGridViewButtonColumn columnaBoton = new DataGridViewButtonColumn();
            columnaBoton.Name = "Opciones";
            columnaBoton.HeaderText = "Acciones";
            columnaBoton.Text = "Opciones";
            columnaBoton.UseColumnTextForButtonValue = true;
            columnaBoton.Width = 60;
            Tabla_Productos.Columns.Add(columnaBoton);

            Tabla_Productos.AllowUserToAddRows = false;

            Tabla_Productos.ReadOnly = true;

            Tabla_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Tabla_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Tabla_Productos.CellContentClick += Tabla_Productos_CellContentClick;
        }

        // Evento que se dispara al abrir la pantalla de productos
        private async void FormProductos_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarProductosDesdeSupabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }



        // Evento del botón para guardar el producto
        private async void btn_GuardarProducto_Click(object sender, EventArgs e)
        {
            string nombre = NombreProd.Text.Trim();
            double.TryParse(PrecioProd.Text.Trim(), out double precio);
            int.TryParse(StockProd.Text.Trim(), out int stock);

            // Validaciones básicas de entrada
            if (!string.IsNullOrWhiteSpace(nombre) && precio > 0 && stock >= 0)
            {
                try
                {
                    var nuevoProducto = new Producto
                    {
                        NombreProd = nombre,
                        PrecioProd = precio,
                        StockProd = stock
                    };

                    if(btn_GuardarProducto.Tag != null)
                    {
                        nuevoProducto.IdProd = Convert.ToInt32(btn_GuardarProducto.Tag);

                        await ConexionDB.Supabase.From<Producto>().Update(nuevoProducto);
                        MessageBox.Show("Producto actualizado exitosamente");

                        btn_GuardarProducto.Tag = null;
                    }
                    else
                    {
                        // Guardar en la base de datos usando la conexión global centralizada
                        await ConexionDB.Supabase.From<Producto>().Insert(nuevoProducto);
                        MessageBox.Show("Producto guardado exitosamente");
                    }

                    // Limpiar los controles
                    NombreProd.Clear();
                    PrecioProd.Clear();
                    StockProd.Clear();
                    NombreProd.Focus();

                    // Actualizar la tabla con los datos del servidor
                    await CargarProductosDesdeSupabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar en Supabase: " + ex.Message);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingrese un nombre válido.");
                    NombreProd.Focus();
                }
                else if (precio <= 0)
                {
                    MessageBox.Show("El precio debe ser un número mayor a 0.");
                    PrecioProd.Focus();
                }
                else if (stock < 0)
                {
                    MessageBox.Show("El stock no puede ser un número negativo.");
                    StockProd.Focus();
                }
            }
        }

        // Función para leer los registros de productos desde la nube
        private async System.Threading.Tasks.Task CargarProductosDesdeSupabase()
        { 
            var resultado = await ConexionDB.Supabase.From<Producto>().Order("id_prod", Postgrest.Constants.Ordering.Ascending).Get();
            listaProductosGlobal = resultado.Models;
            MostrarProductosEnTabla(listaProductosGlobal);
        }

        private void MostrarProductosEnTabla(List<Producto> lista)
        {
            Tabla_Productos.Rows.Clear();
            foreach (var producto in lista)
            {
                Tabla_Productos.Rows.Add(producto.IdProd, producto.NombreProd, producto.PrecioProd, producto.StockProd);
            }
        }

        private void FormProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_IrClientes_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el formulario de productos
            Form1 pantallaClientes = new Form1();

            // 2. Lo mostramos en pantalla
            pantallaClientes.Show();

            // Opcional: Si quieres ocultar el formulario de clientes al abrir productos, 
            // puedes descomentar la siguiente línea:
            this.Hide();
        }

        private void Tabla_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && Tabla_Productos.Columns[e.ColumnIndex].Name == "Opciones")
            {
                filaSeleccionadas = e.RowIndex;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void visualizarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionadas >= 0)
            {
                var fila = Tabla_Productos.Rows[filaSeleccionadas];

                MessageBox.Show($"ID: {fila.Cells["ID"].Value}\n" +
                    $"Nombre: {fila.Cells["Nombre"].Value}\n" +
                    $"Precio: {fila.Cells["Precio"].Value}\n" +
                    $"Stock: {fila.Cells["Stock"].Value}", 
                    "Detalles del Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionadas >= 0)
            {
                var fila = Tabla_Productos.Rows[filaSeleccionadas];
                NombreProd.Text = fila.Cells["Nombre"].Value.ToString();
                PrecioProd.Text = fila.Cells["Precio"].Value.ToString();
                StockProd.Text = fila.Cells["Stock"].Value.ToString();
                btn_GuardarProducto.Tag = fila.Cells["ID"].Value; // Guardamos el ID en el Tag para saber que es una edición
            
                MessageBox.Show("Edita los campos y presiona Guardar para actualizar el producto.", "Editar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NombreProd.Focus();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionadas >= 0)
            {
                var fila = Tabla_Productos.Rows[filaSeleccionadas];
                int idProducto = Convert.ToInt32(fila.Cells["ID"].Value);
                string nombreProducto = fila.Cells["Nombre"].Value.ToString();

                DialogResult seguro = MessageBox.Show($"¿Estás seguro de que deseas eliminar el producto '{nombreProducto}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (seguro == DialogResult.Yes)
                {
                    try
                    {
                        ConexionDB.Supabase.From<Producto>().Where(c => c.IdProd == idProducto).Delete();
                        MessageBox.Show("Producto eliminado exitosamente.");
                        CargarProductosDesdeSupabase(); // Refrescar la tabla después de eliminar
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                    }
                }
            }
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txt_Buscar.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(busqueda))
            {
                MostrarProductosEnTabla(listaProductosGlobal);
                return;
            }

            var filtro = listaProductosGlobal.Where(c =>
            c.IdProd.ToString().Contains(busqueda) ||
            (c.NombreProd != null && c.NombreProd.ToLower().Contains(busqueda))
            ).ToList();

            MostrarProductosEnTabla(filtro);
        }
    }
}
