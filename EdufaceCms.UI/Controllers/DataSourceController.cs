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
    public class DataSourceController : BaseController
    {
        private readonly IDataSourceRepository _dataSourceRepo;
        private readonly UserManager<UserEntity> _userManager;

        public DataSourceController(IDataSourceRepository dataSourceRepo, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _dataSourceRepo = dataSourceRepo;
            PageSubTitle = "Data Kaynağı";
        }

        // GET: BranchEntities
        public async Task<IActionResult> Index()
        {
            return View(await _dataSourceRepo.GetListAsync());
        }

        // GET: BranchEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataSourceEntity = await _dataSourceRepo
                .GetAsync(m => m.Id == id);
            if (dataSourceEntity == null)
            {
                return NotFound();
            }

            return View(dataSourceEntity);
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
        public async Task<IActionResult> Create([Bind("Name,Id,IsActive,CreDate")] DataSourceEntity dataSourceEntity)
        {
            if (ModelState.IsValid)
            {
                await _dataSourceRepo.AddAsync(dataSourceEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(dataSourceEntity);
        }

        // GET: BranchEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataSourceEntity = await _dataSourceRepo.GetAsync(x=>x.Id==id);
            if (dataSourceEntity == null)
            {
                return NotFound();
            }
            return View(dataSourceEntity);
        }

        // POST: BranchEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsActive")] DataSourceEntity dataSourceEntity)
        {
            if (id != dataSourceEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _dataSourceRepo.UpdateAsync(dataSourceEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataSourceEntityExists(dataSourceEntity.Id))
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
            return View(dataSourceEntity);
        }

        // GET: BranchEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataSourceEntity = await _dataSourceRepo
                .GetAsync(m => m.Id == id);
            if (dataSourceEntity == null)
            {
                return NotFound();
            }

            return View(dataSourceEntity);
        }

        // POST: BranchEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataSourceEntity = await _dataSourceRepo.GetAsync(x=>x.Id==id);

            await _dataSourceRepo.DeleteAsync(dataSourceEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool DataSourceEntityExists(int id)
        {
            return _dataSourceRepo.IsAny(x=>x.Id==id);
        }
    }
}
