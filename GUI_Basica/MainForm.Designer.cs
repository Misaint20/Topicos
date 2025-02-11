namespace GUI_Basica
{
    partial class MainForm
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
            BtnAdd = new Button();
            txtName = new TextBox();
            label1 = new Label();
            Users = new ListBox();
            menuStrip1 = new MenuStrip();
            salirToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            txtPhone = new TextBox();
            BtnDelete = new Button();
            txtEmail = new TextBox();
            BtnClear = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(114, 221);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(75, 23);
            BtnAdd.TabIndex = 0;
            BtnAdd.Text = "Agregar";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(77, 126);
            txtName.Name = "txtName";
            txtName.Size = new Size(162, 23);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(219, 47);
            label1.Name = "label1";
            label1.Size = new Size(200, 30);
            label1.TabIndex = 2;
            label1.Text = "Gestion de usuarios";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Users
            // 
            Users.FormattingEnabled = true;
            Users.HorizontalScrollbar = true;
            Users.ItemHeight = 15;
            Users.Location = new Point(276, 126);
            Users.Name = "Users";
            Users.Size = new Size(313, 244);
            Users.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { salirToolStripMenuItem, acercaDeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(613, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(71, 20);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(77, 154);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(162, 23);
            txtPhone.TabIndex = 6;
            // 
            // BtnDelete
            // 
            BtnDelete.Location = new Point(313, 377);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(75, 23);
            BtnDelete.TabIndex = 5;
            BtnDelete.Text = "Eliminar";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(77, 183);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(162, 23);
            txtEmail.TabIndex = 8;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(474, 377);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(75, 23);
            BtnClear.TabIndex = 7;
            BtnClear.Text = "Vaciar";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 129);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "Nombre: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 157);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 10;
            label3.Text = "Telefono: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 186);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 11;
            label4.Text = "Correo: ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 412);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(BtnClear);
            Controls.Add(txtPhone);
            Controls.Add(BtnDelete);
            Controls.Add(Users);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(BtnAdd);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Gestion de contactos";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAdd;
        private TextBox txtName;
        private Label label1;
        private ListBox Users;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private TextBox txtPhone;
        private Button BtnDelete;
        private TextBox txtEmail;
        private Button BtnClear;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
