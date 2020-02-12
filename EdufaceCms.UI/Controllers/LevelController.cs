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
    public class LevelController : BaseController
    {
        private readonly ILevelRepository _levelRepository;
        private readonly UserManager<UserEntity> _userManager;

        public LevelController(ILevelRepository levelRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _levelRepository = levelRepository;
            PageSubTitle = "Seviyeler";
        }


        // GET: Level
        public async Task<IActionResult> Index()
        {
            return View(await _levelRepository.GetListAsync());
        }

        // GET: Level/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelEntity = await _levelRepository
                .GetAsync(m => m.Id == id);
            if (levelEntity == null)
            {
                return NotFound();
            }

            return View(levelEntity);
        }

        // GET: Level/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Level/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] LevelEntity levelEntity)
        {
            if (ModelState.IsValid)
            {
                await _levelRepository.AddAsync(levelEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(levelEntity);
        }

        // GET: Level/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelEntity = await _levelRepository.GetAsync(x=>x.Id==id);
            if (levelEntity == null)
            {
                return NotFound();
            }
            return View(levelEntity);
        }

        // POST: Level/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsActive,CreDate")] LevelEntity levelEntity)
        {
            if (id != levelEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _levelRepository.UpdateAsync(levelEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelEntityExists(levelEntity.Id))
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
            return View(levelEntity);
        }

        // GET: Level/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelEntity = await _levelRepository
                .GetAsync(m => m.Id == id);
            if (levelEntity == null)
            {
                return NotFound();
            }

            return View(levelEntity);
        }

        // POST: Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var levelEntity = await _levelRepository.GetAsync(x=>x.Id==id);
            await _levelRepository.DeleteAsync(levelEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool LevelEntityExists(int id)
        {
            return _levelRepository.IsAny(e => e.Id == id);
        }
    }
}
