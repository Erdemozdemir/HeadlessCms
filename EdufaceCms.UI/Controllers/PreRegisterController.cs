using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.WebApplication.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EdufaceCms.UI.Controllers
{
    [Authorize]
    public class PreRegisterController : BaseController
    {
        private readonly IPreRegisterRepository _preRegisterRepository;
        private readonly UserManager<UserEntity> _userManager;

        public PreRegisterController(IPreRegisterRepository preRegisterRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _preRegisterRepository = preRegisterRepository;
            PageSubTitle = "Ön Kayıt";
        }

        // GET: PreRegister
        public async Task<IActionResult> Index()
        {
            var entities = await _preRegisterRepository.GetIncludedPreRegisterEntities();
            return View(entities);
        }

        // GET: PreRegister/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preRegisterEntity = await _preRegisterRepository.GetIncludedPreRegisterEntity(id.ToInt());
            if (preRegisterEntity == null)
            {
                return NotFound();
            }

            return View(preRegisterEntity);
        }

        // GET: PreRegister/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PreRegister/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,InterviewPerson,InterviewDate,CellPhone,Email,AppointmentDate,GivenPrice,EstimatedPrice,Not,IsRegister,DataQualityId,DataSourceId,LevelId,TimeId,PaymentTypeId,Id,IsActive")] PreRegisterEntity preRegisterEntity)
        {
            if (ModelState.IsValid)
            {
                await _preRegisterRepository.AddAsync(preRegisterEntity);
                return RedirectToAction(nameof(Index));
            }

            return View(preRegisterEntity);
        }

        // GET: PreRegister/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preRegisterEntity = await _preRegisterRepository.GetAsync(x => x.Id == id);
            if (preRegisterEntity == null)
            {
                return NotFound();
            }

            return View(preRegisterEntity);
        }

        // POST: PreRegister/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,InterviewPerson,InterviewDate,CellPhone,Email,AppointmentDate,GivenPrice,EstimatedPrice,Not,IsRegister,DataQualityId,DataSourceId,LevelId,TimeId,PaymentTypeId,Id,IsActive,CreDate")] PreRegisterEntity preRegisterEntity)
        {
            if (id != preRegisterEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _preRegisterRepository.UpdateAsync(preRegisterEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreRegisterEntityExists(preRegisterEntity.Id))
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

            return View(preRegisterEntity);
        }

        // GET: PreRegister/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preRegisterEntity = await _preRegisterRepository.GetIncludedPreRegisterEntity(id.ToInt());
            if (preRegisterEntity == null)
            {
                return NotFound();
            }

            return View(preRegisterEntity);
        }

        // POST: PreRegister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preRegisterEntity = await _preRegisterRepository.GetAsync(x => x.Id == id);
            await _preRegisterRepository.DeleteAsync(preRegisterEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool PreRegisterEntityExists(int id)
        {
            return _preRegisterRepository.IsAny(e => e.Id == id);
        }
    }
}
