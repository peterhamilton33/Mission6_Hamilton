using System.ComponentModel.DataAnnotations;

namespace Mission6_Hamilton.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string Category { get; set; } // Add this line to match the database schema

        [Required]
        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }
    }
}