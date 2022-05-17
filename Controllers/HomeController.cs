using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imdb.Models;

namespace imdb.Controllers
{
    public class HomeController : Controller
    {
        private Cmodel db = new Cmodel();
        public ActionResult Login()
        {
           // Session["Userid"] = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string username = form["uname"].ToString();
            string password = form["pass"].ToString();

            User user = db.users.Where(m => m.username == username && m.password == password).FirstOrDefault();

            if (user == null)
            {
                //   Session["Userid"] = "0";
                @ViewBag.error = "username or password is not correct";
                return View();
            }

            Session["Userid"] = user.Id.ToString();

            return RedirectToAction("index", "ProFile");
        }



        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FormCollection form, HttpPostedFileBase photo)
        {
            User user = new User();
            user.FristName = form["Fname"].ToString();
            user.lastName = form["Lname"].ToString();
            user.username = form["uname"].ToString();
            user.password = form["pass"].ToString();

            HttpPostedFileBase postedFile = Request.Files["photo"];

            string path = Server.MapPath("~/Uploads/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));

            user.Photo = "/Uploads/" + Path.GetFileName(postedFile.FileName);

            db.users.Add(user);
            db.SaveChanges();
            ViewBag.mss = "your acount is created ";

            return RedirectToAction("Login");
        }

        public ActionResult Home()
        {
            ViewBag.allmovie = db.actors.ToList();
            return View(db.movies.ToList());
        }

        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            string search = form["search"];
            SearchModel _search = new SearchModel();
            _search.movies = db.movies.Where(x => x.name.Contains(search)).ToList();
            _search.actors = db.actors.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search)).ToList();

            _search.directors = db.directors.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search)).ToList();

            return View(_search);
        }


        public ActionResult movieUser(int id)
        {
            int idi = Convert.ToInt32(id);

            acts_in_movie acts_In_Movie = new acts_in_movie();

            acts_In_Movie.movie1 = db.movies.Find(idi);
            acts_In_Movie.actors = db.actors.ToList();
            if (Session["Userid"] != null)
            {
                int userid = Convert.ToInt32(Session["Userid"]);

                acts_In_Movie.yourlike = acts_In_Movie.movie1.Likes.Where(x => x.UserID == userid).FirstOrDefault() == null ? null :
                    acts_In_Movie.movie1.Likes.Where(x => x.UserID == userid).FirstOrDefault().like;
            }

            return View(acts_In_Movie);
        }

        [HttpPost]
        public ActionResult movieUser(int id, FormCollection form)
        {
            string newcomment = form["newcomment"];

            Comment _comment = new Comment();
            _comment.comment = newcomment;
            _comment.MovieID = id;
            _comment.UserID = Convert.ToInt32(Session["Userid"].ToString());
            db.comments.Add(_comment);
            db.SaveChanges();
            return RedirectToAction("movieUser", "Home", new { id = id });

        }

        [HttpPost]
        public ActionResult LikemovieUser(int id, FormCollection form)
        {


            Likes _like = new Likes();
            _like.like = true;
            _like.MovieID = id;
            _like.UserID = Convert.ToInt32(Session["Userid"].ToString());
            db.Likes.Add(_like);
            db.SaveChanges();
            return RedirectToAction("movieUser", "Home", new { id = id });

        }
        [HttpPost]
        public ActionResult DislikemovieUser(int id, FormCollection form)
        {


            Likes _like = new Likes();
            _like.like = false;
            _like.MovieID = id;
            _like.UserID = Convert.ToInt32(Session["Userid"].ToString());
            db.Likes.Add(_like);
            db.SaveChanges();
            return RedirectToAction("movieUser", "Home", new { id = id });

        }
    }
}