using ControleServicosApp.Models;
using ControleServicosApp.Database;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ControleServicos.Models;

namespace ControleServicosApp.ViewModels
{
    public class AgendamentosViewModel : BindableObject
    {
        // ...

        private async Task AdicionarAgendamento()
        {
            var mainPage = Application.Current?.Windows.FirstOrDefault()?.Page; // Corrigindo CS0618 e CS8602
            if (mainPage != null)
            {
                await mainPage.Navigation.PushAsync(new CadastroAgendamentoPage());
            }
        }

        private async Task EditarAgendamento(Agendamento agendamento)
        {
            Page? mainPage = Application.Current?.Windows.FirstOrDefault()?.Page; // Corrigindo CS0618 e CS8602
            if (mainPage != null)
            {
                await mainPage.Navigation.PushAsync(new CadastroAgendamentoPage(agendamento));
            }
        }

        // ...
    }
}
