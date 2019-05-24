using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20,MinimumLength=1)]
        public string Title { get; set; }


        [Display(Name = "Release Date")]

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] //◦Allows special characters and numbers in subsequent spaces. "PG-13" is valid for a rating, but fails for a "Genre".

        public string Genre { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set; }

    //     [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    // [StringLength(5)]
    // [Required]
    // public string Rating { get; set; }

    }
}
