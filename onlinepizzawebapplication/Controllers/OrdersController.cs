using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinepizzawebapplication.Data;
using onlinepizzawebapplication.Models;

namespace onlinepizzawebapplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public OrdersController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _fullStackDbContext.Orders.ToListAsync();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrders([FromBody] Orders ordersRequest)
        {
            ordersRequest.orderid = Guid.NewGuid();
            await _fullStackDbContext.Orders.AddAsync(ordersRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(ordersRequest);

        }
        [HttpPut]
        [Route("{orderid:Guid}")]
        public async Task<IActionResult> UpdateOrders([FromRoute] Guid orderid, Orders UpdateOrdersRequest)
        {
            var orders = await _fullStackDbContext.Orders.FindAsync(orderid);
            if (orders == null)
            {
                return NotFound();
            }
            orders.category = UpdateOrdersRequest.category;
            orders.pizzaname = UpdateOrdersRequest.pizzaname;
            orders.price=UpdateOrdersRequest.price;

            await _fullStackDbContext.SaveChangesAsync();
            return Ok(orders);

        }
        [HttpDelete]
        [Route("{orderid:Guid}")]
        public async Task<IActionResult> DeleteOrders([FromRoute] Guid orderid)
        {
            var orders = await _fullStackDbContext.Orders.FindAsync(orderid);
            if (orders == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Orders.Remove(orders);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(orders);
        }
    }
}
