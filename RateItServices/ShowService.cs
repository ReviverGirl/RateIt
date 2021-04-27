using RateIt.Data;
using RateItData;
using RateItModels.Review;
using RateItModels.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateItServices
{
    public class ShowService
    {
        public readonly Guid _userId;
        public ShowService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateShow(ShowCreate model)
        {
            var entity =
                new Show()
                {
                    OwnerId = _userId,
                    ShowName = model.ShowName,
                    DirectorName = model.DirectorName,
                    Duration = model.Duration,
                    GenreOfShow = model.GenreOfShow,
                    DateRelease = model.DateRelease,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shows
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                            e =>
                            new ShowListItem
                            {
                                ShowId = e.ShowId,
                                ShowName = e.ShowName,
                                DirectorName = e.DirectorName,
                                Duration = e.Duration,
                                GenreOfShow = e.GenreOfShow,
                                DateRelease = e.DateRelease,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<ShowListItem> GetAllShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shows
                    .Select(
                            e =>
                            new ShowListItem
                            {
                                ShowId = e.ShowId,
                                ShowName = e.ShowName,
                                DirectorName = e.DirectorName,
                                Duration = e.Duration,
                                GenreOfShow = e.GenreOfShow,
                                DateRelease = e.DateRelease,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }
        public ShowDetail GetShowById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == id);
                return
                    new ShowDetail
                    {
                        ShowId = entity.ShowId,
                        ShowName = entity.ShowName,
                        DirectorName = entity.DirectorName,
                        Duration = entity.Duration,
                        DateRelease = entity.DateRelease,
                        GenreOfShow = entity.GenreOfShow,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public IEnumerable<ReviewDetail> GetReveiwsByShowId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Where(e => e.ShowId == id)
                    .Select(
                                e =>
                                new ReviewDetail
                                {
                                    ReviewId = e.ReviewId,
                                    ShowId = e.ShowId,
                                    Content = e.Content,
                                    Rating = e.Rating,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );
                return query.ToArray();

            }
        }
        public double GetRatingAvgByShowId(int id)
        {
            var ListofReviews = GetReveiwsByShowId(id);
            List<int> ListofRatings = new List<int>();
            if (ListofReviews.Count() != 0)
            {
                foreach (var review in ListofReviews)
                {
                    ListofRatings.Add(review.Rating);

                }
                return ListofRatings.Average();

            }
            else return 0;


        }
        public bool UpdateShow(ShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == model.ShowId && e.OwnerId == _userId);
                entity.ShowName = model.ShowName;
                entity.DirectorName = model.DirectorName;
                entity.Duration = model.Duration;
                entity.DateRelease = model.DateRelease;
                entity.GenreOfShow = model.GenreOfShow;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteShow(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == showId && e.OwnerId == _userId);

                ctx.Shows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
