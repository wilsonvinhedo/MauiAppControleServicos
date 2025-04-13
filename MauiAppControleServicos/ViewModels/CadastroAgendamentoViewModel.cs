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

        public ICommand SalvarAgendamentoCommand { get; }

        // Construtor padrão
        public CadastroAgendamentoViewModel()
        {
            Agendamento = new Agendamento();
            SalvarAgendamentoCommand = new Command(async () => await SalvarAgendamento());
            _ = CarregarDados();
        }

        // Construtor para editar um agendamento existente
        public CadastroAgendamentoViewModel(Agendamento agendamento)
        {
            Agendamento = agendamento;
            SalvarAgendamentoCommand = new Command(async () => await SalvarAgendamento());
            _ = CarregarDados();
        }

        private async Task CarregarDados()
        {
            // carregar lista de clientes e serviços aqui se for necessário
        }

        private async Task SalvarAgendamento()
        {
            await App.Database.InserirAsync(Agendamento);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}