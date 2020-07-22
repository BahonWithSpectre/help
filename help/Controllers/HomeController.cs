using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using help.Models;
using help.DbFolder;
using Microsoft.EntityFrameworkCore;

namespace help.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDb db;

        public HomeController(ILogger<HomeController> logger, AppDb _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            var list = db.Helps.Include(p=>p.City).ToList();

            ViewBag.City = db.Cities.ToList();

            return View(list);
        }


        [HttpPost]
        public IActionResult Index(string category, int? city, string type)
        {
            var list = db.Helps.Include(p => p.City).ToList();

            ViewBag.City = db.Cities.ToList();

            //if (category.Length != 0)
            //{
            //    list = list.Where(p => p.Category == category).ToList();
            //}
            if(city != null && city != 0)
            {
                list = list.Where(p => p.CityId == city).ToList();
            }
            if (type != null && type != "all")
            {
                list = list.Where(p => p.Type == type).ToList();
            }

            return View(list);
        }



        public IActionResult Creat()
        {
            ViewBag.City = db.Cities.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Creat(Help help)
        {
            var tt = help;

            db.Helps.Add(help);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        //public IActionResult AddCity()
        //{
        //    List<City> cities = new List<City>();

        //    cities.Add(new City { CityName="Астана" });
        //    cities.Add(new City { CityName = "Алматы" });
        //    cities.Add(new City { CityName = "Шымкент" });
        //    cities.Add(new City { CityName = "Тараз" });
        //    cities.Add(new City { CityName = "Қызылорда" });
        //    cities.Add(new City { CityName = "Қостанай" });
        //    cities.Add(new City { CityName = "Орал" });
        //    cities.Add(new City { CityName = "Ақтөбе" });
        //    cities.Add(new City { CityName = "Семей" });

        //    db.Cities.AddRange(cities);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

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
