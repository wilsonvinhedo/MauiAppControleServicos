namespace ControleServicosApp.Views
{
    public partial class ServicosPage : ContentPage
    {
        public ServicosPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ServicosViewModel();
        }
    }
}