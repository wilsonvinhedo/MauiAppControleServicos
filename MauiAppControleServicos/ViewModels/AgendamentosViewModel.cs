using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ControleServicosApp.ViewModels
{
    public class AgendamentosViewModel : BindableObject
    {
        public ObservableCollection<Agendamento> Agendamentos { get; set; }
        public ICommand AdicionarAgendamentoCommand { get; }
        public ICommand EditarAgendamentoCommand { get; }
        public ICommand ExcluirAgendamentoCommand { get; }

        public AgendamentosViewModel()
        {
            Agendamentos = new ObservableCollection<Agendamento>();
            AdicionarAgendamentoCommand = new Command(async () => await AdicionarAgendamento());
            EditarAgendamentoCommand = new Command<Agendamento>(async (agendamento) => await EditarAgendamento(agendamento));
            ExcluirAgendamentoCommand = new Command<Agendamento>(async (agendamento) => await ExcluirAgendamento(agendamento));

            _ = CarregarAgendamentos();
        }

        private async Task CarregarAgendamentos()
        {
            var lista = await App.Database.ListarTodosAsync<Agendamento>();
            Agendamentos.Clear();
            foreach (var agendamento in lista)
                Agendamentos.Add(agendamento);
        }

        private async Task AdicionarAgendamento()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CadastroAgendamentoPage());
        }

        private async Task EditarAgendamento(Agendamento agendamento)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CadastroAgendamentoPage(agendamento));
        }

        private async Task ExcluirAgendamento(Agendamento agendamento)
        {
            if (agendamento != null)
            {
                await App.Database.DeletarAsync(agendamento);
                Agendamentos.Remove(agendamento);
            }
        }
    }
}
