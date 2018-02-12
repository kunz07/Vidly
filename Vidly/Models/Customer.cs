using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Vidly.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Byte CustomerID { get; set; }

        [Display(Name = "Membership Type")]
        public Byte MembershipTypeID { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [AgeValidation]
        public DateTime? DateOfBirth { get; set; }
    }
}