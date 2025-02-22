using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Hamilton.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; } = "Unknown Title";

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than 1888.")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; } = "Unknown Director";

        [Required]
        public string Rating { get; set; } = "Not Rated";

        public bool Edited { get; set; }

        public string LentTo { get; set; } = "N/A";

        public bool CopiedToPlex { get; set; }

        public string Notes { get; set; } = "";

        public Category Category { get; set; }
    }
}