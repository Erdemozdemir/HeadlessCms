using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework
{
    public class EfStudentEducationRepository : EfGenericRepository<StudentEducationEntity>, IStudentEducationRepository
    {
        public Task<List<StudentEducationEntity>> GetStudentEducationsAsync(int id)
        {
            return _context.StudentEducations
                .Include(x => x.Student)
                .Include(x => x.Education)
                .Include(x => x.Level)
                .Include(x => x.Time)
                .Where(x => x.IsActive == true && x.Student.IsActive == true)
                .ToListAsync();
        }
    }
}
