using RateItData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels.Music
{
    public class MusicListItem
    {
        [Required]
        public int MusicId { get; set; }

        [Display(Name = "Artist Name")]

        public string ArtistName { get; set; }

        [Display(Name = "Duration In Minutes")]
        public decimal Duration { get; set; }


        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRelease { get; set; }

        [Display(Name = "Genre")]
        public MusicGenre GenreOfMusic { get; set; }

        [Display(Name = "Type")]
        public MusicType TypeOfMusic { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
