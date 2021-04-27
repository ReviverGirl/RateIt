using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItData
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MusicGenre { Alternative = 1, American=2,  Comedy=3, Classical=4, Country=5, Dance=6, Electronic=7, Holiday=8, International=9, Jazz=10, Latino=11, Opera=12, Other=13, Pop=14, Reggae=15, Rock=16, Rap=17 }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MusicType { Single = 1, Album=2 }
    public class Music
    {
        [Key]
        public int MusicId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ArtistName { get; set; }

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
        public MusicGenre GenreOfMusic { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public MusicType TypeOfMusic { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

       
    }
}
