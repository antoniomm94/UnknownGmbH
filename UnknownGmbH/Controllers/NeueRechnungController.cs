using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnknownGmbH.HAK;
using UnknownGmbH.Models;

namespace UnknownGmbH.Controllers
{
    public class NeueRechnungController : Controller
    {
        private WorkContext db = new WorkContext();

        // GET: NeueRechnung
        public ViewResult Index(string sortOrder, string searchString)
        {
         
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var neuerechnungs = from s in db.NeueRechnungs
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
             neuerechnungs = neuerechnungs.Where(s => s.Klient.Contains(searchString)
                                          || s.FirmenName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    neuerechnungs = neuerechnungs.OrderByDescending(s => s.Klient);
                    break;
                case "Date":
                    neuerechnungs = neuerechnungs.OrderBy(s => s.Datum);
                    break;
                case "date_desc":
                    neuerechnungs = neuerechnungs.OrderByDescending(s => s.Datum);
                    break;
                default:
                    neuerechnungs = neuerechnungs.OrderBy(s => s.Klient);
                    break;
            }
            return View(neuerechnungs.ToList());
        }



            // GET: NeueRechnung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NeueRechnung neueRechnung = db.NeueRechnungs.Find(id);
            if (neueRechnung == null)
            {
                return HttpNotFound();
            }
            return View(neueRechnung);
        }

        // GET: NeueRechnung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NeueRechnung/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        /*
        var deutsch = Steuer.DE;
        var kroatisch = Steuer.KRO;
        int Menge = 0;
        decimal NettoPreis = 0m;
        decimal BruttoPreis = 0m;
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Klient,FirmenName,Adresse,Email,PLZ,Stadt,Land,Datum,Währung,Steuer,ZahlungsMethode,Artikel,Menge,ZahlenBis,NettoPreis,BruttoPreis,Gesamt")] NeueRechnung neueRechnung)
        {

            try
            {
                /*
                 if (deutsch)
                 { 
                    BruttoPreis = (Menge + 0.19) * NettoPreis;
                 }

                else if (kroatisch)
                {
                    BruttoPreis =(Menge + 0.25) * NettoPreis;
                }
                 
                 
                  */
                                              
                if (ModelState.IsValid)
                {
                    db.NeueRechnungs.Add(neueRechnung);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(neueRechnung);
        }

        // GET: NeueRechnung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NeueRechnung neueRechnung = db.NeueRechnungs.Find(id);
            if (neueRechnung == null)
            {
                return HttpNotFound();
            }
            return View(neueRechnung);
        }

        // POST: NeueRechnung/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var neuerechnungToUpdate = db.NeueRechnungs.Find(id);
            if (TryUpdateModel(neuerechnungToUpdate, "",
               new string[] { "Klient", "FirmenName", "Adresse", "Email", "PLZ", "Stadt","Land", "Datum", "Währung", "Steuer", "ZahlungsMethode", "Artikel","Menge", "ZahlenBis", "NettoPreis", "BruttoPreis", "Gesamt" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(neuerechnungToUpdate);
        }

        // GET: NeueRechnung/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            NeueRechnung neueRechnung = db.NeueRechnungs.Find(id);
            if (neueRechnung == null)
            {
                return HttpNotFound();
            }
            return View(neueRechnung);
        }

        // POST: NeueRechnung/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                NeueRechnung neueRechnung = db.NeueRechnungs.Find(id);
                db.NeueRechnungs.Remove(neueRechnung);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
