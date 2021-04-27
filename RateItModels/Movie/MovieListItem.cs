using RateItData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels.Movie
{
    public class MovieListItem
    {
        [Required]
        public int MovieId { get; set; }

        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Display(Name = "Director Name")]
        public string DirectorName { get; set; }

        [Display(Name = "Duration In Minutes")]
        public decimal Duration { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRelease { get; set; }

        [Display(Name = "Genre")]
        public MovieGenre GenreOfMovie { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
