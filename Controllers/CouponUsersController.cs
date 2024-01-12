using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanStyleApi.Models;

namespace UrbanStyleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CouponUsersController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public CouponUsersController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/CouponUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CouponUser>>> GetCouponUsers()
        {
            return await _context.CouponUsers.ToListAsync();
        }

        // GET: api/CouponUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CouponUser>> GetCouponUser(long id)
        {
            var couponUser = await _context.CouponUsers.FindAsync(id);

            if (couponUser == null)
            {
                return NotFound();
            }

            return couponUser;
        }

        // PUT: api/CouponUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCouponUser(long id, CouponUser couponUser)
        {
            if (id != couponUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(couponUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponUserExists(id))
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

        // POST: api/CouponUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CouponUser>> PostCouponUser(CouponUser couponUser)
        {
            _context.CouponUsers.Add(couponUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCouponUser", new { id = couponUser.Id }, couponUser);
        }

        // DELETE: api/CouponUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouponUser(long id)
        {
            var couponUser = await _context.CouponUsers.FindAsync(id);
            if (couponUser == null)
            {
                return NotFound();
            }

            _context.CouponUsers.Remove(couponUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CouponUserExists(long id)
        {
            return _context.CouponUsers.Any(e => e.Id == id);
        }
    }
}
