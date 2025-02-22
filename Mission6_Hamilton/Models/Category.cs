using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission6_Hamilton.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Navigation property
        public List<Movie> Movies { get; set; }
    }
}