using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RateItData
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Enter a rating on a scale of 1-5")]
        public int Rating { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public int? MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }



        public int? ShowId { get; set; }
        [ForeignKey(nameof(ShowId))]
        public virtual Show Show { get; set; }


        public int? MusicId { get; set; }
        [ForeignKey(nameof(MusicId))]
        public virtual Music Music { get; set; }
    }
}
