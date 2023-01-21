using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restorani.Data;
using Restorani.Models;
using Restorani.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restorani.Controllers
{
	public class JeloController : Controller
	{

        private readonly ApplicationDBContext _db;
		public JeloController(ApplicationDBContext db)
		{
			_db = db;
		}

		//Stranica sa listom jela
		public IActionResult Index()
		{
			IEnumerable<Jelo> objList = _db.Jela;
			foreach (var obj in objList)
			{
				obj.Restorani = _db.Restorani.FirstOrDefault(u => u.Id == obj.RestoranId);
			}

			return View(objList);
		}

		//Create-GET
		public IActionResult Create()
		{
			JeloVM jeloVM = new JeloVM()
			{
				Jelo = new Jelo(),
				NameDropDown = _db.Restorani.Select(i => new SelectListItem
				{
					Text = i.Naziv,
					Value = i.Id.ToString()
				})
			};
			return View(jeloVM);
		}

		//Create-POST
		public IActionResult CreatePost(JeloVM obj)
		{
			if (ModelState.IsValid)
			{
				_db.Jela.Add(obj.Jelo);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}
