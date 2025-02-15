using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Dinamica.Gallery
{
    public partial class ImageForm : Form
    {
        private PictureBox pictureBox;
        private Image image; 

        public ImageForm(string name, string imagePath)
        {
            InitializeComponent();
            ConfigureImageForm(name, imagePath);
        }

        private void ConfigureImageForm(string name, string imagePath)
        {
            try
            {
                // Cargar la imagen y almacenar la referencia
                image = Image.FromFile(imagePath);

                pictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };

                this.Controls.Add(pictureBox);
                this.StartPosition = FormStartPosition.CenterParent;
                this.Text = "Imagen: " + name;

                // Ajustar el tamaño del formulario al tamaño de la imagen
                this.ClientSize = new Size(image.Width + 10, image.Height + 10); // +10 para el margen
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Liberar la imagen si se ha cargado
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }

                // Liberar el PictureBox
                if (pictureBox != null)
                {
                    pictureBox.Dispose();
                    pictureBox = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}