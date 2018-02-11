using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MovieID { get; set; }

        [Display(Name = "Genre")]
        public byte GenreID { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
    }
}