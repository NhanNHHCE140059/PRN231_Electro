using ElectroMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectroMVC.Controllers
{
	[ViewComponent(Name = "_Category")]
	public class _CategoryViewComponent : ViewComponent
	{
		private readonly ElectroMVCContext _context;

		public _CategoryViewComponent(ElectroMVCContext context)
		{
			_context = context;

		}
		public IViewComponentResult Invoke()
		{
			var _category = _context.Category.ToList();
			return View("_Category", _category);
		}
	}
}
