using System.ComponentModel.DataAnnotations;

namespace StockServices.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProId { get; set; }

        [Required]
        public int InvId { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
