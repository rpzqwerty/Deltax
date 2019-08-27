using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DELTAXDAL;
using DeltaxWebApp.Models;

namespace DeltaxWebApp.Controllers
{
    public class MovieController : Controller
    {
        public DeltaxRepositoryFile db = new DeltaxRepositoryFile();
        
        public Models.Movie DAL_to_Client_Movie(DELTAXDAL.Movie DAL_MV)
        {
            Models.Movie movie = new Models.Movie();
            movie.Name = DAL_MV.Name;
            movie.plot = DAL_MV.plot;
            movie.Poster = DAL_MV.Poster;
            movie.Actors = DAL_MV.Actors;
            movie.yearOfRelease = (DateTime) DAL_MV.yearofRelease;
            return movie;
        }
        public DELTAXDAL.Movie Client_to_DAL(Models.Movie Client_MV)
        {
            DELTAXDAL.Movie movie = new DELTAXDAL.Movie();
            movie.Name = Client_MV.Name;
            movie.plot = Client_MV.plot;
            movie.Poster = Client_MV.Poster;
            movie.Actors = Client_MV.Actors;
            movie.yearofRelease = Client_MV.yearOfRelease;
            return movie;
        }

        public ActionResult Index()
        {
            List<Models.Movie> list_of_client_movies = new List<Models.Movie>();
            var list_of_movies = db.GetMovieList();
            foreach(var movie in list_of_movies)
            {
                list_of_client_movies.Add(DAL_to_Client_Movie(movie));
            }
            return View(list_of_client_movies);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Movie mv)
        {
            var movie = Client_to_DAL(mv);
            db.AddMovie(movie);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string name)
        {
            DELTAXDAL.Movie result = db.GetMovieDetails(name);
            var movie = DAL_to_Client_Movie(result);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit(Models.Movie mv)
        {
            var movie = Client_to_DAL(mv);
            db.EditMovie(movie);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string name)
        {
            DELTAXDAL.Movie result = db.GetMovieDetails(name);
            var movie = DAL_to_Client_Movie(result);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Delete(Models.Movie mv)
        {
            var result = Client_to_DAL(mv);
            db.DeleteMovie(result);
            return RedirectToAction("Index");
        }

    }
}