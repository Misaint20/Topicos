namespace GUI_Basica
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Gestor de usuarios\n" +
                             "Version 1.0.0\n" +
                             "Desarrollado por: Misaint Murillo\n" +
                             "© 2025 Todos los derechos reservados\n\n" +
                             "Esta aplicacion te permite administrar usuarios de forma sencilla y eficiente.";
            MessageBox.Show(message, "Acerca de: Gestor de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtEmail.Text == "")
            {
                // Mensaje de error en validacion de datos
                // Nota para el maestro: El siguiente codigo fue una adaptacion entre aprendizaje por documentacion,
                // pruebas de forma individual y ChatGPT para probar mejoras visuales y funciones extras posibles
                Image errorIcon = SystemIcons.Error.ToBitmap();

                // Se muestra notificacion de error
                MostrarToast("Campos incompletos", "Favor de completar todos los campos", 3000, errorIcon);
            }
            else
            {
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;

                // Se crea la cadena en string para el guardado de usuarios
                string contact = $"Nombre: {name}, Telefono: {phone}, Correo: {email}\n\n";

                // Se agrega usuario a la lista
                Users.Items.Add(contact);

                // Se limpian TextBoxes
                ClearTextBoxes();

                Image okIcon = SystemIcons.Information.ToBitmap();
                // Confirmacion de usuario guardado
                MostrarToast("Confirmacion", "El usuario se guardo correctamente", 3000, okIcon);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (Users.Items.Count == 0)
            {
                Image warningIcon = SystemIcons.Warning.ToBitmap();
                MostrarToast("Lista vacia", "No hay usuarios registrados", 3000, warningIcon);
                return;
            }

            Users.Items.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtName.TabIndex = 0;
            txtPhone.TabIndex = 1;
            txtEmail.TabIndex = 2;
            BtnAdd.TabIndex = 3;
            BtnDelete.TabIndex = 4;
            BtnClear.TabIndex = 5;
        }

        private void MostrarToast(string title, string message, int duration, Image icon)
        {
            ToastForm toast = new ToastForm(title, message, duration, icon);

            // Posicion del toast
            int margin = 10;
            int x = this.Location.X + margin;
            int y = this.Location.Y + this.ClientSize.Height - toast.Height - margin;

            toast.Location = new Point(x, y);
            toast.Show();
        }

        private void ClearTextBoxes()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(Users.SelectedItem == null)
            {
                Image errorIcon = SystemIcons.Error.ToBitmap();
                MostrarToast("Usuario no seleccionado", "Favor de seleccionar un usuario a eliminar", 3000, errorIcon);
                return;
            }

            Users.Items.Remove(Users.SelectedItem);
        }
    }
}
