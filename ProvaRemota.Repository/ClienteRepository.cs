using Dapper;
using ProvaRemota.Domain.Entity;
using ProvaRemota.Domain.Interfaces;
using System.Data;

namespace ProvaRemota.Repository
{

    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
          
        }

        public async Task<Cliente> GetById(int id)
        {
            string sql = @"SELECT c.Id, c.Nome, c.CPF, c.TipoClienteId, c.Sexo, c.SituacaoClienteId,
                 tp.Id, tp.Descricao, 
                 sc.Id , sc.Descricao 
                 FROM Cliente c LEFT JOIN TipoCliente tp on  c.TipoClienteId = tp.Id
                 LEFT JOIN SituacaoCliente sc ON c.SituacaoClienteId = sc.Id
                 WHERE c.Id = @id";

            var param = new DynamicParameters();
            param.Add("id", id);

            var clientes = await _dbConnection.QueryAsync<Cliente, TipoCliente, SituacaoCliente, Cliente>(sql,
                (cliente, tipoCliente, situacaoCliente) =>
                {
                    cliente.TipoCliente = tipoCliente;
                    cliente.SituacaoCliente = situacaoCliente;
                    return cliente;
                }, param,
                splitOn: "Id,Id,Id");

            return clientes.FirstOrDefault();
             
        }

        public async Task<Cliente> ValidateUniqueCPF(string CPF)
        {
            string sql = "SELECT Id, Nome, CPF, TipoClienteId, Sexo, SituacaoClienteId FROM Cliente WHERE CPF = @cpf";

            var param = new DynamicParameters();
            param.Add("cpf", CPF);

            return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(sql, param);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            string sql = @"SELECT c.Id, c.Nome, c.CPF, c.TipoClienteId, c.Sexo, c.SituacaoClienteId, 
                 tp.Id, tp.Descricao, 
                 sc.Id , sc.Descricao 
                 FROM Cliente c LEFT JOIN TipoCliente tp on  c.TipoClienteId = tp.Id 
                 LEFT JOIN SituacaoCliente sc ON c.SituacaoClienteId = sc.Id";

            var clientes = await _dbConnection.QueryAsync<Cliente, TipoCliente, SituacaoCliente, Cliente>(sql,
                (cliente, tipoCliente, situacaoCliente) =>
                {
                    cliente.TipoCliente = tipoCliente;
                    cliente.SituacaoCliente = situacaoCliente;
                    return cliente;
                }, 
                splitOn: "Id,Id,Id");

            return clientes;
        }

        public async Task Insert(Cliente cliente)
        {
            string sql = @"INSERT INTO Cliente ( Nome, CPF, TipoClienteId, Sexo, SituacaoClienteId ) 
                 VALUES ( @nome, @cpf, @tipoClienteId, @sexo, @situacaoClienteId ) ";
            
            var param = new DynamicParameters();
            param.Add("nome", cliente.Nome);
            param.Add("cpf", cliente.CPF);
            param.Add("tipoClienteId", cliente.TipoClienteId);
            param.Add("sexo", cliente.Sexo);
            param.Add("situacaoClienteId", cliente.SituacaoClienteId);
            

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Update(int id, Cliente cliente)
        {
            string sql = "UPDATE Cliente set Nome = @nome, TipoClienteId = @tipoClienteId, Sexo = @sexo, SituacaoClienteId = @situacaoClienteId  WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("nome", cliente.Nome);
            param.Add("tipoClienteId", cliente.TipoClienteId);
            param.Add("sexo", cliente.Sexo);
            param.Add("situacaoClienteId", cliente.SituacaoClienteId);
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM Cliente WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);

        }
    }

}
