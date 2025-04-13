using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ControleServicosApp.ViewModels
{
    public class CadastroFinanceiroViewModel : BindableObject
    {
        public Financeiro RegistroFinanceiro { get; set; }
        public ICommand SalvarRegistroCommand { get; }

        public CadastroFinanceiroViewModel()
        {
            RegistroFinanceiro = new Financeiro();
            SalvarRegistroCommand = new Command(async () => await SalvarRegistro());
        }

        private async Task SalvarRegistro()
        {
            await App.Database.InserirAsync(RegistroFinanceiro);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
