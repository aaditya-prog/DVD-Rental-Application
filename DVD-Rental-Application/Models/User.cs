using System.ComponentModel.DataAnnotations;

namespace DVD_Rental_Application.Models
{
    public class User
    {
        [Key]
        public int UserNumber { get; set; }
        public string? UserName { get; set; }

        public string? UserType { get; set; }

        public string? Password { get; set; }



    }
}
