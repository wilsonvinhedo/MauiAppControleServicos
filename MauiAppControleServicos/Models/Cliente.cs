using SQLite;

namespace ControleServicosApp.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        // Adicione outros campos conforme necessário
    }
}