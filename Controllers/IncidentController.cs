using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IncidentController : Controller
	{
		private SportsProContext context { get; set; }
		public IncidentController(SportsProContext ctx) => context = ctx;

        [Route("[controller]s")]
        public IActionResult Incidents(EditIncidentViewModel model)
		{
			var incidents = context.Incidents
				.Include(i => i.Customer)
				.Include(i => i.Product)
				.Include(i => i.Technician)
				.ToList();
			return View(incidents);
		}

		public IActionResult GetUnassigned(EditIncidentViewModel model)
		{
			var incidents = context.Incidents
				.Include(i => i.Customer)
				.Include(i => i.Product)
				.Include (i => i.Technician)
				.Where(i => i.Technician.TechnicianId == -1)
				.ToList();
			return View("Incidents", incidents);
		}

        public IActionResult GetOpen(EditIncidentViewModel model)
        {
            var incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .Where(i => i.CloseDate == null)
                .ToList();
            return View("Incidents", incidents);
        }

        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
		public ViewResult Add(EditIncidentViewModel model)
		{
			model.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
			model.Products = context.Products.OrderBy(p => p.Name).ToList();
			model.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();

			return View("Edit", model);
		}

        [Route("[controller]/[action]/{id?}")]
        [HttpGet]
		public IActionResult Edit(EditIncidentViewModel model, int id)
		{
			model.Action = "Edit";
			model.Customers = context.Customers.OrderBy(c => c.LastName).ToList();
			model.Products = context.Products.OrderBy(p => p.Name).ToList();
			model.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();

			model.Incident = context.Incidents.Find(id);
			return View(model);
		}

        [Route("[controller]/[action]/{id?}")]
        [HttpPost]
		public IActionResult Edit(EditIncidentViewModel model)
		{
			
			if (ModelState.IsValid)
			{
				if (model.Incident.IncidentId == 0)
					context.Incidents.Add(model.Incident);
				else
					context.Incidents.Update(model.Incident);
				context.SaveChanges();
				return RedirectToAction("Incidents");
			}
			else
			{
				model.Action = (model.Incident.IncidentId == 0) ? "Add" : "Edit";
				model.Customers = context.Customers.OrderBy(c => c.LastName)
					.ToList();
				model.Products = context.Products.OrderBy(c => c.Name)
					.ToList();
				model.Technicians = context.Technicians.OrderBy(c => c.Name)
					.ToList();

				return View(model);
			}

		}

		[Route("[controller]/[action]/{id?}")]
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var incident = context.Incidents.Find(id);
			return View(incident);
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpPost]
		public IActionResult Delete(EditIncidentViewModel model)
		{
			context.Incidents.Remove(model.Incident);
			context.SaveChanges();
			return RedirectToAction("Incidents", "Home");
		}
	}
}

