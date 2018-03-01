using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        public ApplicationDbContext _db { get; set; }

        public MovieRentalsController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(MovieRentalsDto newRental)
        {
            var customer = _db.Customers.Single(c => c.CustomerID == newRental.CustomerID);
            var moviesList = _db.Movies.Where(c => newRental.MovieIDs.Contains(c.MovieID)).ToList();
            Console.WriteLine(moviesList);
            foreach (var movie in moviesList)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest();

                movie.NumberAvailable--;
                var rental = new MovieRentals
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _db.MovieRentals.Add(rental);
            }

            _db.SaveChanges();
            return Ok("Done");
        }
    }
}
