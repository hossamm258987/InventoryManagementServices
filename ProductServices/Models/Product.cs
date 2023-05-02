using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public double BuingPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int SupplierId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int TypeId { get; set; }
        public int InventoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
