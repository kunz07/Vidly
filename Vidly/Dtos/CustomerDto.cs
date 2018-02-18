using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly
{
    public class CustomerDto
    {
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