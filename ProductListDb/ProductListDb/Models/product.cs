using System.ComponentModel.DataAnnotations;

namespace ProductListDb.Models
{
    public class product
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}

