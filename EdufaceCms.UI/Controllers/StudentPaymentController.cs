using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.WebApplication.Helpers;
using Microsoft.AspNetCore.Identity;
using EdufaceCms.UI.Controllers.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

namespace EdufaceCms.UI.Controllers
{
    [Authorize]
    public class StudentPaymentController : StudentBaseController
    {
        private readonly IStudentPaymentRepository _studentPaymentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly UserManager<UserEntity> _userManager;
        public static int StudentId { get; set; }

        public StudentPaymentController(IStudentRepository studentRepository,IStudentPaymentRepository studentPaymentRepository,UserManager<UserEntity> userManager):base(studentRepository,userManager)
        {
            _userManager = userManager;
            _studentPaymentRepository = studentPaymentRepository;
            _studentRepository = studentRepository;
            PageSubTitle = "Öğrenci Ödemeleri";
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            StudentID = StudentId;
            base.OnActionExecuted(context);
        }

        // GET: StudentPayment
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                return BadRequest();

            StudentId = TempData["StudentID"] == null ? id.ToInt() : TempData["StudentID"].ToInt();

            return View(await _studentPaymentRepository.GetStudentPaymentsAsync(StudentId));
        }
        
        // GET: StudentPayment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentPayment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdvancePaymentDate,FirstPaymentDate,InstallementCount,AdvancePaymentPrice,Id,PaymentTypeId,CreDate")] StudentPaymentEntity studentPaymentEntity)
        {
            if (ModelState.IsValid)
            {
                studentPaymentEntity.StudentId = StudentId;
                await _studentPaymentRepository.AddAsync(studentPaymentEntity);
                return RedirectToAction(nameof(Index),new { id= StudentId });
            }
            return View(studentPaymentEntity);
        }

        // GET: StudentPayment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPaymentEntity = await _studentPaymentRepository.GetAsync(x=>x.Id==id);
            if (studentPaymentEntity == null)
            {
                return NotFound();
            }
            return View(studentPaymentEntity);
        }

        // POST: StudentPayment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdvancePaymentDate,FirstPaymentDate,InstallementCount,AdvancePaymentPrice,Id,IsActive,PaymentTypeId")] StudentPaymentEntity studentPaymentEntity)
        {
            if (id != studentPaymentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                studentPaymentEntity.StudentId = StudentId;
                try
                {
                    await _studentPaymentRepository.UpdateAsync(studentPaymentEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPaymentEntityExists(studentPaymentEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = StudentId });
            }
            return View(studentPaymentEntity);
        }

        // GET: StudentPayment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPaymentEntity = await _studentPaymentRepository
                .GetAsync(m => m.Id == id);
            if (studentPaymentEntity == null)
            {
                return NotFound();
            }

            return View(studentPaymentEntity);
        }

        // POST: StudentPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentPaymentEntity = await _studentPaymentRepository.GetAsync(x => x.Id == id);
            await _studentPaymentRepository.DeleteAsync(studentPaymentEntity);
            return RedirectToAction(nameof(Index), new { id = StudentId });
        }

        private bool StudentPaymentEntityExists(int id)
        {
            return _studentPaymentRepository.IsAny(e => e.Id == id);
        }
    }
}
