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
    public class DataQualityController : BaseController
    {
        private readonly IDataQualityRepository _dataQualityRepo;
        private readonly UserManager<UserEntity> _userManager;

        public DataQualityController(IDataQualityRepository dataQualityRepo, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _dataQualityRepo = dataQualityRepo;
            PageSubTitle = "Data Kalitesi";
        }

        // GET: BranchEntities
        public async Task<IActionResult> Index()
        {
            return View(await _dataQualityRepo.GetListAsync());
        }

        // GET: BranchEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataQualityEntity = await _dataQualityRepo
                .GetAsync(m => m.Id == id);
            if (dataQualityEntity == null)
            {
                return NotFound();
            }

            return View(dataQualityEntity);
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
        public async Task<IActionResult> Create([Bind("Name,Id,IsActive,CreDate")] DataQualityEntity dataQualityEntity)
        {
            if (ModelState.IsValid)
            {
                await _dataQualityRepo.AddAsync(dataQualityEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(dataQualityEntity);
        }

        // GET: BranchEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataQualityEntity = await _dataQualityRepo.GetAsync(x=>x.Id==id);
            if (dataQualityEntity == null)
            {
                return NotFound();
            }
            return View(dataQualityEntity);
        }

        // POST: BranchEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsActive")] DataQualityEntity dataQualityEntity)
        {
            if (id != dataQualityEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _dataQualityRepo.UpdateAsync(dataQualityEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dataQualityEntityExists(dataQualityEntity.Id))
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
            return View(dataQualityEntity);
        }

        // GET: BranchEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataQualityEntity = await _dataQualityRepo
                .GetAsync(m => m.Id == id);
            if (dataQualityEntity == null)
            {
                return NotFound();
            }

            return View(dataQualityEntity);
        }

        // POST: BranchEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataQualityEntity = await _dataQualityRepo.GetAsync(x=>x.Id==id);

            await _dataQualityRepo.DeleteAsync(dataQualityEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool dataQualityEntityExists(int id)
        {
            return _dataQualityRepo.IsAny(x=>x.Id==id);
        }
    }
}
