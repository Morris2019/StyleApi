using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UrbanStyleApi.JWTConfigurations;
using UrbanStyleApi.Models;
using UrbanStyleApi.ModelsDTO.Request;
using UrbanStyleApi.ModelsDTO.Response;

namespace UrbanStyleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private readonly urbanstyleContext _context;
        private readonly UserManager<IdentityUser> _usersManager;
        private readonly JJWTurbanConfig _jwtconfig;
        public UsersController(urbanstyleContext context, UserManager<IdentityUser> usersManager, IOptionsMonitor<JJWTurbanConfig> optionsMonitor)
        {
            _context = context;
            _usersManager = usersManager;
            _jwtconfig = optionsMonitor.CurrentValue;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // GET: api/Users/5
        [HttpGet("UserBookings/{id}")]
        public async Task<IActionResult> GetUserBookings(int id)
        {
            var user = await _context.Users.Where(users => users.Id == Convert.ToInt32(id))
                .Include(usersbook => usersbook.Bookings)
                .ThenInclude(usersbook => usersbook.BookingItems)
                .Include(usersbook => usersbook.BookingUsers)
                .Include(usersbook => usersbook.BusinessServiceUsers)
                .ThenInclude(usersbook => usersbook.BusinessService)
                .ThenInclude(usersbook => usersbook.Location)
                .ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        [HttpPost]
        [Route("RegisterUsers")]
        public async Task<IActionResult> RegisterUsers([FromBody] UsersRegistrationRequest userRegister)
        {
            if (ModelState.IsValid)
            {
                var UserExist = await _usersManager.FindByEmailAsync(userRegister.Email);
                if (UserExist != null)
                {
                    return BadRequest(new UsersRegistrationResponse()
                    {
                        Errors = new List<string>()
                    {
                      "User Already Exist"
                     },
                        Success = false
                    });
                }

                var newUser = new IdentityUser() { Email = userRegister.Email, UserName = userRegister.Name, PhoneNumber = userRegister.Mobile };
                var IsCreated = await _usersManager.CreateAsync(newUser, userRegister.Password);
                if (IsCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);

                    return Ok(new UsersRegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new UsersRegistrationResponse()
                    {
                        Errors = IsCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }


            }
            return BadRequest(new UsersRegistrationResponse()
            {
                Errors = new List<string>()
                {
                    "Invalid Payload"
                },
                Success = false
            });

        }
        [HttpPost]
        [Route("LoginUsers")]
        public async Task<IActionResult> LoginUsers([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _usersManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    return BadRequest(new UsersRegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }

                var isCorrect = await _usersManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return BadRequest(new UsersRegistrationResponse()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }

                var jwtToken = GenerateJwtToken(existingUser);

                return Ok(new UsersRegistrationResponse()
                {
                    Success = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new UsersRegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }
        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtconfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
