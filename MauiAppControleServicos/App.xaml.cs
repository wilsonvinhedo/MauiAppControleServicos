using ControleServicosApp.Database;
using System.Threading.Tasks;

public partial class App : Application
{
    public static DatabaseHelper Database { get; private set; }

    public App()
    {
        InitializeComponent();
        Database = new DatabaseHelper();
        Task.Run(async () => await Database.InitializeAsync());
        MainPage = new MainPage();
    }
}
