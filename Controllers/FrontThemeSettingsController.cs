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
    public class FrontThemeSettingsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public FrontThemeSettingsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/FrontThemeSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrontThemeSetting>>> GetFrontThemeSettings()
        {
            return await _context.FrontThemeSettings.ToListAsync();
        }

        // GET: api/FrontThemeSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FrontThemeSetting>> GetFrontThemeSetting(int id)
        {
            var frontThemeSetting = await _context.FrontThemeSettings.FindAsync(id);

            if (frontThemeSetting == null)
            {
                return NotFound();
            }

            return frontThemeSetting;
        }

        // PUT: api/FrontThemeSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrontThemeSetting(int id, FrontThemeSetting frontThemeSetting)
        {
            if (id != frontThemeSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(frontThemeSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrontThemeSettingExists(id))
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

        // POST: api/FrontThemeSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FrontThemeSetting>> PostFrontThemeSetting(FrontThemeSetting frontThemeSetting)
        {
            _context.FrontThemeSettings.Add(frontThemeSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrontThemeSetting", new { id = frontThemeSetting.Id }, frontThemeSetting);
        }

        // DELETE: api/FrontThemeSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrontThemeSetting(int id)
        {
            var frontThemeSetting = await _context.FrontThemeSettings.FindAsync(id);
            if (frontThemeSetting == null)
            {
                return NotFound();
            }

            _context.FrontThemeSettings.Remove(frontThemeSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FrontThemeSettingExists(int id)
        {
            return _context.FrontThemeSettings.Any(e => e.Id == id);
        }
    }
}
