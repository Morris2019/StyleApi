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
    public class EmployeeGroupsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public EmployeeGroupsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeGroup>>> GetEmployeeGroups()
        {
            return await _context.EmployeeGroups.ToListAsync();
        }

        // GET: api/EmployeeGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGroup>> GetEmployeeGroup(int id)
        {
            var employeeGroup = await _context.EmployeeGroups.FindAsync(id);

            if (employeeGroup == null)
            {
                return NotFound();
            }

            return employeeGroup;
        }

        // PUT: api/EmployeeGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeGroup(int id, EmployeeGroup employeeGroup)
        {
            if (id != employeeGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeGroupExists(id))
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

        // POST: api/EmployeeGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeGroup>> PostEmployeeGroup(EmployeeGroup employeeGroup)
        {
            _context.EmployeeGroups.Add(employeeGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeGroup", new { id = employeeGroup.Id }, employeeGroup);
        }

        // DELETE: api/EmployeeGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeGroup(int id)
        {
            var employeeGroup = await _context.EmployeeGroups.FindAsync(id);
            if (employeeGroup == null)
            {
                return NotFound();
            }

            _context.EmployeeGroups.Remove(employeeGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeGroupExists(int id)
        {
            return _context.EmployeeGroups.Any(e => e.Id == id);
        }
    }
}
