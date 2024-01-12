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
    public class PermissionUsersController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public PermissionUsersController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/PermissionUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionUser>>> GetPermissionUsers()
        {
            return await _context.PermissionUsers.ToListAsync();
        }

        // GET: api/PermissionUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionUser>> GetPermissionUser(int id)
        {
            var permissionUser = await _context.PermissionUsers.FindAsync(id);

            if (permissionUser == null)
            {
                return NotFound();
            }

            return permissionUser;
        }

        // PUT: api/PermissionUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissionUser(int id, PermissionUser permissionUser)
        {
            if (id != permissionUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(permissionUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionUserExists(id))
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

        // POST: api/PermissionUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PermissionUser>> PostPermissionUser(PermissionUser permissionUser)
        {
            _context.PermissionUsers.Add(permissionUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PermissionUserExists(permissionUser.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPermissionUser", new { id = permissionUser.UserId }, permissionUser);
        }

        // DELETE: api/PermissionUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionUser(int id)
        {
            var permissionUser = await _context.PermissionUsers.FindAsync(id);
            if (permissionUser == null)
            {
                return NotFound();
            }

            _context.PermissionUsers.Remove(permissionUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionUserExists(int id)
        {
            return _context.PermissionUsers.Any(e => e.UserId == id);
        }
    }
}
