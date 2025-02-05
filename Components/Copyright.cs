using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Components
{
	public class Copyright : ViewComponent
	{
		public IViewComponentResult Invoke() => View();
	}
}
