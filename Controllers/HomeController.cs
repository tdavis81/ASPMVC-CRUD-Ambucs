using AmbucsProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AmbucsProject.Classes.UserMethods;

namespace AmbucsProject.Controllers
{
    public class HomeController : Controller
    {
        RecordsService recordsService = new RecordsService();

        [VerifyLogin]
        public ActionResult Index()
        {
            ViewBag.Records = recordsService.GetAllRecords();
            return View();
        }

        [VerifyLogin]
        [HttpPost]
        public ActionResult AddRecord(string first_name, string last_name, string birthdate, string gifted_date, string phone_number, string address, string city, string state, string zip)
        {
            recordsService.saveRecord(first_name, last_name, birthdate, gifted_date, phone_number, address, city, state, zip);

            return Json(new { success = true });
        }

        [VerifyLogin]
        [HttpPost]
        public ActionResult UpdateRecord(int recipient_id, string first_name, string last_name, string birthdate, string gifted_date, string phone_number, string address, string city, string state, string zip)
        {
            recordsService.updateRecord(recipient_id, first_name, last_name, birthdate, gifted_date, phone_number, address, city, state, zip);

            return Json(new { success = true });
        }

        [VerifyLogin]
        [HttpGet]
        public ActionResult DeleteRecord(int id)
        {
            recordsService.deleteRecord(id);

            return RedirectToAction("Index", "Home");
        }
    }
}