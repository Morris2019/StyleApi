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
    public class CompanySettingsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public CompanySettingsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/CompanySettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanySetting>>> GetCompanySettings()
        {
            return await _context.CompanySettings.ToListAsync();
        }

        // GET: api/CompanySettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanySetting>> GetCompanySetting(int id)
        {
            var companySetting = await _context.CompanySettings.FindAsync(id);

            if (companySetting == null)
            {
                return NotFound();
            }

            return companySetting;
        }

        // PUT: api/CompanySettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanySetting(int id, CompanySetting companySetting)
        {
            if (id != companySetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(companySetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanySettingExists(id))
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

        // POST: api/CompanySettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanySetting>> PostCompanySetting(CompanySetting companySetting)
        {
            _context.CompanySettings.Add(companySetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanySetting", new { id = companySetting.Id }, companySetting);
        }

        // DELETE: api/CompanySettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanySetting(int id)
        {
            var companySetting = await _context.CompanySettings.FindAsync(id);
            if (companySetting == null)
            {
                return NotFound();
            }

            _context.CompanySettings.Remove(companySetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanySettingExists(int id)
        {
            return _context.CompanySettings.Any(e => e.Id == id);
        }
    }
}
