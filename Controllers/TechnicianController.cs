using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TechnicianController : Controller
	{
		private SportsProContext context { get; set; }
		public TechnicianController(SportsProContext ctx) => context = ctx;

		[Route("[controller]s")]
		public IActionResult Technicians()
		{
			var technicians = context.Technicians.OrderBy(t => t.Name).ToList();
			return View("../Technician/Technicians", technicians);
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Technician());
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit";
			var product = context.Technicians.Find(id);
			return View(product);
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpPost]
		public IActionResult Edit(Technician technician)
		{
			if (ModelState.IsValid)
			{
				if (technician.TechnicianId == 0)
					context.Technicians.Add(technician);
				else
					context.Technicians.Update(technician);
				context.SaveChanges();
				return RedirectToAction("Technicians", "Home");
			}
			else
			{
				ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
				return View(technician);
			}
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var technician = context.Technicians.Find(id);
			return View(technician);
		}

		[Route("[controller]/[action]/{id?}")]
		[HttpPost]
		public IActionResult Delete(Technician technician)
		{
			context.Technicians.Remove(technician);
			context.SaveChanges();
			return RedirectToAction("Technicians", "Home");
		}

	}
}
