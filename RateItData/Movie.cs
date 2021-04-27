using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RateItData
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MovieGenre { Aventure = 1, Action=2, Animation=3, Crime=4, Comedy=5, Drama=6, Fantasy=7, Horror=8, Musical=9, Thriller=10, War=11 }
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Remote("IsMovieNameExist", "Movie", AdditionalFields = "Id",
                ErrorMessage = "Movie name already exists")]
        public string MovieName { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [Required]
        [Display(Name = "Duration In Minutes")]
        public decimal Duration { get; set; }

        [Required]
        [Display(Name = "DateRelease")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRelease { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public MovieGenre GenreOfMovie { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

       
    }
}
