using System.Collections.Generic;
using System.Threading.Tasks;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework
{
    public class EfPreRegisterRepository : EfGenericRepository<PreRegisterEntity>, IPreRegisterRepository
    {
        public Task<List<PreRegisterEntity>> GetIncludedPreRegisterEntities()
        {
           return _context.PreRegisterEntities.Include(p => p.DataQuality).Include(p => p.DataSource).Include(p => p.Level).Include(p => p.PaymentType).Include(p => p.Time).ToListAsync();
        }

        public Task<PreRegisterEntity> GetIncludedPreRegisterEntity(int id)
        {
            return _context.PreRegisterEntities.Include(p => p.DataQuality).Include(p => p.DataSource).Include(p => p.Level).Include(p => p.PaymentType).Include(p => p.Time).FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
