using Microsoft.AspNetCore.Mvc;

namespace Pizza.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
