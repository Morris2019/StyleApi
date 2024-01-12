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
    public class PermissionRolesController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public PermissionRolesController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/PermissionRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionRole>>> GetPermissionRoles()
        {
            return await _context.PermissionRoles.ToListAsync();
        }

        // GET: api/PermissionRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionRole>> GetPermissionRole(int id)
        {
            var permissionRole = await _context.PermissionRoles.FindAsync(id);

            if (permissionRole == null)
            {
                return NotFound();
            }

            return permissionRole;
        }

        // PUT: api/PermissionRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissionRole(int id, PermissionRole permissionRole)
        {
            if (id != permissionRole.PermissionId)
            {
                return BadRequest();
            }

            _context.Entry(permissionRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionRoleExists(id))
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

        // POST: api/PermissionRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PermissionRole>> PostPermissionRole(PermissionRole permissionRole)
        {
            _context.PermissionRoles.Add(permissionRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PermissionRoleExists(permissionRole.PermissionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPermissionRole", new { id = permissionRole.PermissionId }, permissionRole);
        }

        // DELETE: api/PermissionRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionRole(int id)
        {
            var permissionRole = await _context.PermissionRoles.FindAsync(id);
            if (permissionRole == null)
            {
                return NotFound();
            }

            _context.PermissionRoles.Remove(permissionRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionRoleExists(int id)
        {
            return _context.PermissionRoles.Any(e => e.PermissionId == id);
        }
    }
}
