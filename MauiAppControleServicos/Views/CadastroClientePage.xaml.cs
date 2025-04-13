using Microsoft.Maui.Controls;
using ControleServicosApp.Models;
using ControleServicosApp.ViewModels;

namespace ControleServicosApp.Views
{
    public partial class CadastroClientePage : ContentPage
    {
        // Construtor padr�o (para novo cadastro)
        public CadastroClientePage()
        {
            InitializeComponent();
            BindingContext = new CadastroClienteViewModel();
        }

        // Construtor para edi��o (recebe um cliente existente)
        public CadastroClientePage(Cliente cliente)
        {
            InitializeComponent();
            BindingContext = new CadastroClienteViewModel(cliente);
        }
    }
}