using ApiNetCoreDapper.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCoreDapper 
{
    /// <summary>
    /// The concrete implementation of a SQL repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class SqlRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private string _connectionString;
        private EDbConnectionTypes _dbType;

        public SqlRepository(string connectionString)
        {
            _dbType = EDbConnectionTypes.Sql;
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            return DbConnectionFactory.GetDbConnection(_dbType, _connectionString);
        }

        public abstract void DeleteAsync(int id);
        public abstract Task<IEnumerable<TEntity>> GetAllAsync();
        public abstract Task<TEntity> GetAsync(int id);
        public abstract void InsertAsync(TEntity entity);
        public abstract void UpdateAsync(TEntity entityToUpdate);
    }
}
