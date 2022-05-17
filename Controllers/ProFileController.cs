using imdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace imdb.Controllers
{
    public class ProFileController : Controller
    {
        private Cmodel db = new Cmodel();
        public ActionResult Index()
        {
            if (Session["Userid"] == "0" && Session["Userid"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.allactor = db.actors.ToList();
            ViewBag.allmovies = db.movies.ToList();
            ViewBag.alldirctor = db.directors.ToList();

            int id = Convert.ToInt32(Session["userid"]);
            User user = db.users.Find(id);
            return View(user);
        }
        //Favourite Actors
        [HttpPost]
        public ActionResult addFavActor(FormCollection form)
        {
            int id = Convert.ToInt32(Session["Userid"]);
            int idAct = Convert.ToInt32(form["act"]);

            fav_act _Act = new fav_act();

            _Act.idact = idAct;
            _Act.iduser = id;
            _Act.User = db.users.Find(id);
            _Act.Actor = db.actors.Find(idAct);
            db.fav_Acts.Add(_Act);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //Favourite Directors
        [HttpPost]
        public ActionResult addFavDir(FormCollection form)
        {
            int id = Convert.ToInt32(Session["Userid"]);
            int idDir = Convert.ToInt32(form["dir"]);

            fav_dir dir = new fav_dir();

            dir.iddir = idDir;
            dir.iduser = id;
            dir.User = db.users.Find(id);
            dir.Director = db.directors.Find(idDir);
            db.fav_Dirs.Add(dir);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //Favourite Movies
        [HttpPost]
        public ActionResult addFavMovie(FormCollection form)
        {
            int id = Convert.ToInt32(Session["Userid"]);
            int idmov = Convert.ToInt32(form["movie"]);

            fav_mov mov = new fav_mov();

            mov.idmov = idmov;
            mov.iduser = id;
            mov.User = db.users.Find(id);
            mov.Movie = db.movies.Find(idmov);
            db.fav_Movs.Add(mov);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}