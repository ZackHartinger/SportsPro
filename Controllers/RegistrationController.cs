using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegistrationController : Controller
	{
		private SportsProContext context { get; set; }
		public RegistrationController(SportsProContext ctx) => context = ctx;

		[Route("[controller]")]
		public IActionResult Index(RegistrationsViewModel model)
		{
		    model.Customers = context.Customers
				.Include("Products")
				.OrderBy(c => c.LastName).ToList();
			return View("GetCustomer", model);
		}

		[Route("[controller]s/{id?}/")]
		[HttpGet]
		public IActionResult GetCustomer(RegistrationsViewModel model)
		{
			if(model.CustomerId != 0)
			{
				var session = new SportsProSession(HttpContext.Session);
				session.SetCustomerId(model.CustomerId);
				model.Customer = context.Customers
					.Include(c => c.Products)
					.First(c => c.CustomerId == session.GetCustomerId());
				model.Products = context.Products.OrderBy(p => p.Name).ToList();

				return View("Registrations", model);
			}
			else
			{
				return RedirectToAction("Index");
			}
			
		}

		[HttpPost]
		public IActionResult Register(RegistrationsViewModel model)
		{
			var session = new SportsProSession(HttpContext.Session);
			session.SetCustomerId(model.Customer.CustomerId);

			if (model.ProductId != 0)
			{
				model.Products = context.Products.OrderBy(p => p.Name).ToList();
				model.Product = context.Products.Find(model.ProductId);

				model.Customer = context.Customers
					.Include("Products")
					.First(c => c.CustomerId == session.GetCustomerId());

				model.Customer.Products.Add(model.Product);
				if (model.Customer.Products.Contains(model.Product))
				{
					TempData["registrationMessage"] = $"{model.Product.Name} is already registered to {model.Customer.FullName}.";
				}
				context.Customers.Update(model.Customer);
				context.SaveChanges();
				return View("Registrations", model);
			}
			else
			{
				model.Customer = context.Customers
					.Include("Products")
					.First(c => c.CustomerId == session.GetCustomerId());
				model.Products = context.Products.OrderBy(p => p.Name).ToList();

				return View("Registrations", model);
			}
		}

		[HttpPost]
		[Route("[controller]s/[action]/{id}")]
		public IActionResult Delete(RegistrationsViewModel model, int id)
		{
			var session = new SportsProSession(HttpContext.Session);
			session.SetCustomerId(model.Customer.CustomerId);

			model.Products = context.Products.OrderBy(p => p.Name).ToList();

			model.Customer = context.Customers
				.Include("Products")
				.First(c => c.CustomerId == session.GetCustomerId());

			var product = model.Customer.Products.First(p => p.ProductId == id);

			model.Customer.Products.Remove(product);
			context.SaveChanges();
			return View("Registrations", model);

		}
	}
}
