using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVD_Rental_Application.Models
{
    public class Member
    {

        [Key]
        public int MemberNumber { get; set; }

        public int MembershipCategoryNumber { get; set; }
        [ForeignKey("MembershipCategoryNumber")]
        public MembershipCategory? MembershipCategory { get; set; }

        public string? MemberFirstName { get; set; }
        public string? MemberLastName { get; set; }
        public string? MemberAddress { get; set; }
        public string? MemberDateOfBirth { get; set; }


    }
}
