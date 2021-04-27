using RateItData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RateItModels.Show
{
    public class ShowCreate
    {
        [Required]
        [Display(Name = "Show Name")]
        [Remote("IsShowNameExist", "Show", AdditionalFields = "Id",
                ErrorMessage = "Show name already exists")]
        [MaxLength(300, ErrorMessage = "Maximum character lenght required is 300 ")]
        [MinLength(1, ErrorMessage = "Minimum character lenght required is 1 ")]
        public string ShowName { get; set; }


        [Required]
        [Display(Name = "Director Name")]
        [MaxLength(300, ErrorMessage = "Maximum character lenght required is 300 ")]
        [MinLength(1, ErrorMessage = "Minimum character lenght required is 1 ")]
        public string DirectorName { get; set; }


        [Required]
        [Display(Name = "Duration In Minutes")]
        public decimal Duration { get; set; }


        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateRelease { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public ShowGenre GenreOfShow { get; set; }


        [Required]
        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
