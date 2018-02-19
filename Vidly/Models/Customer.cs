using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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