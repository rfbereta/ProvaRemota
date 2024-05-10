using Dapper;
using ProvaRemota.Domain.Entity;
using System.Data;
using ProvaRemota.Domain.Interfaces;

namespace ProvaRemota.Repository
{

    public class SituacaoClienteRepository : ISituacaoClienteRepository
    {
        private readonly IDbConnection _dbConnection;

        public SituacaoClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
          
        }

        public async Task<SituacaoCliente> GetById(int id)
        {
            string sql = "SELECT Id, Descricao FROM SituacaoCliente" +
                " WHERE Id = @id";

            var param = new DynamicParameters();
            param.Add("id", id);

            var situacaoCliente = await _dbConnection.QueryFirstOrDefaultAsync<SituacaoCliente>(sql, param);

            return situacaoCliente;
             
        }

        public async Task<IEnumerable<SituacaoCliente>> GetAll()
        {
            string sql = "SELECT Id, Descricao FROM SituacaoCliente";

            return await _dbConnection.QueryAsync<SituacaoCliente>(sql);
        }

        public async Task Insert(SituacaoCliente situacaoCliente)
        {
            string sql = "INSERT INTO SituacaoCliente ( Descricao ) " +
                " VALUES ( @descricao ) ";
            
            var param = new DynamicParameters();
            param.Add("descricao", situacaoCliente.Descricao);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Update(int id, SituacaoCliente situacaoCliente)
        {
            string sql = "UPDATE SituacaoCliente set Descricao = @descricao WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("descricao", situacaoCliente.Descricao);
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM SituacaoCliente WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);

        }
    }

}
