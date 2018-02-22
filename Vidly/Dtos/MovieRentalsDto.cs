using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieRentalsDto
    {
        public byte CustomerID { get; set; }
        public List<byte> MoviesIDs { get; set; }
    }
}