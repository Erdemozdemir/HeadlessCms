using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdufaceCms.UI.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IStudentPaymentRepository _studentPaymentRepository;
        private readonly UserManager<UserEntity> _userManager;

        public ReportController(IStudentRepository studentRepository, IStudentPaymentRepository studentPaymentRepository, UserManager<UserEntity> userManager) : base(userManager)
        {
            _userManager = userManager;
            _studentPaymentRepository = studentPaymentRepository;
            PageSubTitle = "Raporlar";
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            //var payments = _studentPaymentRepository.GetList(x => x.IsActive == true);

            //List<object> chartData = new List<object>();
            //chartData.Add(new object[] {  "Price", "Date" });

            //List<ReportModel> reportModels = new List<ReportModel>();

            //foreach (var payment in payments)
            //{
            //    reportModels.Add(new ReportModel
            //    {
            //        date = payment.CreDate.ToString(),
            //        price = payment.AdvancePaymentPrice,
            //    });
            //}

            //foreach (var item in reportModels)
            //{
            //    chartData.Add(new object[] { item.price,item.date  });
            //}

            //return Json(chartData);
            return null;
        }
    }
}