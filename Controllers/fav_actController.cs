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
    public class fav_actController : Controller
    {
        private Cmodel db = new Cmodel();

        // GET: fav_act
        public ActionResult Index()
        {
            return View(db.fav_Acts.ToList());
        }

        // GET: fav_act/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_act fav_act = db.fav_Acts.Find(id);
            if (fav_act == null)
            {
                return HttpNotFound();
            }
            return View(fav_act);
        }

        // GET: fav_act/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fav_act/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,iduser,idact")] fav_act fav_act)
        {
            if (ModelState.IsValid)
            {
                db.fav_Acts.Add(fav_act);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fav_act);
        }

        // GET: fav_act/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_act fav_act = db.fav_Acts.Find(id);
            if (fav_act == null)
            {
                return HttpNotFound();
            }
            return View(fav_act);
        }

        // POST: fav_act/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,iduser,idact")] fav_act fav_act)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fav_act).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fav_act);
        }

        // GET: fav_act/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_act fav_act = db.fav_Acts.Find(id);
            if (fav_act == null)
            {
                return HttpNotFound();
            }
            return View(fav_act);
        }

        // POST: fav_act/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fav_act fav_act = db.fav_Acts.Find(id);
            db.fav_Acts.Remove(fav_act);
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
