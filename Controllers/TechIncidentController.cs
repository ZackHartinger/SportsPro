using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SportsPro.Models;
using SportsPro.Models.Repositories;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TechIncidentController : Controller
	{
		private SportsProContext context { get; set; }
		public TechIncidentController(SportsProContext ctx) => context = ctx;

		// I tried to implement the repository here but could not include the multiple enitities needed using mehtods covered in the chapter
		//private Repository<Technician> data { get; set; }
		//public TechIncidentController(SportsProContext ctx) => data = new Repository<Technician>(ctx);

		[Route("[controller]")]
		public IActionResult TechIncident(EditIncidentViewModel model)
		{
			model.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
			return View("../Incident/TechIncident", model);
		}

		public IActionResult List(EditIncidentViewModel model)
		{
			var session = new SportsProSession(HttpContext.Session);
			session.SetTechnicianId(model.TechnicianId);

			var technicianName = context.Technicians.Find(session.GetTechnicianId()).Name;
			ViewBag.TechnicianName = technicianName;

			model.Incidents = context.Incidents
				.Include(i => i.Customer)
				.Include(i => i.Product)
				.Include(i => i.Technician)
				.Where(i => i.TechnicianId == session.GetTechnicianId()).ToList();

			//model.Incidents = data.List(QueryOptions<Incident>{
			//	OrderBy = indexer 
			//})
			return View("../Incident/TechIncidentList", model);
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
			return View("../Incident/TechIncidentEdit", model);
		}
		[Route("[controller]/[action]/{id?}")]
		[HttpPost]
		public IActionResult Edit(EditIncidentViewModel model)
		{
			if (model.Incident.IncidentId == 0)
					context.Incidents.Add(model.Incident);
				else
					context.Incidents.Update(model.Incident);
				context.SaveChanges();
				model.TechnicianId = model.Incident.TechnicianId;
				return RedirectToAction("List", model);
			
		}

	}
}
