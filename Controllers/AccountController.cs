using ElectroMVC.Data;
using ElectroMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectroMVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly ElectroMVCContext _context;

		public AccountController(ElectroMVCContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(User user)
		{
			var _user = _context.User.FirstOrDefault(u => u.UserEmail == user.UserEmail && u.UserPassword == user.UserPassword);
			if (_user == null)
			{
				ViewBag.LoginStatus = 0;
				return View();
			}
			string navigateController;
			if (_user.UserRole == Role.ADMIN)
			{
				navigateController = "Admin";
			} 
			else
			{
				navigateController= "Home";
			}
			HttpContext.Session.SetString("userName", _user.UserName!);
			HttpContext.Session.SetString("email", _user.UserEmail!);
			return RedirectToAction("Index", navigateController);

		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(User user, string PwdRepeat)
		{
			if (!ModelState.IsValid || user.UserPassword != PwdRepeat)
			{
				return View();
			}
			//user.UserBirthday = DateTime.Parse(user.UserBirthday).ToString("dd/MM/yyyy");
			_context.User.Add(user);
			_context.SaveChanges();
			return RedirectToAction("Login");
		}
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("userName");
			HttpContext.Session.Remove("email");
			return RedirectToAction("Login", "Account");
		}
	}
}
