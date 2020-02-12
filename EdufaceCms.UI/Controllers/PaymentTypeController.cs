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
    public class PaymentTypeController : BaseController
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly UserManager<UserEntity> _userManager;

        public PaymentTypeController(IPaymentTypeRepository paymentTypeRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _paymentTypeRepository = paymentTypeRepository;
            PageSubTitle = "Ödeme Türleri";
        }

        // GET: PaymentType
        public async Task<IActionResult> Index()
        {
            return View(await _paymentTypeRepository.GetListAsync());
        }

        // GET: PaymentType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentTypeEntity = await _paymentTypeRepository.GetAsync(m => m.Id == id);
            if (paymentTypeEntity == null)
            {
                return NotFound();
            }

            return View(paymentTypeEntity);
        }

        // GET: PaymentType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] PaymentTypeEntity paymentTypeEntity)
        {
            if (ModelState.IsValid)
            {
                await _paymentTypeRepository.AddAsync(paymentTypeEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentTypeEntity);
        }

        // GET: PaymentType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentTypeEntity = await _paymentTypeRepository.GetAsync(x=>x.Id==id);
            if (paymentTypeEntity == null)
            {
                return NotFound();
            }
            return View(paymentTypeEntity);
        }

        // POST: PaymentType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsActive,CreDate")] PaymentTypeEntity paymentTypeEntity)
        {
            if (id != paymentTypeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _paymentTypeRepository.UpdateAsync(paymentTypeEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentTypeEntityExists(paymentTypeEntity.Id))
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
            return View(paymentTypeEntity);
        }

        // GET: PaymentType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentTypeEntity = await _paymentTypeRepository
                .GetAsync(m => m.Id == id);
            if (paymentTypeEntity == null)
            {
                return NotFound();
            }

            return View(paymentTypeEntity);
        }

        // POST: PaymentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentTypeEntity = await _paymentTypeRepository.GetAsync(x=>x.Id==id);
            await _paymentTypeRepository.DeleteAsync(paymentTypeEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentTypeEntityExists(int id)
        {
            return _paymentTypeRepository.IsAny(e => e.Id == id);
        }
    }
}
