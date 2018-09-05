using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using databaseLayerProject.Models;
using databaseLayerProject.Models.Mock;
using Microsoft.AspNet.Identity;

namespace Vjezba.Web.Controllers
{
    public class CarInventoryController : Controller
    {
       
        // GET: CarInventory
        [AllowAnonymous]
        public ActionResult Index()
        {
            using (var dbContext = new shopDbContext())
            {
                var data = dbContext.Cars
                    .ToList();

                return View(data);
        }
        }
        [AllowAnonymous]
        public ActionResult Details(int? id = null)
        {
            if (id == null)
                return View();
            using (var dbContext = new shopDbContext())
            {
                var data = dbContext.Cars
                    .ToList()
                    .FirstOrDefault(p => p.ID == id);

                return View(data);
            }
        }
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Create(Car model)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new shopDbContext();
                dbContext.Cars.Add(model);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [Authorize(Roles = "Admin,Regular")]
        public ActionResult Edit(int id)
        { 
            using (var dbContext = new shopDbContext())
            {
                var model = dbContext.Cars
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
                var model = dbContext.Cars
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
                var model = dbContext.Cars
                    .FirstOrDefault(p => p.ID == id);

                dbContext.Entry(model).State = EntityState.Deleted;
                dbContext.SaveChanges();

                return Json(new { isSuccess = true });
            }
        }
    }
}