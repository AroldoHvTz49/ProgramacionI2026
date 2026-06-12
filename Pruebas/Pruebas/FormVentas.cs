using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pruebas
{
    public partial class FormVentas : Form
    {
        private List<Producto> listaProductosGlobal = new List<Producto>();
        private List<Cliente> listaClientesGlobal = new List<Cliente>();
        private List<Venta> listaVentasGlobal = new List<Venta>();

        private Producto productoSeleccionado = null;
        private Cliente clienteSeleccionado = null;

        private int filaSeleccionada = -1; //Para seleccionar la fila en la tabla de ventas y mostrar el menú 

        public FormVentas()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
            ConfigurarTablaVentas(); // Configura la tabla
        }

        private void ConfigurarTablaVentas()
        {
            Tabla_Ventas.ColumnCount = 5;
            Tabla_Ventas.Columns[0].Name = "ID Venta";
            Tabla_Ventas.Columns[1].Name = "Producto";
            Tabla_Ventas.Columns[2].Name = "Cliente";
            Tabla_Ventas.Columns[3].Name = "Cantidad";
            Tabla_Ventas.Columns[4].Name = "Total";

            // Agregar columna de botón "Acciones" igual que en productos
            DataGridViewButtonColumn columnaBoton = new DataGridViewButtonColumn();
            columnaBoton.Name = "Opciones";
            columnaBoton.HeaderText = "Acciones";
            columnaBoton.Text = "Opciones";
            columnaBoton.UseColumnTextForButtonValue = true;
            columnaBoton.Width = 80;
            Tabla_Ventas.Columns.Add(columnaBoton);

            Tabla_Ventas.AllowUserToAddRows = false;
            Tabla_Ventas.ReadOnly = true;
            Tabla_Ventas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Tabla_Ventas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Vincular el evento del click de la celda de opciones
            Tabla_Ventas.CellContentClick += Tabla_Ventas_CellContentClick;
        }

        private async void FormVentas_Load(object sender, EventArgs e)
        {
            try
            {
                await RecargarDatosDesdeSupabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de inicialización de datos: " + ex.Message);
            }
        }

        // ========================================================
        // 🔍 FILTRADO EN TIEMPO REAL (Buscadores de cajas de texto)
        // ========================================================

        private void txt_BuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string criterio = txt_BuscarProducto.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(criterio))
            {
                productoSeleccionado = null;
                lbl_ProductoSeleccionado.Text = "Producto: Ninguno";
                CalcularTotal();
                return;
            }

            var match = listaProductosGlobal.FirstOrDefault(p => p.NombreProd.ToLower().Contains(criterio));
            if (match != null)
            {
                productoSeleccionado = match;
                lbl_ProductoSeleccionado.Text = $"Seleccionado: {productoSeleccionado.NombreProd} | Stock: {productoSeleccionado.StockProd} | Precio: {productoSeleccionado.PrecioProd}";
            }
            else
            {
                productoSeleccionado = null;
                lbl_ProductoSeleccionado.Text = "Producto no encontrado";
            }
            CalcularTotal();
        }

        private void txt_BuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string criterio = txt_BuscarCliente.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(criterio))
            {
                clienteSeleccionado = null;
                lbl_ClienteSeleccionado.Text = "Cliente: Ninguno";
                return;
            }

            var match = listaClientesGlobal.FirstOrDefault(c => c.NombreCl.ToLower().Contains(criterio));
            if (match != null)
            {
                clienteSeleccionado = match;
                lbl_ClienteSeleccionado.Text = $"Cliente: {clienteSeleccionado.NombreCl}";
            }
            else
            {
                clienteSeleccionado = null;
                lbl_ClienteSeleccionado.Text = "Cliente no encontrado";
            }
        }

        private void txt_Cantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            if (productoSeleccionado != null && int.TryParse(txt_Cantidad.Text.Trim(), out int cantidad))
            {
                double total = productoSeleccionado.PrecioProd * cantidad;
                txt_TotalVenta.Text = total.ToString("F2");
            }
            else
            {
                txt_TotalVenta.Text = "0.00";
            }
        }

        // ========================================================
        // 🔍 FILTRAR LA TABLA DE HISTORIAL EN TIEMPO REAL
        // ========================================================
        private void txt_BuscarHistorial_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txt_BuscarHistorial.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(busqueda))
            {
                // Corregido: l minúscula
                MostrarVentasEnTabla(listaVentasGlobal);
                return;
            }

            // Corregido: Se agregó el filtro con 'var' para que C# sepa qué es 'filtro'
                var filtro = listaVentasGlobal.Where(v => {
                var prod = listaProductosGlobal.FirstOrDefault(p => p.IdProd == v.CodigoProducto);
                var cli = listaClientesGlobal.FirstOrDefault(c => c.IdCl == v.CodigoCliente);

                string nombreP = prod != null ? prod.NombreProd.ToLower() : "";
                string nombreC = cli != null ? cli.NombreCl.ToLower() : "";

                return v.Id.ToString().Contains(busqueda) ||
                       nombreP.Contains(busqueda) ||
                       nombreC.Contains(busqueda);
            }).ToList();

            // Corregido: Ya no marca error porque 'filtro' ya existe arriba
            MostrarVentasEnTabla(filtro);
        }


        // ========================================================
        // 💾 GUARDAR / ACTUALIZAR VENTA
        // ========================================================
        private async void btn_GuardarVenta_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado == null || clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto y un cliente válidos mediante el buscador.");
                return;
            }

            if (!int.TryParse(txt_Cantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad de venta debe ser mayor a 0.");
                return;
            }

            try
            {
                double totalCalculado = productoSeleccionado.PrecioProd * cantidad;

                if (btn_GuardarVenta.Tag != null) // EDICIÓN
                {
                    long idVentaEditar = Convert.ToInt64(btn_GuardarVenta.Tag);
                    var ventaOriginal = listaVentasGlobal.FirstOrDefault(v => v.Id == idVentaEditar);

                    if (ventaOriginal != null)
                    {
                        // Calcular la diferencia de stock (lo que ya se había restado antes)
                        long cantidadAnterior = ventaOriginal.CantidadVenta;
                        long diferenciaStock = cantidad - cantidadAnterior;

                        // Verificar si hay stock suficiente sumando el ajuste
                        if (diferenciaStock > productoSeleccionado.StockProd)
                        {
                            MessageBox.Show($"Stock insuficiente. Solo quedan {productoSeleccionado.StockProd} unidades.");
                            return;
                        }

                        // Actualizar modelo de venta
                        ventaOriginal.CodigoProducto = productoSeleccionado.IdProd;
                        ventaOriginal.CodigoCliente = clienteSeleccionado.IdCl;
                        ventaOriginal.CantidadVenta = cantidad;
                        ventaOriginal.TotalVenta = totalCalculado;

                        await ConexionDB.Supabase.From<Venta>().Update(ventaOriginal);

                        // Ajustar el stock del producto en base a la diferencia
                        productoSeleccionado.StockProd -= (int)diferenciaStock;
                        await ConexionDB.Supabase.From<Producto>().Update(productoSeleccionado);

                        MessageBox.Show("Venta modificada e inventario actualizado.");
                        btn_GuardarVenta.Tag = null;
                        btn_GuardarVenta.Text = "Registrar Venta";
                    }
                }
                else // NUEVA VENTA
                {
                    if (cantidad > productoSeleccionado.StockProd)
                    {
                        MessageBox.Show($"Stock insuficiente (Disponible: {productoSeleccionado.StockProd}).");
                        return;
                    }

                    var nuevaVenta = new Venta
                    {
                        CodigoProducto = productoSeleccionado.IdProd,
                        CodigoCliente = clienteSeleccionado.IdCl,
                        CantidadVenta = cantidad,
                        TotalVenta = totalCalculado
                    };

                    await ConexionDB.Supabase.From<Venta>().Insert(nuevaVenta);

                    productoSeleccionado.StockProd -= cantidad;
                    await ConexionDB.Supabase.From<Producto>().Update(productoSeleccionado);

                    MessageBox.Show("Transacción procesada correctamente.");
                }

                LimpiarFormulario();
                await RecargarDatosDesdeSupabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el servidor: " + ex.Message);
            }
        }
        // ========================================================
        // 📑 MENÚ CONTEXTUAL Y ACCIONES DE LA TABLA
        // ========================================================
        private void Tabla_Ventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && Tabla_Ventas.Columns[e.ColumnIndex].Name == "Opciones")
            {
                filaSeleccionada = e.RowIndex;
                contextMenuStrip1.Show(Cursor.Position); // Usa el nombre de tu ContextMenuStrip de Ventas
            }
        }
        private void visualizarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                var fila = Tabla_Ventas.Rows[filaSeleccionada];
                MessageBox.Show($"ID Venta: {fila.Cells["ID Venta"].Value}\n" +
                $"Producto: {fila.Cells["Producto"].Value}\n" +
                $"Cliente: {fila.Cells["Cliente"].Value}\n" +
                $"Cantidad: {fila.Cells["Cantidad"].Value}\n" +
                $"Total: {fila.Cells["Total"].Value}",
                "Detalles de la Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                var fila = Tabla_Ventas.Rows[filaSeleccionada];
                long idVenta = Convert.ToInt64(fila.Cells["ID Venta"].Value);
                var venta = listaVentasGlobal.FirstOrDefault(v => v.Id == idVenta);
                if (venta != null)
                {
                    // Volvemos a seleccionar los objetos basándonos en sus códigos
                    productoSeleccionado = listaProductosGlobal.FirstOrDefault(p => p.IdProd == venta.CodigoProducto);
                    clienteSeleccionado = listaClientesGlobal.FirstOrDefault(c => c.IdCl == venta.CodigoCliente);
                    // Colocar la info en los buscadores e inputs
                    txt_BuscarProducto.Text = productoSeleccionado?.NombreProd ?? "";
                    txt_BuscarCliente.Text = clienteSeleccionado?.NombreCl ?? "";
                    txt_Cantidad.Text = venta.CantidadVenta.ToString();
                    btn_GuardarVenta.Tag = venta.Id; // Guardar ID en el Tag
                    btn_GuardarVenta.Text = "Actualizar Venta";
                    MessageBox.Show("Modifique la cantidad o datos y presione 'Actualizar Venta'.", "Editar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private async void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0)
            {
                var fila = Tabla_Ventas.Rows[filaSeleccionada];
                long idVenta = Convert.ToInt64(fila.Cells["ID Venta"].Value);
                string nombreProd = fila.Cells["Producto"].Value.ToString();
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                DialogResult seguro = MessageBox.Show($"¿Estás seguro de que deseas eliminar la venta ID #{idVenta}?\nSe devolverán {cantidad} unidades al stock de '{nombreProd}'.", "Cancelar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (seguro == DialogResult.Yes)
                {
                    try
                    {
                        // 1. Eliminar la venta de Supabase
                        await ConexionDB.Supabase.From<Venta>().Where(v => v.Id == idVenta).Delete();
                        // 2. Devolver las unidades canceladas al Stock del producto
                        var prodAsociado = listaProductosGlobal.FirstOrDefault(p => p.NombreProd == nombreProd);
                        if (prodAsociado != null)
                        {
                            prodAsociado.StockProd += cantidad;
                            await ConexionDB.Supabase.From<Producto>().Update(prodAsociado);
                        }
                        MessageBox.Show("Venta eliminada y stock restablecido.");
                        await RecargarDatosDesdeSupabase();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la venta: " + ex.Message);
                    }
                }
            }
        }
        // ========================================================
        // 🔄 MÉTODOS DE RENDERIZADO Y CONTROL DE DATOS
        // ========================================================
        private async System.Threading.Tasks.Task RecargarDatosDesdeSupabase()
        {
            // Descargar catálogos maestros actualizados primero
            var resProductos = await ConexionDB.Supabase.From<Producto>().Order("id_prod", Postgrest.Constants.Ordering.Ascending).Get();
            listaProductosGlobal = resProductos.Models;
            var resClientes = await ConexionDB.Supabase.From<Cliente>().Order("id_cl", Postgrest.Constants.Ordering.Ascending).Get();
            listaClientesGlobal = resClientes.Models;
            // Descargar historial de ventas
            var resVentas = await ConexionDB.Supabase.From<Venta>().Get();
            listaVentasGlobal = resVentas.Models;
            MostrarVentasEnTabla(listaVentasGlobal);
        }
        private void MostrarVentasEnTabla(List<Venta> lista)
        {
            Tabla_Ventas.Rows.Clear();
            foreach (var venta in lista)
            {
                // CRUZAR DATOS: Buscamos el nombre del producto y cliente usando los códigos guardados en el registro
                var prod = listaProductosGlobal.FirstOrDefault(p => p.IdProd == venta.CodigoProducto);
                var cli = listaClientesGlobal.FirstOrDefault(c => c.IdCl == venta.CodigoCliente);
                string nombreProducto = prod != null ? prod.NombreProd : "No encontrado";
                string nombreCliente = cli != null ? cli.NombreCl : "No encontrado";
                // Insertamos los nombres de forma legible para el usuario
                Tabla_Ventas.Rows.Add(venta.Id, nombreProducto, nombreCliente, venta.CantidadVenta, venta.TotalVenta);
            }
        }
        private void FormVentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LimpiarFormulario()
        {
            productoSeleccionado = null;
            clienteSeleccionado = null;
            txt_BuscarProducto.Clear();
            txt_BuscarCliente.Clear();
            txt_Cantidad.Clear();
            txt_TotalVenta.Clear();
            lbl_ProductoSeleccionado.Text = "Producto: Ninguno";
            lbl_ClienteSeleccionado.Text = "Cliente: Ninguno";
            txt_BuscarProducto.Focus();
        }

    }
}
