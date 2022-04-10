using System.ComponentModel.DataAnnotations;

namespace DVD_Rental_Application.Models
{
    public class Studio
    {
        [Key]
        public int StudioNumber { get; set; }
        public string? StudioName { get; set; }
    }
}
