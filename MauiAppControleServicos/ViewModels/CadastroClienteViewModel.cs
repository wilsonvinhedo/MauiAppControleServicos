using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using ControleServicosApp.Models;
using ControleServicosApp.Database;

namespace ControleServicosApp.ViewModels
{
    public class CadastroClienteViewModel : BindableObject
    {
        public Cliente Cliente { get; set; }

        // Modificado para usar propriedade autoimplementada com set privado
        public ICommand SalvarClienteCommand { get; private set; }

        public CadastroClienteViewModel()
        {
            Initialize(new Cliente());
        }

        public CadastroClienteViewModel(Cliente cliente)
        {
            Initialize(cliente);
        }

        private void Initialize(Cliente cliente)
        {
            Cliente = cliente;
            // Agora pode atribuir pois a propriedade tem set privado
            SalvarClienteCommand = new Command(async () => await SalvarCliente());
        }

        private async Task SalvarCliente()
        {
            if (string.IsNullOrWhiteSpace(Cliente.Nome))
                return;

            try
            {
                await App.Database.InserirAsync(Cliente);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}