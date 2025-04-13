using ControleServicosApp.Models;
using ControleServicosApp.ViewModels;

namespace ControleServicosApp.Views
{
    public partial class CadastroAgendamentoPage : ContentPage
    {
        //  Construtor padrão (sem parâmetros)
        public CadastroAgendamentoPage()
        {
            InitializeComponent();
            BindingContext = new CadastroAgendamentoViewModel();
        }

        //  Construtor com parâmetro (para edição)
        public CadastroAgendamentoPage(Agendamento agendamento)
        {
            InitializeComponent();
            BindingContext = new CadastroAgendamentoViewModel(agendamento);
        }
    }
}