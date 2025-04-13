using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ControleServicosApp.ViewModels
{
    public class CadastroAgendamentoViewModel : BindableObject
    {
        public Agendamento Agendamento { get; set; }
        public ObservableCollection<Cliente> Clientes { get; set; }
        public ObservableCollection<Servico> Servicos { get; set; }
        public ICommand SalvarAgendamentoCommand { get; }

        public CadastroAgendamentoViewModel()
        {
            Agendamento = new Agendamento();
            Clientes = new ObservableCollection<Cliente>();
            Servicos = new ObservableCollection<Servico>();

            SalvarAgendamentoCommand = new Command(async () => await SalvarAgendamento());

            _ = CarregarDados();
        }

        private async Task CarregarDados()
        {
            Clientes.Clear();
            Servicos.Clear();

            var listaClientes = await App.Database.ListarTodosAsync<Cliente>();
            var listaServicos = await App.Database.ListarTodosAsync<Servico>();

            foreach (var item in listaClientes) Clientes.Add(item);
            foreach (var item in listaServicos) Servicos.Add(item);
        }

        private async Task SalvarAgendamento()
        {
            await App.Database.InserirAsync(Agendamento);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
