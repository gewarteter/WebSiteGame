using Microsoft.AspNetCore.Mvc;

namespace MvcGame.Controllers
{
    public class CharactersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
