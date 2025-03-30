namespace AccesoBaseDatos1
{
    partial class CrearTabla
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
            this.lblNombreTabla = new System.Windows.Forms.Label();
            this.txtNombreTabla = new System.Windows.Forms.TextBox();
            this.lblDefinicionColumnas = new System.Windows.Forms.Label();
            this.txtDefinicionColumnas = new System.Windows.Forms.TextBox();
            this.btnCrearTabla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombreTabla
            // 
            this.lblNombreTabla.AutoSize = true;
            this.lblNombreTabla.Location = new System.Drawing.Point(20, 20);
            this.lblNombreTabla.Name = "lblNombreTabla";
            this.lblNombreTabla.Size = new System.Drawing.Size(104, 13);
            this.lblNombreTabla.TabIndex = 0;
            this.lblNombreTabla.Text = "Nombre de la Tabla:";
            // 
            // txtNombreTabla
            // 
            this.txtNombreTabla.Location = new System.Drawing.Point(130, 17);
            this.txtNombreTabla.Name = "txtNombreTabla";
            this.txtNombreTabla.Size = new System.Drawing.Size(200, 20);
            this.txtNombreTabla.TabIndex = 1;
            // 
            // lblDefinicionColumnas
            // 
            this.lblDefinicionColumnas.AutoSize = true;
            this.lblDefinicionColumnas.Location = new System.Drawing.Point(20, 60);
            this.lblDefinicionColumnas.Name = "lblDefinicionColumnas";
            this.lblDefinicionColumnas.Size = new System.Drawing.Size(157, 13);
            this.lblDefinicionColumnas.TabIndex = 2;
            this.lblDefinicionColumnas.Text = "Definición de Columnas (SQL):";
            // 
            // txtDefinicionColumnas
            // 
            this.txtDefinicionColumnas.Location = new System.Drawing.Point(20, 80);
            this.txtDefinicionColumnas.Multiline = true;
            this.txtDefinicionColumnas.Name = "txtDefinicionColumnas";
            this.txtDefinicionColumnas.Size = new System.Drawing.Size(310, 80);
            this.txtDefinicionColumnas.TabIndex = 3;
            // 
            // btnCrearTabla
            // 
            this.btnCrearTabla.Location = new System.Drawing.Point(120, 180);
            this.btnCrearTabla.Name = "btnCrearTabla";
            this.btnCrearTabla.Size = new System.Drawing.Size(120, 30);
            this.btnCrearTabla.TabIndex = 4;
            this.btnCrearTabla.Text = "Crear Tabla";
            this.btnCrearTabla.UseVisualStyleBackColor = true;
            this.btnCrearTabla.Click += new System.EventHandler(this.btnCrearTabla_Click);
            // 
            // CrearTablaForm
            // 
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.btnCrearTabla);
            this.Controls.Add(this.txtDefinicionColumnas);
            this.Controls.Add(this.lblDefinicionColumnas);
            this.Controls.Add(this.txtNombreTabla);
            this.Controls.Add(this.lblNombreTabla);
            this.Name = "CrearTablaForm";
            this.Text = "Crear Tabla";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNombreTabla;
        private System.Windows.Forms.TextBox txtNombreTabla;
        private System.Windows.Forms.Label lblDefinicionColumnas;
        private System.Windows.Forms.TextBox txtDefinicionColumnas;
        private System.Windows.Forms.Button btnCrearTabla;

    }
}