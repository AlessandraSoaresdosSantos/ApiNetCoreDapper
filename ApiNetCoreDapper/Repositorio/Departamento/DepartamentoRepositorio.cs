using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ApiNetCoreDapper 
{
    public class DepartamentoRepositorio : SqlRepository<Departamento>, IDepartamentoRepositorio
    {
        public DepartamentoRepositorio(string connectionString) : base(connectionString) { }

        public override async void DeleteAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "DELETE FROM Departamento WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                await conn.QueryFirstOrDefaultAsync<Departamento>(sql, parameters);
            }
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Departamento";
                return await conn.QueryAsync<Departamento>(sql);
            }
        }

        public override async Task<Departamento> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Departamento WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<Departamento>(sql, parameters);
            }
        }

        public override async void InsertAsync(Departamento entity)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "INSERT INTO Departamento(Nome, FuncionarioId) VALUES(@name, @funcionarioId)";

                var parameters = new DynamicParameters();
                parameters.Add("@name", entity.Nome, System.Data.DbType.String);
                parameters.Add("@funcionarioId", entity.FuncionarioId, System.Data.DbType.Int32);

                await conn.QueryAsync(sql, parameters);
            }
        }

        public override async void UpdateAsync(Departamento entityToUpdate)
        {
            using (var conn = GetOpenConnection())
            {
                var existingEntity = await GetAsync(entityToUpdate.Id);

                var sql = "UPDATE Departamento SET Name = @Name, funcionarioId = @funcionarioId  WHERE Id=@Id ";

                var parameters = new DynamicParameters();
                parameters.Add("@name", entityToUpdate.Nome, System.Data.DbType.String);
                parameters.Add("@funcionarioId", entityToUpdate.FuncionarioId, System.Data.DbType.Int32);
                parameters.Add("@Id", entityToUpdate.Id, DbType.Int32);

                await conn.QueryAsync(sql, parameters);
            }
        }
    }
}
