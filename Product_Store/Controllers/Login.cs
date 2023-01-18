using Microsoft.AspNetCore.Mvc;

namespace Product_Store.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
