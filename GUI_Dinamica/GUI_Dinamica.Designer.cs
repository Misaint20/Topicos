namespace GUI_Dinamica
{
    partial class GUI_Dinamica
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
            menuStrip1 = new MenuStrip();
            creacionDeBotonesToolStripMenuItem = new ToolStripMenuItem();
            galeriaDeImagenesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { creacionDeBotonesToolStripMenuItem, galeriaDeImagenesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(338, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // creacionDeBotonesToolStripMenuItem
            // 
            creacionDeBotonesToolStripMenuItem.Name = "creacionDeBotonesToolStripMenuItem";
            creacionDeBotonesToolStripMenuItem.Size = new Size(128, 20);
            creacionDeBotonesToolStripMenuItem.Text = "Creacion de botones";
            creacionDeBotonesToolStripMenuItem.Click += creacionDeBotonesToolStripMenuItem_Click;
            // 
            // galeriaDeImagenesToolStripMenuItem
            // 
            galeriaDeImagenesToolStripMenuItem.Name = "galeriaDeImagenesToolStripMenuItem";
            galeriaDeImagenesToolStripMenuItem.Size = new Size(125, 20);
            galeriaDeImagenesToolStripMenuItem.Text = "Galeria de imagenes";
            galeriaDeImagenesToolStripMenuItem.Click += galeriaDeImagenesToolStripMenuItem_Click;
            // 
            // GUI_Dinamica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 318);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "GUI_Dinamica";
            Text = "GUI_Dinamica";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem creacionDeBotonesToolStripMenuItem;
        private ToolStripMenuItem galeriaDeImagenesToolStripMenuItem;
    }
}