using System.ComponentModel.DataAnnotations;

namespace OrderServices.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80, ErrorMessage="Name Must be Less Than 80 Charchtars")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage="Description Must be Less Than 300 Charchtars")]
        public string Description { get; set; }
        public DateTime OrdDate { get; set; } = DateTime.Now;
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public int InventoryId { get; set; }
        public int SupplierId { get; set; }
        public int EmployeeId { get; set; }
    }
}
