using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GUI_Dinamica.Gallery;

namespace GUI_Dinamica
{
    public partial class Images : Form
    {
        private FlowLayoutPanel flowLayoutPanel;
        private List<string> imagePaths;
        public Images()
        {
            InitializeComponent();
            //LoadImages();
            LoadImagesAsync();
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.WrapContents = true;
            this.flowLayoutPanel.Dock = DockStyle.Fill;
            this.flowLayoutPanel.Location = new Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new Size(800, 450);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // Images
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "Images";
            this.Text = "Images";
            this.ResumeLayout(false);

        }
        // Metodo de carga de imagenes sincrono (no recomendado, uso excesivo de memoria)
        //private void LoadImages()
        //{
        //    this.Show();

        //    string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //    string path = Path.Combine(projectPath, "Gallery", "Images");

        //    if (Directory.Exists(path)) {
        //        string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

        //        string[] files = Directory.GetFiles(path).Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower())).ToArray();

        //        foreach (string file in files)
        //        {
        //            PictureBox pic = new()
        //            {
        //                Image = Image.FromFile(file),
        //                Tag = file,
        //                Name = Path.GetFileName(file)
        //            };
        //            pic.SizeMode = PictureBoxSizeMode.StretchImage;
        //            pic.Size = new Size(100, 100);
        //            pic.Margin = new Padding(5);
        //            pic.Cursor = Cursors.Hand;
        //            pic.Click += Pic_Click;

        //            flowLayoutPanel.Controls.Add(pic);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se encontro la carpeta de imagenes: " + path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // Metodo de carga de imagenes asincrono
        private async void LoadImagesAsync()
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string path = Path.Combine(projectPath, "Gallery", "Images");

            if (Directory.Exists(path))
            {
                string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                imagePaths = Directory.GetFiles(path).Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower())).ToList();

                // Mostrar el formulario antes de cargar las imágenes
                this.Show();

                foreach (string imagePath in imagePaths)
                {
                    // Cargar la imagen en miniatura
                    await Task.Run(() =>
                    {
                        using (Image originalImage = Image.FromFile(imagePath))
                        {
                            // Crear una miniatura
                            Image thumbnail = originalImage.GetThumbnailImage(100, 100, null, IntPtr.Zero);

                            // Agregar la miniatura al FlowLayoutPanel en el hilo principal
                            this.Invoke((MethodInvoker)delegate
                            {
                                PictureBox pic = new()
                                {
                                    Image = thumbnail,
                                    Tag = imagePath,
                                    Name = Path.GetFileName(imagePath)
                                };
                                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                                pic.Size = new Size(100, 100);
                                pic.Margin = new Padding(5);
                                pic.Cursor = Cursors.Hand;
                                pic.Click += Pic_Click;

                                flowLayoutPanel.Controls.Add(pic);
                            });
                        } // originalImage se dispone aquí
                    });
                }
            }
            else
            {
                MessageBox.Show("No se encontró la carpeta de imágenes: " + path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            string imagePath = pic.Tag?.ToString();
            string name = pic.Name.ToString();
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("No se puede encontrar la ruta de la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ImageForm imageForm = new (name, imagePath);
            imageForm.ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (flowLayoutPanel != null)
                {
                    foreach (Control control in flowLayoutPanel.Controls)
                    {
                        if (control is PictureBox pic)
                        {
                            pic.Image?.Dispose();
                            pic.Image = null;
                            pic.Dispose();
                        }
                    }
                    flowLayoutPanel.Controls.Clear();
                    flowLayoutPanel.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
