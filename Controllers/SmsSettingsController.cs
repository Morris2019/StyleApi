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
    public class SmsSettingsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public SmsSettingsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/SmsSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmsSetting>>> GetSmsSettings()
        {
            return await _context.SmsSettings.ToListAsync();
        }

        // GET: api/SmsSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmsSetting>> GetSmsSetting(long id)
        {
            var smsSetting = await _context.SmsSettings.FindAsync(id);

            if (smsSetting == null)
            {
                return NotFound();
            }

            return smsSetting;
        }

        // PUT: api/SmsSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmsSetting(long id, SmsSetting smsSetting)
        {
            if (id != smsSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(smsSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmsSettingExists(id))
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

        // POST: api/SmsSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmsSetting>> PostSmsSetting(SmsSetting smsSetting)
        {
            _context.SmsSettings.Add(smsSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmsSetting", new { id = smsSetting.Id }, smsSetting);
        }

        // DELETE: api/SmsSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmsSetting(long id)
        {
            var smsSetting = await _context.SmsSettings.FindAsync(id);
            if (smsSetting == null)
            {
                return NotFound();
            }

            _context.SmsSettings.Remove(smsSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmsSettingExists(long id)
        {
            return _context.SmsSettings.Any(e => e.Id == id);
        }
    }
}
