using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using EdufaceCms.BusinessLayer.Managers.EntityFramework;
using EdufaceCms.WebApplication.Helpers;
using System;

namespace EdufaceCms.UI.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        private readonly IStudentRepository _studentRepository;
        private readonly UserManager<UserEntity> _userManager;

        public StudentController(IStudentRepository studentRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
            PageSubTitle = "Öğrenciler";
        }

        // GET: StudentEntities
        public async Task<IActionResult> Index(int? pageNumber, int? pageSize)
        {
            var query = _studentRepository.GetIncludedQueryableStudentListAsync();
            pageSize = pageSize ?? 3;
            pageNumber=pageNumber ?? 1;

            ViewData["PageIndex"] = pageNumber;
            ViewData["HasPreviousPage"] = pageNumber>1;
            ViewData["HasNextPage"] =pageNumber< (int)Math.Ceiling((await query.CountAsync()) / (double)pageSize);
            
            return View(await new GenericPagingRepository<StudentEntity>().GetPagedEntity(query, pageNumber.ToInt(), pageSize));
        }

        // GET: StudentEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEntity = await _studentRepository
                .GetAsync(m => m.Id == id);
            if (studentEntity == null)
            {
                return NotFound();
            }

            return View(studentEntity);
        }

        // GET: StudentEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //[Bind("TC,Name,Surname,Gender,Address,CellPhone,Phone,Email,EmergencyPerson,Proximity,Neighborhood,Reference,CityId,CountyId,BranchId")]
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentEntity studentEntity)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.AddAsync(studentEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(studentEntity);
        }

        // GET: StudentEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEntity = await _studentRepository.GetAsync(x => x.Id == id);
            if (studentEntity == null)
            {
                return NotFound();
            }
            return View(studentEntity);
        }

        // POST: StudentEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentEntity studentEntity)
        {
            if (id != studentEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _studentRepository.UpdateAsync(studentEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentEntityExists(studentEntity.Id))
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
            return View(studentEntity);
        }

        // GET: StudentEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEntity = await _studentRepository
                .GetAsync(m => m.Id == id);
            if (studentEntity == null)
            {
                return NotFound();
            }

            return View(studentEntity);
        }

        // POST: StudentEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentEntity = await _studentRepository.GetAsync(x => x.Id == id);
            await _studentRepository.DeleteAsync(studentEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentEntityExists(int id)
        {
            return _studentRepository.IsAny(e => e.Id == id);
        }
    }
}
