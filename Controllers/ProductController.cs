using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using SportsPro.Models.Repositories;

namespace SportsPro.Controllers
{
	[Authorize(Roles = "Admin")]
    public class ProductController : Controller
	{
		//private SportsProContext context { get; set; }
		//public ProductController(SportsProContext ctx) => context = ctx;

		private Repository<Product> data {  get; set; }
		public ProductController(SportsProContext ctx) => data = new Repository<Product>(ctx);

		[Route("[controller]s")]
		public ViewResult Products()
		{
			//var products = context.Products.OrderBy(p => p.Name).ToList();
			var products = data.List(new QueryOptions<Product>
			{
				OrderBy = p => p.Name
			});
			return View(products);
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpGet]
		public ViewResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Product());
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpGet]
		public ViewResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var product = data.Get(id);
			return View(product);
		}


		// Left this as IActionResult because it has different return types based on conditions 
		[Route("[controller]/[action]/{id?}")]
		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				string action = "";

				if (product.ProductId == 0)
				{
					action = "added";
					data.Insert(product);
                }

				else
				{
					action = "edited";
                    data.Update(product);
                }

                data.Save();
				TempData["message"] = $"{product.Name} was {action}.";
				return RedirectToAction("Products", "Product");
			}
			else
			{
				ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
				return View(product);
			}
		}


		[Route("[controller]/[action]/{id?}")]
		[HttpGet]
		public ViewResult Delete(int id)
		{
			var product = data.Get(id);
			return View(product);
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpPost]
		public RedirectToActionResult  Delete(Product product)
		{
			data.Delete(product);
			data.Save();
			TempData["message"] = $"Deletion was successful.";
			return RedirectToAction("Products", "Product");
		}

	}

}
