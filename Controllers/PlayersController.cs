using Microsoft.AspNetCore.Mvc;

namespace MvcGame.Controllers
{
    public class PlayersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
