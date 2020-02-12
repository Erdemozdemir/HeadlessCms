using EdufaceCms.DataAccessLayer.Abstract;
using EdufaceCms.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract
{
    public interface IStudentEducationRepository : IGenericRepository<StudentEducationEntity>
    {
        Task<List<StudentEducationEntity>> GetStudentEducationsAsync(int id);
    }
}
