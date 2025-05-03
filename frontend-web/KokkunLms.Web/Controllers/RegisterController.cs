using Microsoft.AspNetCore.Mvc;

namespace KokkunLms.Web.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(
            string ParentUsername,
            string ParentFullName,
            string ParentEmail,
            string ParentPhoneNumber,
            string ParentPassword,
            string ParentConfirmPassword,
            string StudentUsername,
            string StudentFullName,
            string StudentEmail,
            string StudentPhoneNumber)
        {
            if (ParentPassword != ParentConfirmPassword)
            {
                ViewBag.Error = "Parent passwords do not match.";
                return View();
            }

            // TODO: Save or send data to API

            return RedirectToAction("Index", "Home");
        }
    }
}
