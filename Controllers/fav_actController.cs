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
