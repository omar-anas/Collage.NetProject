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
    public class fav_dirController : Controller
    {
        private Cmodel db = new Cmodel();

        // GET: fav_dir
        public ActionResult Index()
        {
            return View(db.fav_Dirs.ToList());
        }

        // GET: fav_dir/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_dir fav_dir = db.fav_Dirs.Find(id);
            if (fav_dir == null)
            {
                return HttpNotFound();
            }
            return View(fav_dir);
        }

        // GET: fav_dir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fav_dir/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,iduser,iddir")] fav_dir fav_dir)
        {
            if (ModelState.IsValid)
            {
                db.fav_Dirs.Add(fav_dir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fav_dir);
        }

        // GET: fav_dir/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_dir fav_dir = db.fav_Dirs.Find(id);
            if (fav_dir == null)
            {
                return HttpNotFound();
            }
            return View(fav_dir);
        }

        // POST: fav_dir/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,iduser,iddir")] fav_dir fav_dir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fav_dir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fav_dir);
        }

        // GET: fav_dir/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fav_dir fav_dir = db.fav_Dirs.Find(id);
            if (fav_dir == null)
            {
                return HttpNotFound();
            }
            return View(fav_dir);
        }

        // POST: fav_dir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fav_dir fav_dir = db.fav_Dirs.Find(id);
            db.fav_Dirs.Remove(fav_dir);
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
