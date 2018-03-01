using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class MovieRentals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MovieRentalsId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }
    }
}