using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ControleServicosApp.ViewModels
{
    public class ServicosViewModel : BindableObject
    {
        public ObservableCollection<Servico> Servicos { get; set; }
        public ICommand AdicionarServicoCommand { get; }
        public ICommand EditarServicoCommand { get; }
        public ICommand ExcluirServicoCommand { get; }

        public ServicosViewModel()
        {
            Servicos = new ObservableCollection<Servico>();
            AdicionarServicoCommand = new Command(async () => await AdicionarServico());
            EditarServicoCommand = new Command<Servico>(async (servico) => await EditarServico(servico));
            ExcluirServicoCommand = new Command<Servico>(async (servico) => await ExcluirServico(servico));

            _ = CarregarServicos();
        }

        private async Task CarregarServicos()
        {
            var lista = await App.Database.ListarTodosAsync<Servico>();
            Servicos.Clear();
            foreach (var servico in lista)
                Servicos.Add(servico);
        }

        private async Task AdicionarServico()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CadastroServicoPage());
        }

        private async Task EditarServico(Servico servico)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CadastroServicoPage(servico));
        }

        private async Task ExcluirServico(Servico servico)
        {
            if (servico != null)
            {
                await App.Database.DeletarAsync(servico);
                Servicos.Remove(servico);
            }
        }
    }
}
