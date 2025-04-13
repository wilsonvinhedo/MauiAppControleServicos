using SQLite;
using System;

namespace ControleServicosApp.Models
{
    public class Financeiro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int AgendamentoId { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public string Tipo { get; set; } // Entrada ou Saída

        public string Descricao { get; set; }
    }
}
