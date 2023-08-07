using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;

namespace Videoteka.Controllers
{
    public class FilmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Film
        public ActionResult Index()
        {
            //return View(db.Filmovi.ToList());

            var filmovi = db.Filmovi.Include(f => f.Zanr).ToList();
            return View(filmovi);
        }

        // GET: Film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Film film = db.Filmovi.Find(id);
            Film film = db.Filmovi.Include(f => f.Zanr)
                            .SingleOrDefault(f => f.Id == id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            ViewBag.ZanrList = new SelectList(db.Zanr.ToList(), "Id", "Naziv");
            
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,ZanrId,DatumUnosa,DatumIzdanja,BrojNaStanju,BrojDostupnih")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Filmovi.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZanrList = new SelectList(db.Zanr.ToList(), "Id", "Naziv", film.ZanrId);
            return View(film);
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmovi.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZanrList = new SelectList(db.Zanr.ToList(), "Id", "Naziv", film.ZanrId);
            return View(film);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,ZanrId,DatumUnosa,DatumIzdanja,BrojNaStanju,BrojDostupnih")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZanrList = new SelectList(db.Zanr.ToList(), "Id", "Naziv", film.ZanrId);
            return View(film);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Film film = db.Filmovi
                            .Include(k => k.Zanr)
                            .SingleOrDefault(k => k.Id == id);

            if (film == null)
            {
                return HttpNotFound();
            }

            return View(film);
        }


        // POST: Kupac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Filmovi.Find(id);
            db.Filmovi.Remove(film);
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
