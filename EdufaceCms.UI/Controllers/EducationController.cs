using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EdufaceCms.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EducationController : BaseController
    {
        private readonly IEducationRepository _educationRepository;
        private readonly UserManager<UserEntity> _userManager;

        public EducationController(IEducationRepository educationRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _educationRepository = educationRepository;
            PageSubTitle = "Eğitimler";
        }

        // GET: Education
        public async Task<IActionResult> Index()
        {
            return View(await _educationRepository.GetListAsync());
        }

        // GET: Education/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationEntity = await _educationRepository
                .GetAsync(m => m.Id == id);
            if (educationEntity == null)
            {
                return NotFound();
            }

            return View(educationEntity);
        }

        // GET: Education/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,IsActive,CreDate")] EducationEntity educationEntity)
        {
            if (ModelState.IsValid)
            {
                await _educationRepository.AddAsync(educationEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(educationEntity);
        }

        // GET: Education/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationEntity = await _educationRepository.GetAsync(x=>x.Id==id);
            if (educationEntity == null)
            {
                return NotFound();
            }
            return View(educationEntity);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsActive")] EducationEntity educationEntity)
        {
            if (id != educationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _educationRepository.UpdateAsync(educationEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationEntityExists(educationEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(educationEntity);
        }

        // GET: Education/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationEntity = await _educationRepository
                .GetAsync(m => m.Id == id);
            if (educationEntity == null)
            {
                return NotFound();
            }

            return View(educationEntity);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationEntity = await _educationRepository.GetAsync(m => m.Id == id);
            await _educationRepository.DeleteAsync(educationEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool EducationEntityExists(int id)
        {
            return _educationRepository.IsAny(e => e.Id == id);
        }
    }
}
