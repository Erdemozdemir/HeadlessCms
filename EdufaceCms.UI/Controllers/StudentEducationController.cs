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
    public class StudentEducationController : StudentBaseController
    {
        private readonly IStudentEducationRepository _studentEducationRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly UserManager<UserEntity> _userManager;
        public static int StudentId { get; set; }

        public StudentEducationController(IStudentEducationRepository studentEducationRepository, IStudentRepository studentRepository, UserManager<UserEntity> userManager) : base(studentRepository, userManager)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
            _studentEducationRepository = studentEducationRepository;
            PageSubTitle = "Öğrenci Eğitimleri";
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            StudentID = StudentId;
            base.OnActionExecuted(context);
        }

        public ActionResult GoToIndex()
        {
            return RedirectToAction("Index", new { id = TempData["StudentID"] });
        }
        
        // GET: StudentEducation
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                return BadRequest();

            StudentId = TempData["StudentID"]==null?id.ToInt(): TempData["StudentID"].ToInt();

            return View(await _studentEducationRepository.GetStudentEducationsAsync(StudentId));
        }

        // GET: StudentEducation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalHour,ListPrice,SavePrice,Id,EducationId,LevelId,TimeId")] StudentEducationEntity studentEducationEntity)
        {
            if (ModelState.IsValid)
            {
                studentEducationEntity.StudentId = StudentId;
                await _studentEducationRepository.AddAsync(studentEducationEntity);
                return RedirectToAction(nameof(Index), new { id = StudentId });
            }
            return View(studentEducationEntity);
        }

        // GET: StudentEducation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEducationEntity = await _studentEducationRepository.GetAsync(x => x.Id == id);
            if (studentEducationEntity == null)
            {
                return NotFound();
            }
            return View(studentEducationEntity);
        }

        // POST: StudentEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TotalHour,ListPrice,SavePrice,Id,IsActive,EducationId,LevelId,TimeId,CreDate")] StudentEducationEntity studentEducationEntity)
        {
            if (id != studentEducationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                studentEducationEntity.StudentId = StudentId;
                try
                {
                    await _studentEducationRepository.UpdateAsync(studentEducationEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentEducationEntityExists(studentEducationEntity.Id))
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
            return View(studentEducationEntity);
        }

        // GET: StudentEducation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEducationEntity = await _studentEducationRepository
                .GetAsync(m => m.Id == id);
            if (studentEducationEntity == null)
            {
                return NotFound();
            }

            return View(studentEducationEntity);
        }

        // POST: StudentEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentEducationEntity = await _studentEducationRepository.GetAsync(x => x.Id == id);
            await _studentEducationRepository.DeleteAsync(studentEducationEntity);
            return RedirectToAction(nameof(Index), new { id = StudentId });
        }

        private bool StudentEducationEntityExists(int id)
        {
            return _studentEducationRepository.IsAny(e => e.Id == id);
        }
    }
}
