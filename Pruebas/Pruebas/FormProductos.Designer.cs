namespace Pruebas
{
    partial class FormProductos
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
            label3 = new Label();
            StockProd = new TextBox();
            Tabla_Productos = new DataGridView();
            label2 = new Label();
            PrecioProd = new TextBox();
            NombreProd = new TextBox();
            label1 = new Label();
            btn_GuardarProducto = new Button();
            btn_IrClientes = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            visualizarTodoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            label4 = new Label();
            txt_Buscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Tabla_Productos).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 231);
            label3.Name = "label3";
            label3.Size = new Size(171, 20);
            label3.TabIndex = 15;
            label3.Text = "Ingresa Stock disponible";
            // 
            // StockProd
            // 
            StockProd.BackColor = SystemColors.ControlDark;
            StockProd.ForeColor = SystemColors.Desktop;
            StockProd.Location = new Point(142, 254);
            StockProd.Name = "StockProd";
            StockProd.Size = new Size(247, 27);
            StockProd.TabIndex = 14;
            StockProd.Tag = "";
            // 
            // Tabla_Productos
            // 
            Tabla_Productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabla_Productos.Location = new Point(492, 149);
            Tabla_Productos.Name = "Tabla_Productos";
            Tabla_Productos.RowHeadersWidth = 51;
            Tabla_Productos.Size = new Size(560, 296);
            Tabla_Productos.TabIndex = 13;
            Tabla_Productos.CellContentClick += Tabla_Productos_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 163);
            label2.Name = "label2";
            label2.Size = new Size(191, 20);
            label2.TabIndex = 12;
            label2.Text = "Ingresa Precio del Producto";
            // 
            // PrecioProd
            // 
            PrecioProd.BackColor = SystemColors.ControlDark;
            PrecioProd.ForeColor = SystemColors.Desktop;
            PrecioProd.Location = new Point(142, 186);
            PrecioProd.Name = "PrecioProd";
            PrecioProd.Size = new Size(247, 27);
            PrecioProd.TabIndex = 11;
            PrecioProd.Tag = "";
            // 
            // NombreProd
            // 
            NombreProd.BackColor = SystemColors.ControlDark;
            NombreProd.ForeColor = SystemColors.Desktop;
            NombreProd.Location = new Point(142, 123);
            NombreProd.Name = "NombreProd";
            NombreProd.Size = new Size(247, 27);
            NombreProd.TabIndex = 10;
            NombreProd.Tag = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 91);
            label1.Name = "label1";
            label1.Size = new Size(205, 20);
            label1.TabIndex = 9;
            label1.Text = "Ingresa Nombre del Producto";
            // 
            // btn_GuardarProducto
            // 
            btn_GuardarProducto.Location = new Point(142, 309);
            btn_GuardarProducto.Name = "btn_GuardarProducto";
            btn_GuardarProducto.Size = new Size(247, 67);
            btn_GuardarProducto.TabIndex = 16;
            btn_GuardarProducto.Text = "Guardar Producto";
            btn_GuardarProducto.UseVisualStyleBackColor = true;
            btn_GuardarProducto.Click += btn_GuardarProducto_Click;
            // 
            // btn_IrClientes
            // 
            btn_IrClientes.Location = new Point(649, 475);
            btn_IrClientes.Name = "btn_IrClientes";
            btn_IrClientes.Size = new Size(258, 64);
            btn_IrClientes.TabIndex = 17;
            btn_IrClientes.Text = "Ir a Clientes";
            btn_IrClientes.UseVisualStyleBackColor = true;
            btn_IrClientes.Click += btn_IrClientes_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { visualizarTodoToolStripMenuItem, editarToolStripMenuItem, eliminarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(180, 76);
            // 
            // visualizarTodoToolStripMenuItem
            // 
            visualizarTodoToolStripMenuItem.Name = "visualizarTodoToolStripMenuItem";
            visualizarTodoToolStripMenuItem.Size = new Size(179, 24);
            visualizarTodoToolStripMenuItem.Text = "Visualizar Todo";
            visualizarTodoToolStripMenuItem.Click += visualizarTodoToolStripMenuItem_Click;
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(179, 24);
            editarToolStripMenuItem.Text = "Editar";
            editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(179, 24);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(492, 107);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 19;
            label4.Text = "Buscar Producto";
            // 
            // txt_Buscar
            // 
            txt_Buscar.Location = new Point(614, 104);
            txt_Buscar.Name = "txt_Buscar";
            txt_Buscar.Size = new Size(438, 27);
            txt_Buscar.TabIndex = 20;
            txt_Buscar.TextChanged += txt_Buscar_TextChanged;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 589);
            Controls.Add(txt_Buscar);
            Controls.Add(label4);
            Controls.Add(btn_IrClientes);
            Controls.Add(btn_GuardarProducto);
            Controls.Add(label3);
            Controls.Add(StockProd);
            Controls.Add(Tabla_Productos);
            Controls.Add(label2);
            Controls.Add(PrecioProd);
            Controls.Add(NombreProd);
            Controls.Add(label1);
            Name = "FormProductos";
            Text = "FormProductos";
            FormClosed += FormProductos_FormClosed;
            Load += FormProductos_Load;
            ((System.ComponentModel.ISupportInitialize)Tabla_Productos).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox StockProd;
        private DataGridView Tabla_Productos;
        private Label label2;
        private TextBox PrecioProd;
        private TextBox NombreProd;
        private Label label1;
        private Button btn_GuardarProducto;
        private Button btn_IrClientes;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem visualizarTodoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private Label label4;
        private TextBox txt_Buscar;
    }
}