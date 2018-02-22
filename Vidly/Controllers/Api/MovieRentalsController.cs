using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        public ApplicationDbContext db { get; set; }

        public MovieRentalsController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(MovieRentalsDto newRental)
        {
            var customer = db.Customers.Single(c => c.CustomerID == newRental.CustomerID);
            var moviesList = db.Movies.Where(c => newRental.MoviesIDs.Contains(c.MovieID)).ToList();

            foreach(var movie in moviesList)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest();

                movie.NumberAvailable--;
                var rental = new MovieRentals {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                db.MovieRentals.Add(rental);
            }

            db.SaveChanges();
            Console.WriteLine("WTF!?");
            return Ok("Done");
        }
    }
}
