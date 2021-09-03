using DataAccessLayer.Data;
using System.Collections.Generic;

namespace DataAccessLayer.Services
{
    public interface IBookReviewRepository
    {
        IEnumerable<BookReview> Read();
        BookReview Read(int id);
        void Create(BookReview bookReview);
        void Update(int id, BookReview bookReview);
        void Delete(int id);
    }
}
