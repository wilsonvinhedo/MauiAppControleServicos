using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MauiAppControleServicos.Views;

namespace ControleServicosApp.ViewModels
{
    public class ClientesViewModel : BindableObject
    {
        public ObservableCollection<Cliente> Clientes { get; set; }
        public ICommand AdicionarClienteCommand { get; }
        public ICommand EditarClienteCommand { get; }
        public ICommand ExcluirClienteCommand { get; }

        public ClientesViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();
            AdicionarClienteCommand = new Command(async () => await AdicionarCliente());
            EditarClienteCommand = new Command<Cliente>(async (cliente) => await EditarCliente(cliente));
            ExcluirClienteCommand = new Command<Cliente>(async (cliente) => await ExcluirCliente(cliente));

            _ = CarregarClientes();
        }

        private async Task CarregarClientes()
        {
            var lista = await App.Database.ListarTodosAsync<Cliente>();
            Clientes.Clear();
            foreach (var cliente in lista)
                Clientes.Add(cliente);
        }

        private async Task AdicionarCliente()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CadastroClientePage());
        }

        private async Task EditarCliente(Cliente cliente)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CadastroClientePage(cliente));
        }

        private async Task ExcluirCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                await App.Database.DeletarAsync(cliente);
                Clientes.Remove(cliente);
            }
        }
    }
}
