using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCoreDapper 
{
    public class EnderecoRepositorio : SqlRepository<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(string connectionString) : base(connectionString) { }

        public override async void DeleteAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "DELETE FROM Endereco WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                await conn.QueryFirstOrDefaultAsync<Endereco>(sql, parameters);
            }
        }

        public override async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Endereco";
                return await conn.QueryAsync<Endereco>(sql);
            }
        }

        public override async Task<Endereco> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Endereco WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<Endereco>(sql, parameters);
            }
        }

        public override async void InsertAsync(Endereco entity)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "INSERT INTO Endereco(Logradouro ,Numero ,Complemento , Bairro, Cidade ,Estado ,FuncionarioId)  VALUES(@logradouro ,@numero ,@complemento , @bairro, @cidade ,@estado ,@funcionarioId)";

                var parameters = new DynamicParameters();
                parameters.Add("@logradouro", entity.Logradouro, System.Data.DbType.String);
                parameters.Add("@numero", entity.Logradouro, System.Data.DbType.String);
                parameters.Add("@complemento", entity.Logradouro, System.Data.DbType.String);
                parameters.Add("@bairro", entity.Logradouro, System.Data.DbType.String);
                parameters.Add("@cidade", entity.Logradouro, System.Data.DbType.String);
                parameters.Add("@estado", entity.Logradouro, System.Data.DbType.String);
                parameters.Add("@funcionarioId", entity.FuncionarioId, System.Data.DbType.Int32);

                await conn.QueryAsync(sql, parameters);
            }
        }

        public override async void UpdateAsync(Endereco entityToUpdate)
        {
            using (var conn = GetOpenConnection())
            {
                var existingEntity = await GetAsync(entityToUpdate.Id);

                var sql = "UPDATE Endereco SET Logradouro = @logradouro , Numero = @numero ,Complemento = @complemento , Bairro = @bairro, Cidade = @cidade ,Estado = @estado ,FuncionarioId = @funcionarioId  WHERE Id=@Id ";

                var parameters = new DynamicParameters();
                parameters.Add("@logradouro", entityToUpdate.Logradouro, System.Data.DbType.String);
                parameters.Add("@numero", entityToUpdate.Logradouro, System.Data.DbType.String);
                parameters.Add("@complemento", entityToUpdate.Logradouro, System.Data.DbType.String);
                parameters.Add("@bairro", entityToUpdate.Logradouro, System.Data.DbType.String);
                parameters.Add("@cidade", entityToUpdate.Logradouro, System.Data.DbType.String);
                parameters.Add("@estado", entityToUpdate.Logradouro, System.Data.DbType.String);
                parameters.Add("@funcionarioId", entityToUpdate.FuncionarioId, System.Data.DbType.Int32);
                parameters.Add("@Id", entityToUpdate.Id, DbType.Int32);

                await conn.QueryAsync(sql, parameters);
            }
        }
    }
}
