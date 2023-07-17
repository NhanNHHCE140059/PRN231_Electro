using ElectroMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElectroMVC.Controllers
{
	[ViewComponent(Name = "_Search")]
	public class _SearchViewComponent : ViewComponent
	{
		private readonly ElectroMVCContext _context;

		public _SearchViewComponent(ElectroMVCContext context)
		{
			_context = context;

		}
		public IViewComponentResult Invoke()
		{
			var _category = _context.Category.ToList();
			return View("_Search", _category);
		}
	}
}
