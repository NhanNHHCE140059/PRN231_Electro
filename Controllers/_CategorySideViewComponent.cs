using ElectroMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElectroMVC.Controllers
{
	[ViewComponent(Name = "_CategorySide")]
	public class _CategorySideViewComponent : ViewComponent
	{
		private readonly ElectroMVCContext _context;

		public _CategorySideViewComponent(ElectroMVCContext context)
		{
			_context = context;

		}
		public IViewComponentResult Invoke()
		{
			var _category = _context.Category.ToList();
			return View("_CategorySide", _category);
		}
	}
}
