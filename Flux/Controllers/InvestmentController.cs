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
    public class InvestmentController : Controller
    {
        private FluxContext db = new FluxContext();

        //
        // GET: /Investment/

        public ActionResult Index()
        {
            var investments = db.Investments.Include(i => i.BusinessUnit);
            return View(investments.ToList());
        }

        //
        // GET: /Investment/Details/5

        public ActionResult Details(int id = 0)
        {
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return HttpNotFound();
            }
            return View(investment);
        }

        //
        // GET: /Investment/Create

        public ActionResult Create()
        {
            ViewBag.BusinessUnitId = new SelectList(db.BusinessUnits, "BusinessUnitId", "Name");
            return View();
        }

        //
        // POST: /Investment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Investment investment)
        {
            if (ModelState.IsValid)
            {
                db.Investments.Add(investment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessUnitId = new SelectList(db.BusinessUnits, "BusinessUnitId", "Name", investment.BusinessUnitId);
            return View(investment);
        }

        //
        // GET: /Investment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessUnitId = new SelectList(db.BusinessUnits, "BusinessUnitId", "Name", investment.BusinessUnitId);
            return View(investment);
        }

        //
        // POST: /Investment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Investment investment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessUnitId = new SelectList(db.BusinessUnits, "BusinessUnitId", "Name", investment.BusinessUnitId);
            return View(investment);
        }

        //
        // GET: /Investment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return HttpNotFound();
            }
            return View(investment);
        }

        //
        // POST: /Investment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Investment investment = db.Investments.Find(id);
            db.Investments.Remove(investment);
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