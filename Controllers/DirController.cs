using imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace imdb.Controllers
{
    public class DirController : Controller
    {
        private Cmodel db = new Cmodel();
     
        public ActionResult Dir_one(int? id)
        {
            int idi = Convert.ToInt32(id);

            director director = db.directors.Find(idi);
            director.movies = db.movies.Where(m => m.id_director == idi).ToList();

            return View(director);
        }
        
    }
}