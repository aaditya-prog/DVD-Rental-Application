using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVD_Rental_Application.Models
{
    public class DVDCopy
    {
        [Key]
        public int CopyNumber { get; set; }

        public int DVDNumber { get; set; }
        [ForeignKey("DVDNumber")]
        public DVDTitle? DVDTitle { get; set; }

        public DateTime DatePurchased { get; set; }


    }
}