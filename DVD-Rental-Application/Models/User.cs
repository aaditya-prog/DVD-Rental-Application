using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVD_Rental_Application.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserNumber { get; set; }
        public string? UserName { get; set; }

        public string? UserType { get; set; }

        [Required(ErrorMessage ="Password is a required field")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Invalid Password, Length must be between 8 to 15 characters, must contain an uppercase letter, a number and a special character ")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }



    }
}
