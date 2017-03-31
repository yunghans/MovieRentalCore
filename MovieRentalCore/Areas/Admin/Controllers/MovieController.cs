using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Data;
using MovieRental.Models;

namespace MovieRentalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly IMovieRepository rep;

        public MovieController(IMovieRepository movieRep)
        {
            rep = movieRep;
        }

        // GET: Movie
        public ActionResult Index()
        {

            IEnumerable<Movie> movies = rep.GetAllMovies();
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(string id)
        {
            Movie movie = rep.GetMovie(id);
            return View(movie);

        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);

        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                rep.Add(movie);
                rep.Save();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.ToString());
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(string id)
        {
            Movie movie = rep.GetMovie(id);
            return View(movie);
        }


        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                Movie movie = rep.GetMovie(id);
                if (await TryUpdateModelAsync(movie))
                {
                    rep.Save();
                    return RedirectToAction("Index");
                } else
                {
                    return View();
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.ToString());
                return View();
            }
        }


        // GET: Movie/Delete/5
        public ActionResult Delete(string id)
        {
            return View(rep.GetMovie(id));
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                rep.Delete(id);
                rep.Save();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.ToString());
                return View();
            }
        }

    }
}
