using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework
{
    public class EfStudentRepository : EfGenericRepository<StudentEntity>, IStudentRepository
    {
        public IQueryable<StudentEntity> GetIncludedQueryableStudentListAsync()
        {
            return _context.Students
                .Include(x => x.Branch)
                .Include(x => x.City)
                .Include(x => x.County);
        }

        public Task<List<StudentEntity>> GetIncludedStudentListAsync()
        {
            return _context.Students
                .Include(x => x.Branch)
                .Include(x => x.City)
                .Include(x => x.County)
                .ToListAsync();
        }
    }
}
