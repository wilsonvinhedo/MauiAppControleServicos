using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ControleServicosApp.Database
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ControleServicos.db3");
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<Cliente>();
            await _database.CreateTableAsync<Servico>();
            await _database.CreateTableAsync<Agendamento>();
        }

        public Task<int> InserirAsync<T>(T entidade) where T : new()
        {
            return _database.InsertAsync(entidade);
        }

        public Task<List<T>> ListarTodosAsync<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<int> AtualizarAsync<T>(T entidade) where T : new()
        {
            return _database.UpdateAsync(entidade);
        }

        public Task<int> DeletarAsync<T>(T entidade) where T : new()
        {
            return _database.DeleteAsync(entidade);
        }
    }
}
