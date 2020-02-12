using EdufaceCms.DataAccessLayer.Abstract;
using EdufaceCms.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract
{
    public interface IPreRegisterRepository : IGenericRepository<PreRegisterEntity>
    {
        Task<List<PreRegisterEntity>> GetIncludedPreRegisterEntities();
        Task<PreRegisterEntity> GetIncludedPreRegisterEntity(int id);
    }
}
