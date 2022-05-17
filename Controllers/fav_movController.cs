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
