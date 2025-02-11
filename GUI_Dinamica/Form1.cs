namespace GUI_Dinamica
{
    public partial class Form1 : Form
    {
        private Button btnAddControls;
        private List<Button> dynamicButtons = new List<Button>();
        private List<TextBox> dynamicTextBoxes = new List<TextBox>();
        private int controlCounter = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configuracion de la ventana
            this.Text = "Creacion Dinamica de Controles";
            this.Size = new Size(400, 400);

            // Boton para agregar controles dinamicamente
            btnAddControls = new Button();
            btnAddControls.Text = "Agregar controles";
            btnAddControls.Location = new Point(20, 20);
            btnAddControls.Click += new EventHandler(AddControls);
            this.Controls.Add(btnAddControls);
        }

        private void AddControls(object sender, EventArgs e)
        {
            // Crear nuevo boton 
            Button newButton = new Button();
            newButton.Text = "Boton " + controlCounter;
            newButton.Size = new Size(100, 30);
            newButton.Location = new Point(20, 60 + dynamicButtons.Count * 40);
            newButton.Click += DynamicButtonClick;

            // Crear una nueva caja de texto
            TextBox newTextBox = new TextBox();
            newTextBox.Size = new Size(150, 30);
            newTextBox.Location = new Point(140, 60 + dynamicTextBoxes.Count * 40);
            newTextBox.KeyPress += DynamicTextKeyPress;
            newTextBox.Tag = controlCounter;

            dynamicTextBoxes.Add(newTextBox);
            dynamicButtons.Add(newButton);

            this.Controls.Add(newTextBox);
            this.Controls.Add(newButton);

            controlCounter++;
        }

        private void DynamicButtonClick(object sender, EventArgs e) { 
            Button clickedButton = sender as Button;
            MessageBox.Show("Has presionado: " + clickedButton.Text);
        }

        private void DynamicTextKeyPress(object sender, KeyPressEventArgs e) {
            TextBox keyText = sender as TextBox;

            int idx = (int)keyText.Tag % 2;
            int tecla = (int)e.KeyChar;

            // Validacion TextBoxes no pares
            if(idx == 1)
            {
                if(!int.TryParse(e.KeyChar.ToString(), out _) || tecla == 127)
                    e.Handled = true;
            } 
            // Validacion TextBoxes pares
            else
            {
                if(int.TryParse(e.KeyChar.ToString(), out _) || tecla == 127)
                    e.Handled = true;
            }
        }
    }
}
