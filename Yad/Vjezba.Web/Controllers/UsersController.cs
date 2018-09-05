using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using databaseLayerProject.Models;
using databaseLayerProject.Models.Mock;

namespace Vjezba.Web.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            using (var dbContext = new shopDbContext())
            {
                var data = dbContext.Users
                    .ToList();

                return View(data);
            }
        }

        public ActionResult Details(int? id = null)
        {
            if (id == null)
                return View();
            using (var dbContext = new shopDbContext())
            {
                var data = dbContext.Users
                    .ToList()
                    .FirstOrDefault(p => p.ID == id);

                return View(data);
            }
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Prodavac model)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new shopDbContext();
                dbContext.Users.Add(model);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            using (var dbContext = new shopDbContext())
            {
                var model = dbContext.Users
                    .FirstOrDefault(p => p.ID == id);

                return View(model);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        [Authorize(Roles = "Admin")]
        public ActionResult EditPost(int id)
        {
            using (var dbContext = new shopDbContext())
            {
                var model = dbContext.Users
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            using (var dbContext = new shopDbContext())
            {
                var model = dbContext.Users
                    .FirstOrDefault(p => p.ID == id);

                dbContext.Entry(model).State = EntityState.Deleted;
                dbContext.SaveChanges();

                return Json(new { isSuccess = true });
            }
        }
    }
}
