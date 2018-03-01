using System.Collections.Generic;

namespace Vidly.Dtos
{
    public class MovieRentalsDto
    {
        public byte CustomerID { get; set; }
        public List<byte> MovieIDs { get; set; }
    }
}