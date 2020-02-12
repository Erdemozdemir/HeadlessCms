using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdufaceCms.UI.Controllers.Base
{
    public class StudentBaseController : BaseController
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IStudentRepository _studentRepository;
        protected int StudentID { get; set; }

        public StudentBaseController(IStudentRepository studentRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var student = _studentRepository.Get(x => x.Id == StudentID);
            if (student != null)
            {
                ViewData["StudentName"] = string.Format("{0} {1}", student.Name, student.Surname);
                TempData["StudentID"] = StudentID;
            }
            base.OnActionExecuted(context);
        }
    }
}
