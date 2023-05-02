using System.ComponentModel.DataAnnotations;

namespace InventoryServices.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage="Inventory Name must be Less Than 80 Charachtars")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Inventory Description must be Less Than 80 Charachtars")]
        public string Description { get; set; }

        [MaxLength(150, ErrorMessage = "Inventory Description must be Less Than 80 Charachtars")]
        public string Location { get; set; }
        public int MngId { get; set; }
        public bool IsActive { get; set; }
    }
}
