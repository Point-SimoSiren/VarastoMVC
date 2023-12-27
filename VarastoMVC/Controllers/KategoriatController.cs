﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VarastoMVC.Models;

namespace VarastoMVC.Controllers
{
    public class KategoriatController : Controller
    {
        private VarastoDBEntities db = new VarastoDBEntities();

        // GET: Kategoriat
        public ActionResult Index()
        {
            return View(db.Kategoriat.ToList());
        }

        // GET: Kategoriat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriat kategoriat = db.Kategoriat.Find(id);
            if (kategoriat == null)
            {
                return HttpNotFound();
            }
            return View(kategoriat);
        }

        // GET: Kategoriat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategoriat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriaId,KategoriaNimi")] Kategoriat kategoriat)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriat.Add(kategoriat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriat);
        }

        // GET: Kategoriat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriat kategoriat = db.Kategoriat.Find(id);
            if (kategoriat == null)
            {
                return HttpNotFound();
            }
            return View(kategoriat);
        }

        // POST: Kategoriat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriaId,KategoriaNimi")] Kategoriat kategoriat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriat);
        }

        // GET: Kategoriat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriat kategoriat = db.Kategoriat.Find(id);
            if (kategoriat == null)
            {
                return HttpNotFound();
            }
            return View(kategoriat);
        }

        // POST: Kategoriat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoriat kategoriat = db.Kategoriat.Find(id);
            db.Kategoriat.Remove(kategoriat);
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
