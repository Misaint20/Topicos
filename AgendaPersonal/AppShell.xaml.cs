using AgendaPersonal.Views;

namespace AgendaPersonal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registrar rutas
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("DetalleContactPage", typeof(DetalleContactPage));
            Routing.RegisterRoute("CrearContactPage", typeof(CrearContactPage));
            Routing.RegisterRoute("ContactsPage", typeof(ContactsPage));
            Routing.RegisterRoute("ConfigurationPage", typeof(ConfigurationPage));

            // Establecer la página inicial
            CurrentItem = new ShellContent
            {
                Content = new LoginPage()
            };
        }
    }
}