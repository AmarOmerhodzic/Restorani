using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Restorani.Data;
using Restorani.Models;
using static System.Formats.Asn1.AsnWriter;

namespace Restorani.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var jela = _db.Jela.ToList();
            if (jela.Count == 0)
            {
                return View();
            }
            else
            {
                var randomJelo = jela[new Random().Next(jela.Count)];
                var restoran = _db.Restorani.FirstOrDefault(x => x.Id == randomJelo.RestoranId);
                var obj = new Jelo
                {
                    Id = randomJelo.Id,
                    Naziv = randomJelo.Naziv,
                    Cijena = randomJelo.Cijena,
                    Restorani = restoran
                };
                return View(obj);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }


       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
