using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinepizzawebapplication.Data;
using onlinepizzawebapplication.Models;

namespace onlinepizzawebapplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public PizzaController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPizzas()
        {
            var pizzas = await _fullStackDbContext.Pizzas.ToListAsync();
            return Ok(pizzas);
        }
        [HttpPost]
        public async Task<IActionResult> AddPizza([FromBody] Pizza pizzaRequest)
        {
            pizzaRequest.pizzaid = Guid.NewGuid();
            await _fullStackDbContext.Pizzas.AddAsync(pizzaRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(pizzaRequest);

        }
        [HttpPut]
        [Route("{pizzaid:Guid}")]
        public async Task<IActionResult> UpdatePizza([FromRoute] Guid pizzaid, Pizza UpdatePizzaRequest)
        {
            var pizzas = await _fullStackDbContext.Pizzas.FindAsync(pizzaid);
            if (pizzas == null)
            {
                return NotFound();
            }
            pizzas.category = UpdatePizzaRequest.category;
            pizzas.name = UpdatePizzaRequest.name;
            pizzas.price = UpdatePizzaRequest.price;

            await _fullStackDbContext.SaveChangesAsync();
            return Ok(pizzas);

        }
        [HttpDelete]
        [Route("{pizzaid:Guid}")]
        public async Task<IActionResult> DeletePizza([FromRoute] Guid pizzaid)
        {
            var pizzas = await _fullStackDbContext.Pizzas.FindAsync(pizzaid);
            if (pizzas == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Pizzas.Remove(pizzas);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(pizzas);
        }
    }
}





