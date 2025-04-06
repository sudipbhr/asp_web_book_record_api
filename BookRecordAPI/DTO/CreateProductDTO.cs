using System.ComponentModel.DataAnnotations;

namespace BookRecordAPI.DTO
{
    public class CreateProductDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public bool IsActive { get; set; } = true;

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }
    }
}
