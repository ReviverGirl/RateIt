using RateItData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels.Music
{
    public class MusicEdit
    {
        [Required]
        public int MusicId { get; set; }

        [Display(Name = "Artist Name")]
        [MaxLength(300, ErrorMessage = "Maximum character lenght required is 300 ")]
        [MinLength(1, ErrorMessage = "Minimum character lenght required is 1 ")]
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

    }
}
