using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.CanManageMovies))
                return View("Index");

            return View("ReadOnlyIndex");
        }

        // GET: Movies/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            var genres = db.Genres.ToList();
            var moviedetails = new MovieDetailsViewModel()
            {
                Movie = movie,
                Genres = genres
            };
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(moviedetails);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            return View();
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,GenreID,MovieName,ReleaseDate,NumberInStock")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreID);
            return View(movie);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        // GET: Movies/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreID);
            return View(movie);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,GenreID,MovieName,ReleaseDate,NumberInStock")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movie.GenreID);
            return View(movie);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        // GET: Movies/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            var genres = db.Genres.ToList();
            var movies = new MovieDetailsViewModel()
            {
                Movie = movie,
                Genres = genres
            };
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
