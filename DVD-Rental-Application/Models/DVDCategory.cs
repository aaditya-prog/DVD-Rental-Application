using System.ComponentModel.DataAnnotations;

namespace DVD_Rental_Application.Models
{
    public class DVDCategory
    {
        [Key]
        public int CategoryNumber { get; set; }
        public string? CategoryDescription { get; set; }

        public int AgeRestricted { get; set; }
    }
}