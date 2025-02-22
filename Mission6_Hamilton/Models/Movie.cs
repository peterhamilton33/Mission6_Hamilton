using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Hamilton.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        // Navigation property
        public Category Category { get; set; }
    }
}