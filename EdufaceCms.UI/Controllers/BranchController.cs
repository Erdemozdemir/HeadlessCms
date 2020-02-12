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
    public class BranchController : BaseController
    {
        private readonly IBranchRepository _branchRepo;
        private readonly UserManager<UserEntity> _userManager;

        public BranchController(IBranchRepository branchRepo, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _branchRepo=branchRepo;
            PageSubTitle = "Şubeler";
        }

        // GET: BranchEntities
        public async Task<IActionResult> Index()
        {
            return View(await _branchRepo.GetListAsync());
        }

        // GET: BranchEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchEntity = await _branchRepo
                .GetAsync(m => m.Id == id);
            if (branchEntity == null)
            {
                return NotFound();
            }

            return View(branchEntity);
        }

        // GET: BranchEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BranchEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Address,Id,IsActive,CreDate")] BranchEntity branchEntity)
        {
            if (ModelState.IsValid)
            {
                await _branchRepo.AddAsync(branchEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(branchEntity);
        }

        // GET: BranchEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchEntity = await _branchRepo.GetAsync(x=>x.Id==id);
            if (branchEntity == null)
            {
                return NotFound();
            }
            return View(branchEntity);
        }

        // POST: BranchEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Phone,Address,Id,IsActive")] BranchEntity branchEntity)
        {
            if (id != branchEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _branchRepo.UpdateAsync(branchEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchEntityExists(branchEntity.Id))
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
            return View(branchEntity);
        }

        // GET: BranchEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchEntity = await _branchRepo
                .GetAsync(m => m.Id == id);
            if (branchEntity == null)
            {
                return NotFound();
            }

            return View(branchEntity);
        }

        // POST: BranchEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branchEntity = await _branchRepo.GetAsync(x=>x.Id==id);

            await _branchRepo.DeleteAsync(branchEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool BranchEntityExists(int id)
        {
            return _branchRepo.IsAny(x=>x.Id==id);
        }
    }
}
