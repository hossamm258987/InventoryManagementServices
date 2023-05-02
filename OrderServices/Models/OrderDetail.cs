using System.ComponentModel.DataAnnotations;

namespace OrderServices.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantuty { get; set; }
        public double Amount { get; set; }
        public double ProductDiscount { get; set; }
    }
}
