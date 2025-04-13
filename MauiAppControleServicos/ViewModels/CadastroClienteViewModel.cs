using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ControleServicosApp.ViewModels
{
    public class CadastroClienteViewModel : BindableObject
    {
        public Cliente Cliente { get; set; }
        public ICommand SalvarClienteCommand { get; }

        public CadastroClienteViewModel()
        {
            Cliente = new Cliente();
            SalvarClienteCommand = new Command(async () => await SalvarCliente());
        }

        private async Task SalvarCliente()
        {
            if (!string.IsNullOrWhiteSpace(Cliente.Nome))
            {
                await App.Database.InserirAsync(Cliente);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
