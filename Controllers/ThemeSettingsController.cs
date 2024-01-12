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
    public class ThemeSettingsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public ThemeSettingsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/ThemeSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThemeSetting>>> GetThemeSettings()
        {
            return await _context.ThemeSettings.ToListAsync();
        }

        // GET: api/ThemeSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThemeSetting>> GetThemeSetting(int id)
        {
            var themeSetting = await _context.ThemeSettings.FindAsync(id);

            if (themeSetting == null)
            {
                return NotFound();
            }

            return themeSetting;
        }

        // PUT: api/ThemeSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThemeSetting(int id, ThemeSetting themeSetting)
        {
            if (id != themeSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(themeSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeSettingExists(id))
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

        // POST: api/ThemeSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThemeSetting>> PostThemeSetting(ThemeSetting themeSetting)
        {
            _context.ThemeSettings.Add(themeSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThemeSetting", new { id = themeSetting.Id }, themeSetting);
        }

        // DELETE: api/ThemeSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThemeSetting(int id)
        {
            var themeSetting = await _context.ThemeSettings.FindAsync(id);
            if (themeSetting == null)
            {
                return NotFound();
            }

            _context.ThemeSettings.Remove(themeSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThemeSettingExists(int id)
        {
            return _context.ThemeSettings.Any(e => e.Id == id);
        }
    }
}
