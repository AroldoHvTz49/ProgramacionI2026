namespace Pruebas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btn_Click_Prueba = new Button();
            label1 = new Label();
            Nombre = new TextBox();
            Edad = new TextBox();
            label2 = new Label();
            Tabla_Clientes = new DataGridView();
            label3 = new Label();
            Telefono = new TextBox();
            btn_IrProductos = new Button();
            label4 = new Label();
            txt_Buscar = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            visualizarTodoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            btn_IrVentas = new Button();
            ((System.ComponentModel.ISupportInitialize)Tabla_Clientes).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Click_Prueba
            // 
            btn_Click_Prueba.BackColor = SystemColors.ActiveCaption;
            btn_Click_Prueba.ForeColor = Color.Black;
            btn_Click_Prueba.Location = new Point(52, 304);
            btn_Click_Prueba.Name = "btn_Click_Prueba";
            btn_Click_Prueba.Size = new Size(247, 80);
            btn_Click_Prueba.TabIndex = 0;
            btn_Click_Prueba.Text = "Clickeame despues de ingresar nombre";
            btn_Click_Prueba.UseVisualStyleBackColor = false;
            btn_Click_Prueba.Click += btn_Click_Prueba_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 77);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 1;
            label1.Text = "Ingresa Nombre";
            // 
            // Nombre
            // 
            Nombre.BackColor = SystemColors.ControlDark;
            Nombre.ForeColor = SystemColors.Desktop;
            Nombre.Location = new Point(52, 109);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(247, 27);
            Nombre.TabIndex = 2;
            Nombre.Tag = "";
            // 
            // Edad
            // 
            Edad.BackColor = SystemColors.ControlDark;
            Edad.ForeColor = SystemColors.Desktop;
            Edad.Location = new Point(52, 172);
            Edad.Name = "Edad";
            Edad.Size = new Size(247, 27);
            Edad.TabIndex = 3;
            Edad.Tag = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 149);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 4;
            label2.Text = "Ingresa Edad";
            // 
            // Tabla_Clientes
            // 
            Tabla_Clientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabla_Clientes.Location = new Point(402, 135);
            Tabla_Clientes.Name = "Tabla_Clientes";
            Tabla_Clientes.RowHeadersWidth = 51;
            Tabla_Clientes.Size = new Size(560, 296);
            Tabla_Clientes.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 217);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 7;
            label3.Text = "Ingresa Telefono";
            // 
            // Telefono
            // 
            Telefono.BackColor = SystemColors.ControlDark;
            Telefono.ForeColor = SystemColors.Desktop;
            Telefono.Location = new Point(52, 240);
            Telefono.Name = "Telefono";
            Telefono.Size = new Size(247, 27);
            Telefono.TabIndex = 6;
            Telefono.Tag = "";
            // 
            // btn_IrProductos
            // 
            btn_IrProductos.Location = new Point(457, 459);
            btn_IrProductos.Name = "btn_IrProductos";
            btn_IrProductos.Size = new Size(206, 86);
            btn_IrProductos.TabIndex = 8;
            btn_IrProductos.Text = "Ir a Productos";
            btn_IrProductos.UseVisualStyleBackColor = true;
            btn_IrProductos.Click += btn_IrProductos_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(402, 95);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 9;
            label4.Text = "Buscar Cliente:";
            // 
            // txt_Buscar
            // 
            txt_Buscar.Location = new Point(504, 92);
            txt_Buscar.Name = "txt_Buscar";
            txt_Buscar.Size = new Size(458, 27);
            txt_Buscar.TabIndex = 10;
            txt_Buscar.TextChanged += txt_Buscar_TextChanged;
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
            // btn_IrVentas
            // 
            btn_IrVentas.Location = new Point(700, 459);
            btn_IrVentas.Name = "btn_IrVentas";
            btn_IrVentas.Size = new Size(206, 86);
            btn_IrVentas.TabIndex = 11;
            btn_IrVentas.Text = "Ir a Ventas";
            btn_IrVentas.UseVisualStyleBackColor = true;
            btn_IrVentas.Click += btn_IrVentas_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 577);
            Controls.Add(btn_IrVentas);
            Controls.Add(txt_Buscar);
            Controls.Add(label4);
            Controls.Add(btn_IrProductos);
            Controls.Add(label3);
            Controls.Add(Telefono);
            Controls.Add(Tabla_Clientes);
            Controls.Add(label2);
            Controls.Add(Edad);
            Controls.Add(Nombre);
            Controls.Add(label1);
            Controls.Add(btn_Click_Prueba);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)Tabla_Clientes).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Click_Prueba;
        private Label label1;
        private TextBox Nombre;
        private TextBox Edad;
        private Label label2;
        private DataGridView Tabla_Clientes;
        private Label label3;
        private TextBox Telefono;
        private Button btn_IrProductos;
        private Label label4;
        private TextBox txt_Buscar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem visualizarTodoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private Button btn_IrVentas;
    }
}
