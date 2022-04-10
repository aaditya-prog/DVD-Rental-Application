using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVD_Rental_Application.Models
{
    public class DVDTitle
    {
        [Key]
        public int DVDNumber { get; set; }

        public int ProducerNumber { get; set; }
        [ForeignKey("ProducerNumber")]
        public Producer Producer { get; set; }

        public int CategoryNumber { get; set; }
        [ForeignKey("CategoryNumber")]
        public DVDCategory DVDCategory { get; set; }

        public int StudioNumber { get; set; }
        [ForeignKey("StudioNumber")]
        public Studio Studio { get; set; }

        public DateTime DateReleased { get; set; }

        public double StandardCharge { get; set; }

        public double PenaltyCharge { get; set; }

        public string? Description { get; set; }



    }
}