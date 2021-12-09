using DL;
using Ent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingBL : IRatingBL
    {
        IRatingDL _ratintDL;
        public RatingBL(IRatingDL ratingDL)
        {
            _ratintDL = ratingDL;
        }

        public void insertRating(Rating rating)
        {
            _ratintDL.insertRating(rating);
        }
    }
}
