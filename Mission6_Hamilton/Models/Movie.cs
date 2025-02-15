using System.ComponentModel.DataAnnotations;

namespace Mission6_Hamilton.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Category { get; set; } = "";

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; } = "";

        [Required]
        public string Rating { get; set; } = ""; 
        // e.g. G, PG, PG-13, R

        public bool Edited { get; set; }  // optional

        public string? LentTo { get; set; }  // optional

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }  // optional
    }
}