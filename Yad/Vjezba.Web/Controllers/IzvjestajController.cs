using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serviceSloj.Models;
using databaseLayerProject.Models;
using databaseLayerProject.Models.Mock;
using Vjezba.Web.Models;


namespace Vjezba.Web.Controllers
{
    public class IzvjestajController : Controller
    {
        // GET: Izvjestaj
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Index()
        {
            var dbContext = new shopDbContext();

            var data = dbContext.Orders
                .ToList();

            foreach (var d in data)
            {
                d.profit = Izracun.porez(d.cijena);
            }

            var total = new Tuple<IEnumerable<Narudzbe>, double>(data, Izracun.Profit(data));

            return View(total);

        }
        public double izracunaj(List<Narudzbe> nar)
        {
           return Izracun.Profit(nar);
        }


        [Authorize(Roles = "Admin,Regular")]
        public ActionResult FilterForm()
        {
            return PartialView("_Filter");
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Index(NarucbaFilter filter)
         {
            var dbContext = new shopDbContext();
    
         var dataQuery = dbContext.Orders.ToList();

        if (!string.IsNullOrWhiteSpace(filter.KupacIme))
            dataQuery = dataQuery.Where(p => p.Kupac.Name.Contains(filter.KupacIme)).ToList();

        if (!string.IsNullOrWhiteSpace(filter.CarIme))
            dataQuery = dataQuery.Where(p => p.Car != null && p.Car.Name.Contains(filter.CarIme)).ToList();

        if (!string.IsNullOrWhiteSpace(filter.Prodavac))
            dataQuery = dataQuery.Where(p => p.Prodavac != null && p.Prodavac.Name.Contains(filter.Prodavac)).ToList();

        if (!string.IsNullOrWhiteSpace(filter.DucanIme))
            dataQuery = dataQuery.Where(p => p.Ducani != null && p.Ducani.Name.Contains(filter.DucanIme)).ToList();

        foreach (var data in dataQuery)
            {
                data.profit = Izracun.porez(data.cijena);
            }

            var total = new Tuple<IEnumerable<Narudzbe>, double>(dataQuery, Izracun.Profit(dataQuery));

            return View(total);
    
    
        }
       

        [HttpPost]
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Filter()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}