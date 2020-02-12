using EdufaceCms.DataAccessLayer;
using EdufaceCms.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework
{
    public class GenericPagingRepository<TEntity> where TEntity : EntityBase, new()
    {
        private DatabaseContext _context;

        public GenericPagingRepository() => _context = new DatabaseContext();

        public async Task<List<TEntity>> GetPagedEntity(IQueryable<TEntity> source, int pageIndex, int? pageSize)
        {
            //var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * (int)pageSize).Take((int)pageSize).ToListAsync();


            return items;
        }
    }
}
