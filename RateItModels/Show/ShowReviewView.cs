using RateItModels.Review;
using RateItModels.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItModels
{
    public class ShowReviewView
    {
        public ShowDetail Show { get; set; }
        public IEnumerable<ReviewDetail> Reviews { get; set; }
    }
}
