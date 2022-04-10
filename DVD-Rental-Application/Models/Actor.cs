using System.ComponentModel.DataAnnotations;

namespace DVD_Rental_Application.Models
{
    public class Actor
    {
        [Key]
        public int ActorNumber { get; set; }
        public string? ActorFirstName { get; set; }
        public string? ActorSurname { get; set; }
    }
}
