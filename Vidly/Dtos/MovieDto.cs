using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MovieID { get; set; }

        public byte GenreID { get; set; }
        
        public GenreDto Genre { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number should be between 1 and 20")]
        public int NumberInStock { get; set; }
    }
}