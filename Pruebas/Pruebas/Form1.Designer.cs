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
            btn_Click_Prueba = new Button();
            label1 = new Label();
            Nombre = new TextBox();
            Edad = new TextBox();
            label2 = new Label();
            Tabla_Clientes = new DataGridView();
            label3 = new Label();
            Telefono = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Tabla_Clientes).BeginInit();
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 577);
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
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)Tabla_Clientes).EndInit();
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
    }
}
