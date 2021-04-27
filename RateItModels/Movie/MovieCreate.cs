using RateItData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RateItModels.Movie
{
    public class MovieCreate
    {
        [Required]
        [Display(Name = "Movie Name")]
        [Remote("IsMovieNameExist", "Movie", AdditionalFields = "Id",
                ErrorMessage = "Movie name already exists")]
        [MaxLength(300, ErrorMessage = "Maximum character lenght required is 300 ")]
        [MinLength(1, ErrorMessage = "Minimum character lenght required is 1 ")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name = "Director Name")]
        [MaxLength(300, ErrorMessage = "Maximum character lenght required is 300 ")]
        [MinLength(1, ErrorMessage = "Minimum character lenght required is 1 ")]
        public string DirectorName { get; set; }

        [Required]
        [Range(1, 300, ErrorMessage = "Enter a valid Duration between 1 to 300 minutes")]
        [Display(Name = "Duration In Minutes")]
        public decimal Duration { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRelease { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public MovieGenre GenreOfMovie { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }


    }
}
