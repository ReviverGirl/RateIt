using RateIt.Data;
using RateItData;
using RateItModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItServices
{
    public class ReviewService
    {
        public readonly Guid _userId;
        public ReviewService (Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    OwnerId=_userId,
                    Content=model.Content,
                    Rating=model.Rating,
                    MovieId=model.MovieId,
                    ShowId = model.ShowId,
                    MusicId = model.MusicId,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                            e=>
                            new ReviewListItem
                            {
                                ReviewId=e.ReviewId,
                                Content=e.Content,
                                Rating=e.Rating,
                                MovieId = e.MovieId,
                                ShowId = e.ShowId,
                                MusicId = e.MusicId,
                                CreatedUtc =e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<ReviewListItem> GeAllReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Select(
                            e =>
                            new ReviewListItem
                            {
                                ReviewId = e.ReviewId,
                                Content = e.Content,
                                Rating = e.Rating,
                                MovieId = e.MovieId,
                                ShowId = e.ShowId,
                                MusicId = e.MusicId,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }
        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewId == id && e.OwnerId == _userId);
                return
                    new ReviewDetail
                    {
                        ReviewId=entity.ReviewId,
                        Content=entity.Content,
                        Rating=entity.Rating,
                        MovieId = entity.MovieId,
                        ShowId = entity.ShowId,
                        MusicId = entity.MusicId,
                        CreatedUtc =entity.CreatedUtc,
                        ModifiedUtc=entity.ModifiedUtc


                    };
            }
        }
        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewId == model.ReviewId && e.OwnerId == _userId);
                entity.Content = model.Content;
                entity.Rating = model.Rating;
                entity.MovieId = model.MovieId;
                entity.ShowId = model.ShowId;
                entity.MusicId = model.MusicId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}
