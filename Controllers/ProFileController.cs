using imdb.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            int id = Convert.ToInt32(Session["userid"]);
            User user = db.users.Find(id);
            List<actor> actors = db.actors.ToList();
            actors.RemoveAll(x => user.Fav_Acts.Select(y => y.idact).ToList().Contains(x.id));
            ViewBag.allactor = actors;
            List<movie> movies = db.movies.ToList();
            movies.RemoveAll(x => user.Fav_Movs.Select(y => y.idmov).ToList().Contains(x.id));
            ViewBag.allmovies = movies;
            List<director> dirs = db.directors.ToList();
            dirs.RemoveAll(x => user.Fav_Dirs.Select(y => y.iddir).ToList().Contains(x.id));
            ViewBag.alldirctor = dirs;
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

        public ActionResult edit(int id)
        {

            User user = db.users.Find(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult edit(FormCollection form, HttpPostedFileBase photo, int id)
        {

            User user = db.users.Find(id);
            user.FristName = form["Fname"].ToString();
            user.lastName = form["Lname"].ToString();


            HttpPostedFileBase postedFile = Request.Files["photo"];
            if (postedFile.ContentLength > 0)
            {
                string path = Server.MapPath("~/Uploads/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));

                user.Photo = "/Uploads/" + Path.GetFileName(postedFile.FileName);

            }
            db.SaveChanges();
            ViewBag.mss = "your acount is updated ";

            return RedirectToAction("Index");

        }

    }
}