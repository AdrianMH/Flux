using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flux.Models;

namespace Flux.Controllers
{
    public class BusinessUnitController : Controller
    {
        private FluxContext db = new FluxContext();

        //
        // GET: /BusinessUnit/

        public ActionResult Index()
        {
            return View(db.BusinessUnits.ToList());
        }

        //
        // GET: /BusinessUnit/Details/5

        public ActionResult Details(int id = 0)
        {
            BusinessUnit businessunit = db.BusinessUnits.Find(id);
            if (businessunit == null)
            {
                return HttpNotFound();
            }
            return View(businessunit);
        }

        //
        // GET: /BusinessUnit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BusinessUnit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusinessUnit businessunit)
        {
            if (ModelState.IsValid)
            {
                db.BusinessUnits.Add(businessunit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessunit);
        }

        //
        // GET: /BusinessUnit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BusinessUnit businessunit = db.BusinessUnits.Find(id);
            if (businessunit == null)
            {
                return HttpNotFound();
            }
            return View(businessunit);
        }

        //
        // POST: /BusinessUnit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessUnit businessunit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessunit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessunit);
        }

        //
        // GET: /BusinessUnit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BusinessUnit businessunit = db.BusinessUnits.Find(id);
            if (businessunit == null)
            {
                return HttpNotFound();
            }
            return View(businessunit);
        }

        //
        // POST: /BusinessUnit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessUnit businessunit = db.BusinessUnits.Find(id);
            db.BusinessUnits.Remove(businessunit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}