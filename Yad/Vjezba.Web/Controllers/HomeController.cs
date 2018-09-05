using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Vjezba.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string lang)
        {
            ViewBag.Message = "Odabrani jezik: " + lang;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Jednostavan način proslijeđivanja poruke iz Controller -> View.";

            //Kao rezultat se pogled /Views/Home/Contact.cshtml renderira u "pravi" HTML
            //Primjetiti - View() je poziv funkcije koja uzima cshtml template i pretvara ga u HTML
            //Zasto bas Contact.cshtml? Jer se akcija zove Contact, te prema konvenciji se "po defaultu" uzima cshtml datoteka u folderu Views/CONTROLLER_NAME/AKCIJA.cshtml


            return View();
        }

        /// <summary>
        /// Ova akcija se poziva kada na formi za kontakt kliknemo "Submit"
        /// URL ove akcije je /Home/SubmitQuery, uz POST zahtjev isključivo - ne može se napraviti GET zahtjev zbog [HttpPost] parametra
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitQuery(FormCollection formData)
        {
            //Ovdje je potrebno obraditi podatke i pospremiti finalni string u ViewBag

            var ime = formData["ime"];
            var prezime = formData["prezime"];
            var email = formData["email"];
            var poruka = formData["poruka"];
            var tip = formData["tip"];
            var newsletter = bool.Parse(formData["newsletter"].Split(',').FirstOrDefault());

            var msg = "Dragi {0} {1} ({2}) zaprimili smo vašu poruku te će vam se netko ubrzo javiti. Sadržaj vaše poruke je: [{3}] {4}." +
                " Također, {5} o daljnjim promjenama preko newslettera.";

            ViewBag.Message = string.Format(msg,
                ime, prezime,
                email,
                tip, poruka,
                newsletter ? "obavijestit cemo vas" : "necemo vas obavijestiti");


            //Kao rezultat se pogled /Views/Home/ContactSuccess.cshtml renderira u "pravi" HTML
            //Kao parametar se predaje naziv cshtml datoteke koju treba obraditi (ne koristi se default vrijednost)
            //Trazenu cshtml datoteku je potrebno samostalno dodati u projekt
            return View("ContactSuccess");
        }

    }
}