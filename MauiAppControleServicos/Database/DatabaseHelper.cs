using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using SQLite;
using ControleServicosApp.Models;

namespace ControleServicosApp.Database
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;
        private bool _initialized = false;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public DatabaseHelper()
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "ControleServicos.db3");
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                if (!_initialized)
                {
                    // Criação de tabelas com configurações específicas
                    await _database.CreateTableAsync<Cliente>();
                    await _database.CreateTableAsync<Servico>();
                    await _database.CreateTableAsync<Agendamento>();
                    _initialized = true;
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        // █ Métodos específicos para Serviço (novos)
        public async Task<int> SalvarServicoAsync(Servico servico)
        {
            await InitializeAsync();
            return servico.Id == 0
                ? await _database.InsertAsync(servico)
                : await _database.UpdateAsync(servico);
        }

        public async Task<List<Servico>> ObterServicosAsync()
        {
            await InitializeAsync();
            return await _database.Table<Servico>().ToListAsync();
        }

        // █ Métodos para Cliente (mantidos)
        public async Task<int> SalvarClienteAsync(Cliente cliente)
        {
            await InitializeAsync();
            return cliente.Id == 0
                ? await _database.InsertAsync(cliente)
                : await _database.UpdateAsync(cliente);
        }

        public async Task<List<Cliente>> ObterClientesAsync()
        {
            await InitializeAsync();
            return await _database.Table<Cliente>().ToListAsync();
        }

        // █ Métodos genéricos (para qualquer entidade)
        public async Task<int> InserirAsync<T>(T entidade) where T : new()
        {
            await InitializeAsync();
            return await _database.InsertAsync(entidade);
        }

        public async Task<List<T>> ListarTodosAsync<T>() where T : new()
        {
            await InitializeAsync();
            return await _database.Table<T>().ToListAsync();
        }

        public async Task<int> AtualizarAsync<T>(T entidade) where T : new()
        {
            await InitializeAsync();
            return await _database.UpdateAsync(entidade);
        }

        public async Task<int> DeletarAsync<T>(T entidade) where T : new()
        {
            await InitializeAsync();
            return await _database.DeleteAsync(entidade);
        }

        // █ Método transacional aprimorado
        public async Task RunInTransactionAsync(Func<Task> action)
        {
            await _semaphore.WaitAsync();
            try
            {
                await _database.RunInTransactionAsync(async t =>
                {
                    await action();
                });
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}