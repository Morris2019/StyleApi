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
    public class TaxSettingsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public TaxSettingsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/TaxSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxSetting>>> GetTaxSettings()
        {
            return await _context.TaxSettings.ToListAsync();
        }

        // GET: api/TaxSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxSetting>> GetTaxSetting(int id)
        {
            var taxSetting = await _context.TaxSettings.FindAsync(id);

            if (taxSetting == null)
            {
                return NotFound();
            }

            return taxSetting;
        }

        // PUT: api/TaxSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxSetting(int id, TaxSetting taxSetting)
        {
            if (id != taxSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxSettingExists(id))
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

        // POST: api/TaxSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxSetting>> PostTaxSetting(TaxSetting taxSetting)
        {
            _context.TaxSettings.Add(taxSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxSetting", new { id = taxSetting.Id }, taxSetting);
        }

        // DELETE: api/TaxSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxSetting(int id)
        {
            var taxSetting = await _context.TaxSettings.FindAsync(id);
            if (taxSetting == null)
            {
                return NotFound();
            }

            _context.TaxSettings.Remove(taxSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxSettingExists(int id)
        {
            return _context.TaxSettings.Any(e => e.Id == id);
        }
    }
}
