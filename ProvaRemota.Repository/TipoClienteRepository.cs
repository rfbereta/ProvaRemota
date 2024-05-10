using Dapper;
using ProvaRemota.Domain.Entity;
using ProvaRemota.Domain.Interfaces;
using System.Data;

namespace ProvaRemota.Repository
{

    public class TipoClienteRepository : ITipoClienteRepository
    {
        private readonly IDbConnection _dbConnection;

        public TipoClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
          
        }

        public async Task<TipoCliente> GetById(int id)
        {
            string sql = "SELECT Id, Descricao FROM TipoCliente" +
                " WHERE Id = @id";

            var param = new DynamicParameters();
            param.Add("id", id);

            var TipoClientes = await _dbConnection.QueryFirstOrDefaultAsync<TipoCliente>(sql, param);

            return TipoClientes;
             
        }

        public async Task<IEnumerable<TipoCliente>> GetAll()
        {
            string sql = "SELECT Id, Descricao FROM TipoCliente";

            return await _dbConnection.QueryAsync<TipoCliente>(sql);
        }

        public async Task Insert(TipoCliente tipoCliente)
        {
            string sql = "INSERT INTO TipoCliente ( Descricao ) " +
                " VALUES ( @descricao ) ";
            
            var param = new DynamicParameters();
            param.Add("descricao", tipoCliente.Descricao);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Update(int id, TipoCliente tipoCliente)
        {
            string sql = "UPDATE TipoCliente set Descricao = @descricao WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("descricao", tipoCliente.Descricao);
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM TipoCliente WHERE Id = @id ";

            var param = new DynamicParameters();
            param.Add("id", id);

            await _dbConnection.ExecuteAsync(sql, param);

        }
    }

}
