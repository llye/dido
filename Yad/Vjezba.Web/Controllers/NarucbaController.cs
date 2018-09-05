using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using databaseLayerProject.Models;
using databaseLayerProject.Models.Mock;
using serviceSloj.Models;

namespace Vjezba.Web.Controllers
{
    public class NarucbaController : Controller
    {
        
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Index()
        {
            var dbContext = new shopDbContext();
            
                var data = dbContext.Orders
                    .ToList();
               
                return View(data);
            
        }
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Details(int? id = null)
        {
            if (id == null)
                return View();
            using (var dbContext = new shopDbContext())
            {
                var data = dbContext.Orders
                    .ToList()
                    .FirstOrDefault(p => p.ID == id);

                return View(data);
            }
        }

        public ActionResult Create()
        {
            this.FillDropDownValues();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Create(Narudzbe model)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new shopDbContext();

                var data = dbContext.Cars
                    .ToList();
                int carId = (int)model.CarId;
                var car = data.FirstOrDefault(p => p.ID == carId);
              
                model.cijena = Izracun.izracunaj(car.SellPrice, 500);
                dbContext.Orders.Add(model);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                this.FillDropDownValues();
                return View(model);
            }
        }
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Edit(int id)
        {
            this.FillDropDownValues();
            using (var dbContext = new shopDbContext())
            {
                var model = dbContext.Orders
                    .FirstOrDefault(p => p.ID == id);

                return View(model);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult EditPost(int id)
        {
            using (var dbContext = new shopDbContext())
            {
                var model = dbContext.Orders
                    .FirstOrDefault(p => p.ID == id);

                var didUpdateModelSucceed = this.TryUpdateModel(model);

                if (didUpdateModelSucceed && ModelState.IsValid)
                {
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }

        }
        [HttpPost]
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Delete(int id)
        {
            using (var dbContext = new shopDbContext())
            {
                var model = dbContext.Orders
                    .FirstOrDefault(p => p.ID == id);

                dbContext.Entry(model).State = EntityState.Deleted;
                dbContext.SaveChanges();

                return Json(new { isSuccess = true });
            }
        }
        private void FillDropDownValues()
        {
            using (var dbContext = new shopDbContext())
            {
                var possibleManagers = dbContext.Users
                    .ToList();
                var possibleCars = dbContext.Cars
                    .ToList();
                var possibleStores = dbContext.Stores
                    .ToList();
                var possibleBuyers = dbContext.Kupci
                    .ToList();

                var selectItems = new List<System.Web.Mvc.SelectListItem>();

                //Polje je opcionalno
                var listItem = new SelectListItem();
                listItem.Text = "- odaberite -";
                listItem.Value = "";
                selectItems.Add(listItem);

                foreach (var aa in possibleManagers)
                {
                    listItem = new SelectListItem();
                    listItem.Text = aa.Name;
                    listItem.Value = aa.ID.ToString();
                    listItem.Selected = false;
                    selectItems.Add(listItem);
                }
                ViewBag.PossibleManagers = selectItems;
                //////////////////////////////////////////////////////////////////////////////
                 selectItems = new List<System.Web.Mvc.SelectListItem>();

                //Polje je opcionalno
                 listItem = new SelectListItem();
                listItem.Text = "- odaberite -";
                listItem.Value = "";
                selectItems.Add(listItem);

                foreach (var aa in possibleCars)
                {
                    listItem = new SelectListItem();
                    listItem.Text = aa.Name;
                    listItem.Value = aa.ID.ToString();
                    listItem.Selected = false;
                    selectItems.Add(listItem);
                }
                ViewBag.possibleCars = selectItems;

                selectItems = new List<System.Web.Mvc.SelectListItem>();
                //////////////////////////////////////////////////////////////////////////////
                //Polje je opcionalno
                 listItem = new SelectListItem();
                listItem.Text = "- odaberite -";
                listItem.Value = "";
                selectItems.Add(listItem);

                foreach (var aa in possibleStores)
                {
                    listItem = new SelectListItem();
                    listItem.Text = aa.Name;
                    listItem.Value = aa.ID.ToString();
                    listItem.Selected = false;
                    selectItems.Add(listItem);
                }
                ViewBag.possibleStores = selectItems;
                //////////////////////////////////////////////////////////////////////////////

                selectItems = new List<System.Web.Mvc.SelectListItem>();
                //Polje je opcionalno
                listItem = new SelectListItem();
                listItem.Text = "- odaberite -";
                listItem.Value = "";
                selectItems.Add(listItem);

                foreach (var aa in possibleBuyers)
                {
                    listItem = new SelectListItem();
                    listItem.Text = aa.Name;
                    listItem.Value = aa.ID.ToString();
                    listItem.Selected = false;
                    selectItems.Add(listItem);
                }
                ViewBag.possibleBuyers = selectItems;
            }
        }
    }
}