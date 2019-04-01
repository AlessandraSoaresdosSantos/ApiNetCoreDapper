using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCoreDapper 
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        void InsertAsync(TEntity entity);
        void DeleteAsync(int id);
        void UpdateAsync(TEntity entityToUpdate);
    }
}
