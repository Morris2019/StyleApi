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
    public class LtmTranslationsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public LtmTranslationsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/LtmTranslations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LtmTranslation>>> GetLtmTranslations()
        {
            return await _context.LtmTranslations.ToListAsync();
        }

        // GET: api/LtmTranslations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LtmTranslation>> GetLtmTranslation(int id)
        {
            var ltmTranslation = await _context.LtmTranslations.FindAsync(id);

            if (ltmTranslation == null)
            {
                return NotFound();
            }

            return ltmTranslation;
        }

        // PUT: api/LtmTranslations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLtmTranslation(int id, LtmTranslation ltmTranslation)
        {
            if (id != ltmTranslation.Id)
            {
                return BadRequest();
            }

            _context.Entry(ltmTranslation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LtmTranslationExists(id))
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

        // POST: api/LtmTranslations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LtmTranslation>> PostLtmTranslation(LtmTranslation ltmTranslation)
        {
            _context.LtmTranslations.Add(ltmTranslation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLtmTranslation", new { id = ltmTranslation.Id }, ltmTranslation);
        }

        // DELETE: api/LtmTranslations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLtmTranslation(int id)
        {
            var ltmTranslation = await _context.LtmTranslations.FindAsync(id);
            if (ltmTranslation == null)
            {
                return NotFound();
            }

            _context.LtmTranslations.Remove(ltmTranslation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LtmTranslationExists(int id)
        {
            return _context.LtmTranslations.Any(e => e.Id == id);
        }
    }
}
