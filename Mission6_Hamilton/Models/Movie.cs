using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Hamilton.Models
{
    public class Movie
    {
  

        [Key]
        public int MovieId { get; set; }  // Primary Key

        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // Foreign Key from Categories table
        

        [Required]
        public string Title { get; set; }  // Movie title

        [Required]
        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100")]
        public int Year { get; set; }  // Year of release

        [Required]
        public string Director { get; set; }  // Director's name

        [Required]
        public string Rating { get; set; }  // Movie rating

        public bool Edited { get; set; }  // Has the movie been edited?

        public string? LentTo { get; set; }  // Who is the movie lent to?

        public bool CopiedToPlex { get; set; }  // Copied to Plex server?

        public string? Notes { get; set; }  // Any additional notes

        // Navigation property for Category (joining with Categories table)
        public Category? Category { get; set; }
    }
}