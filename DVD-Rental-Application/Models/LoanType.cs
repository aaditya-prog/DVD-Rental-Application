using System.ComponentModel.DataAnnotations;

namespace DVD_Rental_Application.Models
{
    public class LoanType
    {
        [Key]
        public int LoanTypeNumber { get; set; }
        public string? TypeOfLoan { get; set; }
        public string? LoanDuration { get; set; }


    }
}
