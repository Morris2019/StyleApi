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
    public class EmployeeGroupServicesController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public EmployeeGroupServicesController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeGroupServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeGroupService>>> GetEmployeeGroupServices()
        {
            return await _context.EmployeeGroupServices.ToListAsync();
        }

        // GET: api/EmployeeGroupServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGroupService>> GetEmployeeGroupService(long id)
        {
            var employeeGroupService = await _context.EmployeeGroupServices.FindAsync(id);

            if (employeeGroupService == null)
            {
                return NotFound();
            }

            return employeeGroupService;
        }

        // PUT: api/EmployeeGroupServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeGroupService(long id, EmployeeGroupService employeeGroupService)
        {
            if (id != employeeGroupService.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeGroupService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeGroupServiceExists(id))
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

        // POST: api/EmployeeGroupServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeGroupService>> PostEmployeeGroupService(EmployeeGroupService employeeGroupService)
        {
            _context.EmployeeGroupServices.Add(employeeGroupService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeGroupService", new { id = employeeGroupService.Id }, employeeGroupService);
        }

        // DELETE: api/EmployeeGroupServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeGroupService(long id)
        {
            var employeeGroupService = await _context.EmployeeGroupServices.FindAsync(id);
            if (employeeGroupService == null)
            {
                return NotFound();
            }

            _context.EmployeeGroupServices.Remove(employeeGroupService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeGroupServiceExists(long id)
        {
            return _context.EmployeeGroupServices.Any(e => e.Id == id);
        }
    }
}
