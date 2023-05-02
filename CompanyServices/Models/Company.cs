using System.ComponentModel.DataAnnotations;

namespace CompanyServices.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Name Must be Less Than 80 Charchtar")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Description Must be Less Than 300 Charchtar")]
        public string Description { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "Phone Must be Less Than 14 Charchtar")]
        public string Phone { get; set; }


        [MaxLength(50, ErrorMessage = "Email Must be Less Than 50 Charchtar")]
        public string Email { get; set; }


        [MaxLength(30, ErrorMessage = "Country Must be Less Than 30 Charchtar")]
        public string Country { get; set; }


        [MaxLength(30, ErrorMessage = "City Must be Less Than 30 Charchtar")]
        public string City { get; set; }


        [MaxLength(60, ErrorMessage = "Street Must be Less Than 60 Charchtar")]
        public string Street { get; set; }


        [MaxLength(6, ErrorMessage = "Postal Code Must be Less Than 6 Charchtar")]
        public string PostalCode { get; set; }

        public bool IsActive { get; set; }
    }
}
