namespace Pruebas
{
    partial class FormVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txt_BuscarProducto = new TextBox();
            label1 = new Label();
            lbl_ProductoSeleccionado = new Label();
            lbl_ClienteSeleccionado = new Label();
            label3 = new Label();
            txt_BuscarCliente = new TextBox();
            Tabla_Ventas = new DataGridView();
            label2 = new Label();
            txt_Cantidad = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txt_TotalVenta = new TextBox();
            btn_GuardarVenta = new Button();
            txt_BuscarHistorial = new TextBox();
            label6 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            verDetallesToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)Tabla_Ventas).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txt_BuscarProducto
            // 
            txt_BuscarProducto.Location = new Point(106, 75);
            txt_BuscarProducto.Name = "txt_BuscarProducto";
            txt_BuscarProducto.Size = new Size(273, 27);
            txt_BuscarProducto.TabIndex = 0;
            txt_BuscarProducto.TextChanged += txt_BuscarProducto_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 26);
            label1.Name = "label1";
            label1.Size = new Size(122, 31);
            label1.TabIndex = 1;
            label1.Text = "Productos:";
            // 
            // lbl_ProductoSeleccionado
            // 
            lbl_ProductoSeleccionado.AutoSize = true;
            lbl_ProductoSeleccionado.Location = new Point(106, 115);
            lbl_ProductoSeleccionado.Name = "lbl_ProductoSeleccionado";
            lbl_ProductoSeleccionado.Size = new Size(133, 20);
            lbl_ProductoSeleccionado.TabIndex = 2;
            lbl_ProductoSeleccionado.Text = "Producto: Ninguno";
            // 
            // lbl_ClienteSeleccionado
            // 
            lbl_ClienteSeleccionado.AutoSize = true;
            lbl_ClienteSeleccionado.Location = new Point(106, 262);
            lbl_ClienteSeleccionado.Name = "lbl_ClienteSeleccionado";
            lbl_ClienteSeleccionado.Size = new Size(119, 20);
            lbl_ClienteSeleccionado.TabIndex = 5;
            lbl_ClienteSeleccionado.Text = "Cliente: Ninguno";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(106, 173);
            label3.Name = "label3";
            label3.Size = new Size(90, 31);
            label3.TabIndex = 4;
            label3.Text = "Cliente:";
            // 
            // txt_BuscarCliente
            // 
            txt_BuscarCliente.Location = new Point(106, 222);
            txt_BuscarCliente.Name = "txt_BuscarCliente";
            txt_BuscarCliente.Size = new Size(273, 27);
            txt_BuscarCliente.TabIndex = 3;
            txt_BuscarCliente.TextChanged += txt_BuscarCliente_TextChanged;
            // 
            // Tabla_Ventas
            // 
            Tabla_Ventas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabla_Ventas.Location = new Point(505, 138);
            Tabla_Ventas.Name = "Tabla_Ventas";
            Tabla_Ventas.RowHeadersWidth = 51;
            Tabla_Ventas.Size = new Size(793, 318);
            Tabla_Ventas.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(106, 323);
            label2.Name = "label2";
            label2.Size = new Size(77, 31);
            label2.TabIndex = 8;
            label2.Text = "Venta:";
            // 
            // txt_Cantidad
            // 
            txt_Cantidad.Location = new Point(106, 408);
            txt_Cantidad.Name = "txt_Cantidad";
            txt_Cantidad.Size = new Size(273, 27);
            txt_Cantidad.TabIndex = 7;
            txt_Cantidad.TextChanged += txt_Cantidad_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(109, 374);
            label4.Name = "label4";
            label4.Size = new Size(131, 20);
            label4.TabIndex = 9;
            label4.Text = "Cantidad de Venta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(112, 454);
            label5.Name = "label5";
            label5.Size = new Size(120, 20);
            label5.TabIndex = 11;
            label5.Text = "Total de la Venta";
            // 
            // txt_TotalVenta
            // 
            txt_TotalVenta.Location = new Point(109, 488);
            txt_TotalVenta.Name = "txt_TotalVenta";
            txt_TotalVenta.Size = new Size(273, 27);
            txt_TotalVenta.TabIndex = 10;
            // 
            // btn_GuardarVenta
            // 
            btn_GuardarVenta.Location = new Point(122, 542);
            btn_GuardarVenta.Name = "btn_GuardarVenta";
            btn_GuardarVenta.Size = new Size(239, 66);
            btn_GuardarVenta.TabIndex = 12;
            btn_GuardarVenta.Text = "Registrar Venta";
            btn_GuardarVenta.UseVisualStyleBackColor = true;
            btn_GuardarVenta.Click += btn_GuardarVenta_Click;
            // 
            // txt_BuscarHistorial
            // 
            txt_BuscarHistorial.Location = new Point(602, 92);
            txt_BuscarHistorial.Name = "txt_BuscarHistorial";
            txt_BuscarHistorial.Size = new Size(696, 27);
            txt_BuscarHistorial.TabIndex = 13;
            txt_BuscarHistorial.TextChanged += txt_BuscarHistorial_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(505, 95);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 14;
            label6.Text = "Filtrar Venta:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { verDetallesToolStripMenuItem, editarToolStripMenuItem, eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(158, 76);
            // 
            // verDetallesToolStripMenuItem
            // 
            verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            verDetallesToolStripMenuItem.Size = new Size(157, 24);
            verDetallesToolStripMenuItem.Text = "Ver Detalles";
            verDetallesToolStripMenuItem.Click += visualizarTodoToolStripMenuItem_Click;
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(157, 24);
            editarToolStripMenuItem.Text = "Editar";
            editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(157, 24);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 719);
            Controls.Add(label6);
            Controls.Add(txt_BuscarHistorial);
            Controls.Add(btn_GuardarVenta);
            Controls.Add(label5);
            Controls.Add(txt_TotalVenta);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(txt_Cantidad);
            Controls.Add(Tabla_Ventas);
            Controls.Add(lbl_ClienteSeleccionado);
            Controls.Add(label3);
            Controls.Add(txt_BuscarCliente);
            Controls.Add(lbl_ProductoSeleccionado);
            Controls.Add(label1);
            Controls.Add(txt_BuscarProducto);
            Name = "FormVentas";
            Text = "FormVentas";
            FormClosed += FormVentas_FormClosed;
            Load += FormVentas_Load;
            ((System.ComponentModel.ISupportInitialize)Tabla_Ventas).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_BuscarProducto;
        private Label label1;
        private Label lbl_ProductoSeleccionado;
        private Label lbl_ClienteSeleccionado;
        private Label label3;
        private TextBox txt_BuscarCliente;
        private DataGridView Tabla_Ventas;
        private Label label2;
        private TextBox txt_Cantidad;
        private Label label4;
        private Label label5;
        private TextBox txt_TotalVenta;
        private Button btn_GuardarVenta;
        private TextBox txt_BuscarHistorial;
        private Label label6;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem verDetallesToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
    }
}