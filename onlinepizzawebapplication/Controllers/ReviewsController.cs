using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinepizzawebapplication.Data;
using onlinepizzawebapplication.Models;

namespace onlinepizzawebapplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public ReviewsController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _fullStackDbContext.Reviews.ToListAsync();
            return Ok(reviews);
        }
        [HttpPost]
        public async Task<IActionResult> AddReviews([FromBody] Reviews reviewsRequest)
        {
            reviewsRequest.reviewid = Guid.NewGuid();
            await _fullStackDbContext.Reviews.AddAsync(reviewsRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(reviewsRequest);

        }
        [HttpPut]
        [Route("{reviewid:Guid}")]
        public async Task<IActionResult> UpdateReview([FromRoute] Guid reviewid, Reviews UpdateReviewRequest)
        {
            var reviews = await _fullStackDbContext.Reviews.FindAsync(reviewid);
            if (reviews == null)
            {
                return NotFound();
            }
            reviews.category = UpdateReviewRequest.category;
            reviews.pizzaname = UpdateReviewRequest.pizzaname;
            reviews.rating = UpdateReviewRequest.rating;
            reviews.description=UpdateReviewRequest.description;

            await _fullStackDbContext.SaveChangesAsync();
            return Ok(reviews);

        }
        [HttpDelete]
        [Route("{reviewid:Guid}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid reviewid)
        {
            var reviews = await _fullStackDbContext.Reviews.FindAsync(reviewid);
            if (reviews == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Reviews.Remove(reviews);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(reviews);
        }
    }
    }
