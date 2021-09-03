using DataAccessLayer.Data;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviewApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private IBookReviewRepository _repos;

        public BookReviewController(IBookReviewRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReview>> GetBookReviews()
        {
            return Ok(_repos.Read());
        }

        [HttpGet("{id}")]
        public ActionResult<BookReview> GetBookReviewById(int id)
        {
            return Ok(_repos.Read(id));
        }

        [HttpPost]
        public ActionResult CreateBookReview ([FromBody] BookReview review)
        {
            _repos.Create(review);

            return CreatedAtAction(nameof(GetBookReviewById), new { id = review.Id }, review.Id);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBookReview (int id, [FromBody] BookReview review)
        {
            _repos.Update(id, review);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBookReview(int id)
        {
            _repos.Delete(id);

            return Ok();
        }
    }
}
