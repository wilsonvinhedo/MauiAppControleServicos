using SQLite;
using System;

namespace ControleServicosApp.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public int ServicoId { get; set; }

        public DateTime DataHora { get; set; }

        public decimal ValorTotal { get; set; }

        public string Observacoes { get; set; }
    }
}
