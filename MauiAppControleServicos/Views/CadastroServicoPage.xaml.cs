public partial class CadastroServicoPage : ContentPage
{
    public CadastroServicoPage()
    {
        InitializeComponent();
        BindingContext = new CadastroServicoViewModel(); // Chama o construtor padrão (servico = null)
    }

    public CadastroServicoPage(Servico servico)
    {
        InitializeComponent();
        BindingContext = new CadastroServicoViewModel(servico); // Passa o serviço existente
    }
}