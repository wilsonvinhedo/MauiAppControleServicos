public partial class CadastroServicoPage : ContentPage
{
    public CadastroServicoPage()
    {
        InitializeComponent();
        BindingContext = new CadastroServicoViewModel(); // Chama o construtor padr�o (servico = null)
    }

    public CadastroServicoPage(Servico servico)
    {
        InitializeComponent();
        BindingContext = new CadastroServicoViewModel(servico); // Passa o servi�o existente
    }
}