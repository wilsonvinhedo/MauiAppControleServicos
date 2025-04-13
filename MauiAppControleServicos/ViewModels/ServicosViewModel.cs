using ControleServicosApp.Models;
using System.Windows.Input;
using Microsoft.Maui.Controls;

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

        public CadastroServicoViewModel(Servico servico)
        {
            Servico = servico;
            SalvarServicoCommand = new Command(async () => await SalvarServico());
        }

        private async Task SalvarServico()
        {
            if (string.IsNullOrWhiteSpace(Servico.Nome))
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Nome do serviço é obrigatório", "OK");
                return;
            }

            try
            {
                if (Servico.Id == 0)
                    await App.Database.InserirAsync(Servico);
                else
                    await App.Database.AtualizarAsync(Servico);

                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}