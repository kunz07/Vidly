using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MembershipTypeID { get; set; }

        [Display(Name = "Membership Type")]
        public string MembershipName { get; set; }

        [Display(Name = "Duration in Months")]
        public int MembershipDuration { get; set; }
    }
}