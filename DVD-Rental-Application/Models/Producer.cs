using System.ComponentModel.DataAnnotations;

namespace DVD_Rental_Application.Models
{
    public class Producer
    {
        [Key]
        public int ProducerNumber { get; set; }
        public string? ProducerName { get; set; }
    }
}
