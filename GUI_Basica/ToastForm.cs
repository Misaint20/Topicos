using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GUI_Basica
{
    public partial class ToastForm : Form
    {
        private Timer closeTimer;
        public ToastForm(string titulo, string message, int closeTime, Image icon)
        {
            InitializeComponent();

            // Configuracion del formulario
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.FromArgb(50, 50, 50);
            this.Opacity = 0.9;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Configuracion del Label para el titulo
            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Padding = new Padding(10, 10, 10, 5);

            // Configuracion del Label para el mensaje
            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.ForeColor = Color.White;
            lblMessage.Font = new Font("Segoe UI", 10);
            lblMessage.AutoSize = true;
            lblMessage.Padding = new Padding(10, 5, 10 ,10);

            // Panel para organizar controles
            FlowLayoutPanel principalPanel = new FlowLayoutPanel();
            principalPanel.FlowDirection = FlowDirection.LeftToRight;
            principalPanel.BackColor = Color.Transparent;
            principalPanel.AutoSize = true;
            principalPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            principalPanel.Padding = new Padding(0);
            principalPanel.Margin = new Padding(0);

            // Icono con PictureBox
            if (icon != null)
            {
                PictureBox pbIcon = new PictureBox();
                pbIcon.Image = icon;
                pbIcon.SizeMode = PictureBoxSizeMode.AutoSize;
                pbIcon.Padding = new Padding(10);
                principalPanel.Controls.Add(pbIcon);
            }

            // Organizar textos
            FlowLayoutPanel textPanel = new FlowLayoutPanel();
            textPanel.FlowDirection = FlowDirection.TopDown;
            textPanel.BackColor = Color.Transparent;
            textPanel.AutoSize = true;
            textPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            textPanel.Padding = new Padding(0);
            textPanel.Margin = new Padding(0);

            textPanel.Controls.Add(lblTitulo);
            textPanel.Controls.Add(lblMessage);

            principalPanel.Controls.Add(textPanel);

            this.Controls.Add(principalPanel);

            // Timer de muestra de formulario
            closeTimer = new Timer();
            closeTimer.Interval = closeTime;
            closeTimer.Tick += (s, e) =>
            {
                closeTimer.Stop();
                this.Close();
            };
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            closeTimer.Start();
        }
    }
}
