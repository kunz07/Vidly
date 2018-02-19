using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Genre")]
        public byte GenreID { get; set; }

        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}