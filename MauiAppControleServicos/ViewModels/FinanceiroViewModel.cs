using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Maui.Controls;

namespace ControleServicosApp.ViewModels
{
    public class FinanceiroViewModel : BindableObject
    {
        public ObservableCollection<Financeiro> RegistrosFinanceiros { get; set; }
        private decimal totalFinanceiro;

        public decimal TotalFinanceiro
        {
            get => totalFinanceiro;
            set
            {
                totalFinanceiro = value;
                OnPropertyChanged();
            }
        }

        public FinanceiroViewModel()
        {
            RegistrosFinanceiros = new ObservableCollection<Financeiro>();
            _ = CarregarFinanceiro();
        }

        private async Task CarregarFinanceiro()
        {
            var lista = await App.Database.ListarTodosAsync<Financeiro>();
            RegistrosFinanceiros.Clear();

            foreach (var item in lista)
                RegistrosFinanceiros.Add(item);

            TotalFinanceiro = RegistrosFinanceiros.Sum(f => f.Tipo == "Entrada" ? f.Valor : -f.Valor);
        }
    }
}
