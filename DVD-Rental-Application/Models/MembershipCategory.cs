using System.ComponentModel.DataAnnotations;

namespace DVD_Rental_Application.Models
{
    public class MembershipCategory
    {
        [Key]
        public int MembershipCategoryNumber { get; set; }
        public string? MembershipCategoryDescription { get; set; }
        public string? MembershipCategoryTotalLoans { get; set; }

    }
}
