using ControleServicosApp.Models;

namespace ControleServicosApp.Views
{
    public partial class CadastroAgendamentoPage : ContentPage
    {
        public CadastroAgendamentoPage()
        {
            InitializeComponent();
        }

        // Adding a constructor that accepts an Agendamento parameter
        public CadastroAgendamentoPage(Agendamento agendamento) : this()
        {
            // You can initialize the page with the provided Agendamento object here
            BindingContext = agendamento;
        }
    }
}
