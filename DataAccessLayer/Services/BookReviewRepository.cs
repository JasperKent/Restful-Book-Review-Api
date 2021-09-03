using DataAccessLayer.Data;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Services
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly BookReviewDbContext _dbContext;

        public BookReviewRepository(BookReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(BookReview bookReview)
        {
            _dbContext.BookReviews.Add(bookReview);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.BookReviews.Remove(Read(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<BookReview> Read()
        {
            return _dbContext.BookReviews;
        }

        public BookReview Read(int id)
        {
            return _dbContext.BookReviews.SingleOrDefault(r => r.Id == id);
        }

        public void Update(int id, BookReview bookReview)
        {
            var review = Read(id);

            review.Title = bookReview.Title;
            review.Rating = bookReview.Rating;
            _dbContext.SaveChanges();
        }
    }
}
