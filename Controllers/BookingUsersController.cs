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
    public class BookingUsersController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public BookingUsersController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/BookingUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingUser>>> GetBookingUsers()
        {
            return await _context.BookingUsers.ToListAsync();
        }

        // GET: api/BookingUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingUser>> GetBookingUser(int id)
        {
            var bookingUser = await _context.BookingUsers.FindAsync(id);

            if (bookingUser == null)
            {
                return NotFound();
            }

            return bookingUser;
        }

        // PUT: api/BookingUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingUser(int id, BookingUser bookingUser)
        {
            if (id != bookingUser.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingUserExists(id))
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

        // POST: api/BookingUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingUser>> PostBookingUser(BookingUser bookingUser)
        {
            _context.BookingUsers.Add(bookingUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingUserExists(bookingUser.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingUser", new { id = bookingUser.BookingId }, bookingUser);
        }

        // DELETE: api/BookingUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingUser(int id)
        {
            var bookingUser = await _context.BookingUsers.FindAsync(id);
            if (bookingUser == null)
            {
                return NotFound();
            }

            _context.BookingUsers.Remove(bookingUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingUserExists(int id)
        {
            return _context.BookingUsers.Any(e => e.BookingId == id);
        }
    }
}
