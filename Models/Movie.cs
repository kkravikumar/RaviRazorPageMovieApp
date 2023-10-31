
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace RaviRazorPageMovieApp.Models
{
    public class Movie
        {
            [Key]
            public int Id { get; set; }
            public string? Title { get; set; }

            [Display(Name = "Release Date")]
            [DataType(DataType.Date)]
            public DateTime ReleaseDate { get; set; }
            public string? Genre { get; set; }

            [Column(TypeName = "decimal(18, 2)")]
            public decimal Price { get; set; }

            [ForeignKey("HeroId")]
            // Navigation Object
            // Relationship - One to One 
            public Actor? Hero { get; set; }

            public int? HeroId { get; set; }

            // Relationship - One to Many 
            public ICollection<Actor>? Actors { get; set; }

            [NotMapped]
            public int HeroAge { get; set; }

    }
    }

