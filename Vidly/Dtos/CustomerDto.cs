using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vidly.Dtos;

namespace Vidly
{
    public class CustomerDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Byte CustomerID { get; set; }

        [Required]
        public string Name { get; set; }

        public Byte MembershipTypeID { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[AgeValidation]
        public DateTime? DateOfBirth { get; set; }
    }
}