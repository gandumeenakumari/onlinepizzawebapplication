using Microsoft.AspNetCore.Mvc;
using onlinepizzawebapplication.Data;
using Microsoft.EntityFrameworkCore;
using onlinepizzawebapplication.Models;

namespace onlinepizzawebapplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

            private readonly FullStackDbContext _fullStackDbContext;
            public LoginController(FullStackDbContext fullStackDbContext)
            {
                _fullStackDbContext = fullStackDbContext;
            }
            [HttpGet]
            public async Task<IActionResult> GetAlllogins()
            {
                var logins = await _fullStackDbContext.login.ToListAsync();
                return Ok(logins);
            }
            [HttpPost]
            public async Task<IActionResult> Addlogins([FromBody] login loginRequest)
            {
                loginRequest.loginid = Guid.NewGuid();
                await _fullStackDbContext.login.AddAsync(loginRequest);
                await _fullStackDbContext.SaveChangesAsync();
                return Ok(loginRequest);

            }
            [HttpPut]
            [Route("{loginid:Guid}")]
            public async Task<IActionResult> UpdateLogin([FromRoute] Guid loginid, login UpdateLoginRequest)
            {
                var logins = await _fullStackDbContext.login.FindAsync(loginid);
                if (logins == null)
                {
                    return NotFound();
                }
                logins.name = UpdateLoginRequest.name;
                logins.email = UpdateLoginRequest.email;
                logins.password= UpdateLoginRequest.password;

                await _fullStackDbContext.SaveChangesAsync();
                return Ok(logins);

            }
        }
    }