using Microsoft.AspNetCore.Mvc;

namespace ResumePortofolio.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
