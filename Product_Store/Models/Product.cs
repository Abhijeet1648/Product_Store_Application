using System.ComponentModel.DataAnnotations;

namespace Product_Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 10, ErrorMessage = "Value should not be less than 1 or More than 10")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
