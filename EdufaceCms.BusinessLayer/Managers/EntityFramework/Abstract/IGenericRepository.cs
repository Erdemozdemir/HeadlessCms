using EdufaceCms.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EdufaceCms.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T: EntityBase, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        bool IsAny(Expression<Func<T, bool>> filter = null);

    }
}
