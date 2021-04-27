using RateItData;
using RateItModels.Movie;
using RateItModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels
{
    public class MovieReviewView
    {
        public MovieDetail Movie { get; set; }
        public IEnumerable<ReviewDetail> Reviews { get; set; }
    }
}
