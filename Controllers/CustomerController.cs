using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;


namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
	{
		private SportsProContext context { get; set; }
		public CustomerController(SportsProContext ctx) => context = ctx;

        [Route("[controller]s")]
        public IActionResult Customers()
        {
            var customers = context.Customers.OrderBy(c => c.LastName).ToList();
            return View("../Customer/Customers", customers);
        }

        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Customer());
		}

        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var customer = context.Customers.Find(id);
			return View(customer);
		}

        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
		public IActionResult Edit(Customer customer)
		{
			if (TempData["okEmail"] == null)
			{
				string msg = Check.EmailExists(context, customer.Email);
				if (!String.IsNullOrEmpty(msg))
				{
					ModelState.AddModelError(nameof(Customer.Email), msg);
				}
			}
			if (ModelState.IsValid)
			{
				if (customer.CustomerId == 0)
					context.Customers.Add(customer);
				else
					context.Customers.Update(customer);
				context.SaveChanges();
				return RedirectToAction("Customers");
			}
			else
			{
				ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
				return View(customer);
			}
		}

        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
		public IActionResult Delete(int id)
		{
			var customer = context.Customers.Find(id);
			return View(customer);
		}

        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
		public IActionResult Delete(Customer customer)
		{
			context.Customers.Remove(customer);
			context.SaveChanges();
			return RedirectToAction("Customers");
		}
	}
}
