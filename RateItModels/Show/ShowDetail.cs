using RateItData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels.Show
{
    public class ShowDetail
    {
        [Required]
        public int ShowId { get; set; }

        [Display(Name = "Show Name")]
        public string ShowName { get; set; }

        [Display(Name = "Director Name")]
        public string DirectorName { get; set; }

        [Display(Name = "Duration In Minutes")]
        public decimal Duration { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRelease { get; set; }

        [Display(Name = "Genre")]
        public ShowGenre GenreOfShow { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modification Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int? Rating { get; set; }
    }
}
