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
    public class SmtpSettingsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public SmtpSettingsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/SmtpSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmtpSetting>>> GetSmtpSettings()
        {
            return await _context.SmtpSettings.ToListAsync();
        }

        // GET: api/SmtpSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmtpSetting>> GetSmtpSetting(int id)
        {
            var smtpSetting = await _context.SmtpSettings.FindAsync(id);

            if (smtpSetting == null)
            {
                return NotFound();
            }

            return smtpSetting;
        }

        // PUT: api/SmtpSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmtpSetting(int id, SmtpSetting smtpSetting)
        {
            if (id != smtpSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(smtpSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmtpSettingExists(id))
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

        // POST: api/SmtpSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmtpSetting>> PostSmtpSetting(SmtpSetting smtpSetting)
        {
            _context.SmtpSettings.Add(smtpSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmtpSetting", new { id = smtpSetting.Id }, smtpSetting);
        }

        // DELETE: api/SmtpSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmtpSetting(int id)
        {
            var smtpSetting = await _context.SmtpSettings.FindAsync(id);
            if (smtpSetting == null)
            {
                return NotFound();
            }

            _context.SmtpSettings.Remove(smtpSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmtpSettingExists(int id)
        {
            return _context.SmtpSettings.Any(e => e.Id == id);
        }
    }
}
