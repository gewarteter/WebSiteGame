using Microsoft.AspNetCore.Mvc;

namespace MvcGame.Controllers
{
    public class LevelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
