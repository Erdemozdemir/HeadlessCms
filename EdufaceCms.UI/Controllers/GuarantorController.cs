using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.WebApplication.Helpers;
using Microsoft.AspNetCore.Identity;
using EdufaceCms.UI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;

namespace EdufaceCms.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GuarantorController : StudentBaseController
    {
        private readonly IGuarantorRepository _guarantorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly UserManager<UserEntity> _userManager;

        public static int StudentId { get; set; }

        public GuarantorController(IGuarantorRepository guarantorRepository, IStudentRepository studentRepository, UserManager<UserEntity> userManager) : base(studentRepository,userManager)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
            _guarantorRepository = guarantorRepository;
            PageSubTitle = "Öğrencinin Kefilleri";
        }

        // GET: Guarantor
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                return BadRequest();

            StudentId = id.ToInt();

            return View(await _guarantorRepository.GetListAsync());
        }

        // GET: Guarantor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guarantor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TC,Name,Surname,Address,CellPhone,Proximity,Id,CityId,CountyId,CreDate")] GuarantorEntity guarantorEntity)
        {
            if (ModelState.IsValid)
            {
                guarantorEntity.StudentId = StudentId;

                await _guarantorRepository.AddAsync(guarantorEntity);
                return RedirectToAction(nameof(Index),new { id=StudentId});
            }
            return View(guarantorEntity);
        }

        // GET: Guarantor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guarantorEntity = await _guarantorRepository.GetAsync(x=>x.Id==id);
            if (guarantorEntity == null)
            {
                return NotFound();
            }
            return View(guarantorEntity);
        }

        // POST: Guarantor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TC,Name,Surname,Address,CellPhone,Proximity,Id,IsActive,CityId,CountyId")] GuarantorEntity guarantorEntity)
        {
            if (id != guarantorEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                guarantorEntity.StudentId = StudentId;
                try
                {
                    await _guarantorRepository.UpdateAsync(guarantorEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuarantorEntityExists(guarantorEntity.Id))
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
            return View(guarantorEntity);
        }

        // GET: Guarantor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guarantorEntity = await _guarantorRepository
                .GetAsync(m => m.Id == id);
            if (guarantorEntity == null)
            {
                return NotFound();
            }

            return View(guarantorEntity);
        }

        // POST: Guarantor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guarantorEntity = await _guarantorRepository.GetAsync(x=>x.Id==id);
            await _guarantorRepository.DeleteAsync(guarantorEntity);
            return RedirectToAction(nameof(Index), new { id = StudentId });
        }

        private bool GuarantorEntityExists(int id)
        {
            return _guarantorRepository.IsAny(e => e.Id == id);
        }
    }
}
