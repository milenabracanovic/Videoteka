using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;

namespace Videoteka.Controllers
{
    public class KupacController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kupac
        public ActionResult Index()
        {
            var kupci = db.Kupci.Include(k => k.TipClanstva).Include(k => k.TipKupca).ToList();
            return View(kupci);
        }

        // GET: Kupac/Details/5
        // GET: Kupac/Delete/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kupac kupac = db.Kupci
                            .Include(k => k.TipClanstva)
                            .Include(k => k.TipKupca)
                            .SingleOrDefault(k => k.Id == id);

            if (kupac == null)
            {
                return HttpNotFound();
            }

            return View(kupac);
        }


        // GET: Kupac/Create
        public ActionResult Create()
        {
            ViewBag.TipClanstvaList = new SelectList(db.TipClanstva.ToList(), "Id", "Naziv");
            ViewBag.TipKupcaList = new SelectList(db.TipKupca.ToList(), "Id", "Naziv");
            return View();
        }

        // POST: Kupac/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,PrimaObavjestenja,DatumRodjenja,TipClanstvaId,TipKupcaId")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                db.Kupci.Add(kupac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipClanstvaList = new SelectList(db.TipClanstva.ToList(), "Id", "Naziv", kupac.TipClanstvaId);
            ViewBag.TipKupcaList = new SelectList(db.TipKupca.ToList(), "Id", "Naziv", kupac.TipKupcaId);
            return View(kupac);
        }

        // GET: Kupac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = db.Kupci.Find(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipClanstvaList = new SelectList(db.TipClanstva.ToList(), "Id", "Naziv", kupac.TipClanstvaId);
            ViewBag.TipKupcaList = new SelectList(db.TipKupca.ToList(), "Id", "Naziv", kupac.TipKupcaId);
            return View(kupac);
        }

        // POST: Kupac/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,PrimaObavjestenja,DatumRodjenja,TipClanstvaId,TipKupcaId")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kupac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipClanstvaList = new SelectList(db.TipClanstva.ToList(), "Id", "Naziv", kupac.TipClanstvaId);
            ViewBag.TipKupcaList = new SelectList(db.TipKupca.ToList(), "Id", "Naziv", kupac.TipKupcaId);
            return View(kupac);
        }

        // GET: Kupac/Delete/5
        // GET: Kupac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kupac kupac = db.Kupci
                            .Include(k => k.TipClanstva)
                            .Include(k => k.TipKupca)
                            .SingleOrDefault(k => k.Id == id);

            if (kupac == null)
            {
                return HttpNotFound();
            }

            return View(kupac);
        }


        // POST: Kupac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kupac kupac = db.Kupci.Find(id);
            db.Kupci.Remove(kupac);
            db.SaveChanges();
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
