using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MisaintLibrary
{
    // Enum para definir el tipo de entrada permitida.
    public enum AllowedInputType
    {
        Both,    // Permite letras y números
        Letters, // Solo letras
        Numbers  // Solo números
    }

    public partial class CustomTxtBox : UserControl
    {
        private TextBox innerTextBox;
        private AllowedInputType allowedInput = AllowedInputType.Both;
        // Color normal del borde y color en caso de error
        private Color borderColor = Color.Gray;
        private Color errorBorderColor = Color.Red;
        private bool isError = false;

        public CustomTxtBox()
        {
            InitializeComponent();
            // Ajusta el tamaño del control
            this.Size = new Size(150, 25);
            // Configura el TextBox interno
            innerTextBox = new TextBox();
            innerTextBox.BorderStyle = BorderStyle.None;
            innerTextBox.Location = new Point(3, 3);
            innerTextBox.Width = this.Width - 6;
            innerTextBox.KeyPress += InnerTextBox_KeyPress;
            this.Controls.Add(innerTextBox);

            // Opcional: puedes configurar un Padding para el borde
            this.Padding = new Padding(2);
            this.BackColor = Color.White;
        }

        [Category("Behavior")]
        [Description("Define el tipo de caracteres permitidos: Both, Letters o Numbers")]
        public AllowedInputType AllowedInput
        {
            get { return allowedInput; }
            set { allowedInput = value; }
        }

        // Sobrescribe la propiedad Text para reflejar el texto del TextBox interno.
        public override string Text
        {
            get { return innerTextBox.Text; }
            set { innerTextBox.Text = value; }
        }

        // Valida cada tecla presionada
        private void InnerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsValidChar(e.KeyChar))
            {
                // Si el carácter no es válido, se marca el error y se invalida la tecla
                isError = true;
                this.Invalidate(); // Fuerza el repintado para mostrar el borde en rojo
                e.Handled = true;
            }
            else
            {
                // Si es válido, se asegura de limpiar el error (si lo hubiera)
                isError = false;
                this.Invalidate();
            }
        }

        // Método auxiliar que valida el carácter según la configuración de AllowedInput
        private bool IsValidChar(char c)
        {
            // Permitir siempre los caracteres de control (como Backspace)
            if (char.IsControl(c))
                return true;

            switch (allowedInput)
            {
                case AllowedInputType.Both:
                    return true;
                case AllowedInputType.Letters:
                    return char.IsLetter(c);
                case AllowedInputType.Numbers:
                    return char.IsDigit(c);
                default:
                    return true;
            }
        }

        // Sobrescribe OnPaint para dibujar el borde personalizado
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Selecciona el color del borde según si hay error o no
            Color currentBorderColor = isError ? errorBorderColor : borderColor;
            using (Pen pen = new Pen(currentBorderColor))
            {
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        // Ajusta el tamaño del TextBox interno si se cambia el tamaño del control
        protected override void OnResize(EventArgs e)
        {
            if (innerTextBox != null)
            {
                innerTextBox.Width = this.Width - 6;
                innerTextBox.Height = this.Height - 6;
            }
        }
    }
}
