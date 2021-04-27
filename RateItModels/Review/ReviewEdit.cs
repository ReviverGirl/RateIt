using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels.Review
{
    public  class ReviewEdit
    {
        [Required]

        public int ReviewId { get; set; }

        [Display(Name = "Comments")]
        [MaxLength(3000, ErrorMessage = "Maximum character lenght required is 3000 ")]
        [MinLength(2, ErrorMessage = "Minimum character lenght required is 2 ")]
        public string Content { get; set; }


        [Display(Name = "Rating ***** ")]
        [Range(1, 5, ErrorMessage = "Enter a rating on a scale of 1-5")]
        public int Rating { get; set; }

        [Display(Name = "Movie ID")]
        public int? MovieId { get; set; }

        [Display(Name = "Music ID")]
        public int? MusicId { get; set; }

        [Display(Name = "Show ID")]
        public int? ShowId { get; set; }

    }
}
