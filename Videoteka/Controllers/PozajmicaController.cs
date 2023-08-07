using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json;
using Videoteka.Models;
using Videoteka.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Videoteka.Controllers
{
    public class PozajmicaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        VideotekaAPI _api = new VideotekaAPI();
        public ActionResult Index()
        {
            var pozajmica = db.Pozajmica.Include(p => p.Film).Include(p => p.Kupac);
            return View(pozajmica.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozajmica pozajmica = db.Pozajmica.Find(id);
            if (pozajmica == null)
            {
                return HttpNotFound();
            }
            return View(pozajmica);
        }


        public ActionResult Create()
        {
            ViewBag.FilmId = new SelectList(db.Filmovi, "Id", "Naziv");
            ViewBag.KupacId = new SelectList(db.Kupci, "Id", "Ime");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KupacId,FilmId,DatumPozajmice,DatumVracanja,Napomena")] Pozajmica pozajmica)
        {
            if (ModelState.IsValid)
            {
                db.Pozajmica.Add(pozajmica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KupacList = new SelectList(db.Kupci.ToList(), "Id", "Naziv", pozajmica.KupacId);
            ViewBag.FilmList = new SelectList(db.Filmovi.ToList(), "Id", "Naziv", pozajmica.FilmId);
            return View(pozajmica);
        }

        //[HttpPost]
        //public ActionResult Create(Pozajmica pozajmica)
        //{
        //    HttpClient client = _api.Initial();

        //    string json = JsonConvert.SerializeObject(pozajmica);

        //    HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        //    var postTask = client.PostAsync("api/Pozajmica", httpContent);
        //    postTask.Wait();

        //    var result = postTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        // GET: Pozajmica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozajmica pozajmica = db.Pozajmica.Find(id);
            if (pozajmica == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(db.Filmovi, "Id", "Naziv", pozajmica.FilmId);
            ViewBag.KupacId = new SelectList(db.Kupci, "Id", "Ime", pozajmica.KupacId);
            return View(pozajmica);
        }

        // POST: Pozajmica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KupacId,FilmId,DatumPozajmice,DatumVracanja,Napomena")] Pozajmica pozajmica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pozajmica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(db.Filmovi, "Id", "Naziv", pozajmica.FilmId);
            ViewBag.KupacId = new SelectList(db.Kupci, "Id", "Ime", pozajmica.KupacId);
            return View(pozajmica);
        }

        // GET: Pozajmica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozajmica pozajmica = db.Pozajmica.Find(id);
            if (pozajmica == null)
            {
                return HttpNotFound();
            }
            return View(pozajmica);
        }

        // POST: Pozajmica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pozajmica pozajmica = db.Pozajmica.Find(id);
            db.Pozajmica.Remove(pozajmica);
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
