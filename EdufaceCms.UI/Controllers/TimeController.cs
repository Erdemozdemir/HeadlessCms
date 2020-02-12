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
    public class TimeController : BaseController
    {
        private readonly ITimeRepository _timeRepository;
        private readonly UserManager<UserEntity> _userManager;

        public TimeController(ITimeRepository timeRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _timeRepository = timeRepository;
            PageSubTitle = "Ders Saatleri";
        }

        // GET: Time
        public async Task<IActionResult> Index()
        {
            return View(await _timeRepository.GetListAsync());
        }

        // GET: Time/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeEntity = await _timeRepository
                .GetAsync(m => m.Id == id);
            if (timeEntity == null)
            {
                return NotFound();
            }

            return View(timeEntity);
        }

        // GET: Time/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Time/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] TimeEntity timeEntity)
        {
            if (ModelState.IsValid)
            {
                await _timeRepository.AddAsync(timeEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(timeEntity);
        }

        // GET: Time/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeEntity = await _timeRepository.GetAsync(x=>x.Id==id);
            if (timeEntity == null)
            {
                return NotFound();
            }
            return View(timeEntity);
        }

        // POST: Time/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsActive,CreDate")] TimeEntity timeEntity)
        {
            if (id != timeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _timeRepository.UpdateAsync(timeEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeEntityExists(timeEntity.Id))
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
            return View(timeEntity);
        }

        // GET: Time/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeEntity = await _timeRepository
                .GetAsync(m => m.Id == id);
            if (timeEntity == null)
            {
                return NotFound();
            }

            return View(timeEntity);
        }

        // POST: Time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeEntity = await _timeRepository.GetAsync(x=>x.Id==id);
            await _timeRepository.DeleteAsync(timeEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool TimeEntityExists(int id)
        {
            return _timeRepository.IsAny(e => e.Id == id);
        }
    }
}
