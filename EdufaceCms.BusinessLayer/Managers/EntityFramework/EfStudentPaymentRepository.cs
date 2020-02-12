using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework
{
    public class EfStudentPaymentRepository : EfGenericRepository<StudentPaymentEntity>, IStudentPaymentRepository
    {
        public Task<List<StudentPaymentEntity>> GetStudentPaymentsAsync(int id)
        {
            return _context.StudentPayments
                 .Include(x => x.Student)
                 .Include(x=>x.PaymentType)
                 .Where(x => x.Student.IsActive==true & x.StudentId == id&x.IsActive==true)
                 .ToListAsync();
        }
    }
}
