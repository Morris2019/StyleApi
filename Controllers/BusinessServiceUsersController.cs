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
    public class BusinessServiceUsersController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public BusinessServiceUsersController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/BusinessServiceUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessServiceUser>>> GetBusinessServiceUsers()
        {
            return await _context.BusinessServiceUsers.ToListAsync();
        }

        // GET: api/BusinessServiceUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessServiceUser>> GetBusinessServiceUser(int id)
        {
            var businessServiceUser = await _context.BusinessServiceUsers.FindAsync(id);

            if (businessServiceUser == null)
            {
                return NotFound();
            }

            return businessServiceUser;
        }

        // PUT: api/BusinessServiceUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessServiceUser(int id, BusinessServiceUser businessServiceUser)
        {
            if (id != businessServiceUser.BusinessServiceId)
            {
                return BadRequest();
            }

            _context.Entry(businessServiceUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessServiceUserExists(id))
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

        // POST: api/BusinessServiceUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessServiceUser>> PostBusinessServiceUser(BusinessServiceUser businessServiceUser)
        {
            _context.BusinessServiceUsers.Add(businessServiceUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusinessServiceUserExists(businessServiceUser.BusinessServiceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBusinessServiceUser", new { id = businessServiceUser.BusinessServiceId }, businessServiceUser);
        }

        // DELETE: api/BusinessServiceUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessServiceUser(int id)
        {
            var businessServiceUser = await _context.BusinessServiceUsers.FindAsync(id);
            if (businessServiceUser == null)
            {
                return NotFound();
            }

            _context.BusinessServiceUsers.Remove(businessServiceUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessServiceUserExists(int id)
        {
            return _context.BusinessServiceUsers.Any(e => e.BusinessServiceId == id);
        }
    }
}
