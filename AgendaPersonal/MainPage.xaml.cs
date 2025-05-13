namespace AgendaPersonal
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void IrListaContactos(object sender, EventArgs e)
        {
            // Navegar a la página de contactos
            await Shell.Current.GoToAsync("/ContactsPage");
        }
        private async void IrCrearContacto(object sender, EventArgs e)
        {
            // Navegar a la página de crear contacto
            await Shell.Current.GoToAsync("/CrearContactPage");
        }
        private async void IrConfiguracion(object sender, EventArgs e)
        {
            // Navegar a la página de configuración
            await Shell.Current.GoToAsync("/ConfigurationPage");
        }
    }

}
