using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VarastoMVC.Models;
using VarastoMVC.Data;


namespace VarastoMVC.Controllers
{
    public class ArtikkelitController : Controller
    {
        private VarastoDBEntities db = new VarastoDBEntities();

        // GET: Artikkelit
        public ActionResult Index()
        {
            var artikkelit = db.Artikkelit.Include(a => a.Kategoriat);
            return View(artikkelit.ToList());
        }


        // JSON DATAA LÄHETTÄVÄ METODI
        public JsonResult ArtikkelitByKategoria(int? id)
        {

            var artikkelit = db.Artikkelit.Where(a => a.KategoriaId == id);

            List<ArtikkeliData> list = new List<ArtikkeliData>();

            foreach (Artikkelit a in artikkelit)
            {
                ArtikkeliData ad = new ArtikkeliData();
                ad.ArtikkeliId = a.ArtikkeliId;
                ad.ArtikkeliNimi = a.Artikkelinimi;
                list.Add(ad);
            }

            return Json(list, JsonRequestBehavior.AllowGet);

        }


        // GET: Artikkelit/Create
        public ActionResult Create()
        {
            ViewBag.KategoriaId = new SelectList(db.Kategoriat, "KategoriaId", "KategoriaNimi");
            return View();
        }

        // POST: Artikkelit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtikkeliId,Artikkelinimi,KategoriaId")] Artikkelit artikkelit)
        {
            if (ModelState.IsValid)
            {
                db.Artikkelit.Add(artikkelit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriaId = new SelectList(db.Kategoriat, "KategoriaId", "KategoriaNimi", artikkelit.KategoriaId);
            return View(artikkelit);
        }

        // GET: Artikkelit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikkelit artikkelit = db.Artikkelit.Find(id);
            if (artikkelit == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaId = new SelectList(db.Kategoriat, "KategoriaId", "KategoriaNimi", artikkelit.KategoriaId);
            return View(artikkelit);
        }

        // POST: Artikkelit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtikkeliId,Artikkelinimi,KategoriaId")] Artikkelit artikkelit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikkelit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaId = new SelectList(db.Kategoriat, "KategoriaId", "KategoriaNimi", artikkelit.KategoriaId);
            return View(artikkelit);
        }

        // GET: Artikkelit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikkelit artikkelit = db.Artikkelit.Find(id);
            if (artikkelit == null)
            {
                return HttpNotFound();
            }
            return View(artikkelit);
        }

        // POST: Artikkelit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artikkelit artikkelit = db.Artikkelit.Find(id);
            db.Artikkelit.Remove(artikkelit);
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
