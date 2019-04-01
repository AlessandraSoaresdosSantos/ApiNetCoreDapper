using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCoreDapper 
{
    public class FuncionarioRepositorio : SqlRepository<Funcionario>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(string connectionString) : base(connectionString) { }

        public override async void DeleteAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "DELETE FROM Funcionario WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                await conn.QueryFirstOrDefaultAsync<Funcionario>(sql, parameters);
            }
        }

        public override async Task<IEnumerable<Funcionario>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Funcionario";
                return await conn.QueryAsync<Funcionario>(sql);
            }
        }

        public override async Task<Funcionario> GetAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Funcionario WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, System.Data.DbType.Int32);
                return await conn.QueryFirstOrDefaultAsync<Funcionario>(sql, parameters);
            }
        }

        public override async void InsertAsync(Funcionario entity)
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "INSERT INTO Funcionario(Nome,CPF,RG,Telefone,EnderecoId,DepartamentoId)  VALUES(@nome, @cpf, @rg, @telefone, @enderecoId, @departamentoId)";

                var parameters = new DynamicParameters();
                parameters.Add("@nome", entity.Nome, System.Data.DbType.String);
                parameters.Add("@cpf", entity.CPF, System.Data.DbType.String);
                parameters.Add("@rg", entity.RG, System.Data.DbType.String);
                parameters.Add("@telefone", entity.Telefone, System.Data.DbType.String);
                parameters.Add("@enderecoId", entity.EnderecoId, System.Data.DbType.String);
                parameters.Add("@departamentoId", entity.DepartamentoId, System.Data.DbType.String);

                await conn.QueryAsync(sql, parameters);
            }
        }

        public override async void UpdateAsync(Funcionario entityToUpdate)
        {
            using (var conn = GetOpenConnection())
            {
                var existingEntity = await GetAsync(entityToUpdate.Id);

                var sql = "UPDATE Funcionario SET Nome = @nome, CPF = @cpf, RG = @rg, Telefone = @telefone, EnderecoId = @enderecoId, DepartamentoId = @departamentoId  WHERE Id=@Id ";

                var parameters = new DynamicParameters();
                parameters.Add("@nome", entityToUpdate.Nome, System.Data.DbType.String);
                parameters.Add("@cpf", entityToUpdate.CPF, System.Data.DbType.String);
                parameters.Add("@rg", entityToUpdate.RG, System.Data.DbType.String);
                parameters.Add("@telefone", entityToUpdate.Telefone, System.Data.DbType.String);
                parameters.Add("@enderecoId", entityToUpdate.EnderecoId, System.Data.DbType.String);
                parameters.Add("@departamentoId", entityToUpdate.DepartamentoId, System.Data.DbType.String);
                parameters.Add("@Id", entityToUpdate.Id, DbType.Int32);

                await conn.QueryAsync(sql, parameters);
            }
        }
    }
}

