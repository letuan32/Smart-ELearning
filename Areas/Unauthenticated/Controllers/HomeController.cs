using Microsoft.AspNetCore.Mvc;

namespace Smart_ELearning.Areas.Unauthenticated.Controllers
{
    [Area("Unauthenticated")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}