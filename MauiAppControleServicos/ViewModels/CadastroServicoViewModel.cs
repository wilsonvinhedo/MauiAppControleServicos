using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ControleServicosApp.ViewModels
{
    public class CadastroServicoViewModel : BindableObject
    {
        public Servico Servico { get; set; }
        public ICommand SalvarServicoCommand { get; }

        public CadastroServicoViewModel()
        {
            Servico = new Servico();
            SalvarServicoCommand = new Command(async () => await SalvarServico());
        }

        private async Task SalvarServico()
        {
            if (!string.IsNullOrWhiteSpace(Servico.Nome) && Servico.Preco > 0)
            {
                await App.Database.InserirAsync(Servico);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
