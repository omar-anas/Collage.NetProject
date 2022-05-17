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
