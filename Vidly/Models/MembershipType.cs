using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}