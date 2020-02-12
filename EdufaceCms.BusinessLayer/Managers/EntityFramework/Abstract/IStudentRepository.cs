using EdufaceCms.DataAccessLayer.Abstract;
using EdufaceCms.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract
{
    public interface IStudentRepository : IGenericRepository<StudentEntity>
    {
        Task<List<StudentEntity>> GetIncludedStudentListAsync();
        IQueryable<StudentEntity> GetIncludedQueryableStudentListAsync();
    }
}
