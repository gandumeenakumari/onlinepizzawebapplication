using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinepizzawebapplication.Data;
using onlinepizzawebapplication.Models;

namespace onlinepizzawebapplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly FullStackDbContext _c;
        public CategoriesController(FullStackDbContext c)
        {
            _c = c;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _c.Categories.ToListAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategories([FromBody] Categories categoryRequest)
        {
            categoryRequest.categoryid = Guid.NewGuid();

            await _c.Categories.AddAsync(categoryRequest);
            await _c.SaveChangesAsync();
            return Ok(categoryRequest);

        }
        [HttpPut]
        [Route("{categoyid:Guid}")]
        public async Task<IActionResult> UpdateCategories([FromRoute] Guid categoryid,Categories UpdatCategoriesRequest)
        {
            var category = await _c.Categories.FindAsync(categoryid);
            if(category == null)
            {
                return NotFound();
            }
            category.categoryname=UpdatCategoriesRequest.categoryname;
            await _c.SaveChangesAsync();
            return Ok(category);

        }
        [HttpDelete]
        [Route("{categoryid:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid categoryid)
        {
            var category = await _c.Categories.FindAsync(categoryid);
            if (category == null)
            {
                return NotFound();
            }
            _c.Categories.Remove(category);
            await _c.SaveChangesAsync();
            return Ok(category);
        }
    }
}
