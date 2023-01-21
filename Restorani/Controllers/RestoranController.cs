using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restorani.Data;
using Restorani.Models;
using System.Linq;

namespace Restorani.Controllers
{
    public class RestoranController : Controller
    {
		private readonly ApplicationDBContext _db;

		public RestoranController(ApplicationDBContext db)
		{
			_db = db;
		}
		public IActionResult Index()
        {
			IEnumerable<Restoran> objList = _db.Restorani;
			return View(objList);
		}

        //GET-CREATE
       public IActionResult Create()
        {
            return View();
        }

        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restoran obj)
        {
            if (ModelState.IsValid)
            {
                _db.Restorani.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
       
		

	}
}
