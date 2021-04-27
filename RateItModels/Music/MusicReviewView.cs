using RateItModels.Music;
using RateItModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels
{
    public class MusicReviewView
    {
        public MusicDetail Music { get; set; }
        public IEnumerable<ReviewDetail> Reviews { get; set; }
    }
}
