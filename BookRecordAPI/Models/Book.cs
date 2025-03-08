using System.ComponentModel.DataAnnotations;

namespace BookRecordAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        [Range(1000, 2100, ErrorMessage = "Published Year must be between 1000 and 2100.")]
        public int PublishedYear { get; set; }

    }
}
