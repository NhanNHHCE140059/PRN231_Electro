using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectroMVC.Controllers
{
	//[Authorize]
	public class AdminController : Controller
    {
        public IActionResult Index()
        {
			var isLogin = HttpContext.Session.GetString("userName") != null;
			var isAdmin = HttpContext.Session.GetString("email") == "admin@gmail.com";
			if (!isAdmin)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
        }
    }
}
