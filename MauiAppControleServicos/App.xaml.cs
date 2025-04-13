using ControleServicosApp.Database;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ControleServicosApp
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }

        public App()
        {
            InitializeDatabase();
            MainPage = new AppShell();
        }

        private async void InitializeDatabase()
        {
            try
            {
                Database = new DatabaseHelper();
                await Database.InitializeAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Falha na inicialização do BD: {ex.Message}");
            }
        }

        protected override async void OnStart()
        {
            base.OnStart();

            if (Database == null)
            {
                InitializeDatabase();
            }
        }
    }
}