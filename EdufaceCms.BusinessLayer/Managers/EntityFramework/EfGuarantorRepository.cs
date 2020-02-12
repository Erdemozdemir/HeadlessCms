using EdufaceCms.BusinessLayer.Managers.EntityFramework;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.Entities.Concrete;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework
{
    public class EfGuarantorRepository : EfGenericRepository<GuarantorEntity>, IGuarantorRepository
    {
    }
}
