using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVD_Rental_Application.Models
{
    public class CastMember
    {
        public int DVDNumber { get; set; }
        [Key]
        [ForeignKey("DVDNumber")]
        public DVDTitle? DVDTitle { get; set; }

        public int ActorNumber { get; set; }
        [Key]
        [ForeignKey("ActorNumber")]
        public Actor Actor { get; set; }
    }
}
