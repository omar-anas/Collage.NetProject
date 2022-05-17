using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using imdb.Models;

namespace imdb.Controllers
{
    public class fav_movController : Controller
    {
        private Cmodel db = new Cmodel();

        // GET: fav_mov
        public ActionResult Index()
        {
            return View(db.fav_Movs.ToList());
        }

        // GET: fav_mov/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_mov fav_mov = db.fav_Movs.Find(id);
            if (fav_mov == null)
            {
                return HttpNotFound();
            }
            return View(fav_mov);
        }

        // GET: fav_mov/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fav_mov/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,iduser,idmov")] fav_mov fav_mov)
        {
            if (ModelState.IsValid)
            {
                db.fav_Movs.Add(fav_mov);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fav_mov);
        }

        // GET: fav_mov/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_mov fav_mov = db.fav_Movs.Find(id);
            if (fav_mov == null)
            {
                return HttpNotFound();
            }
            return View(fav_mov);
        }

        // POST: fav_mov/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,iduser,idmov")] fav_mov fav_mov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fav_mov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fav_mov);
        }

        // GET: fav_mov/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_mov fav_mov = db.fav_Movs.Find(id);
            if (fav_mov == null)
            {
                return HttpNotFound();
            }
            return View(fav_mov);
        }

        // POST: fav_mov/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fav_mov fav_mov = db.fav_Movs.Find(id);
            db.fav_Movs.Remove(fav_mov);
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
