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
    public class UniversalSearchesController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public UniversalSearchesController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/UniversalSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversalSearch>>> GetUniversalSearches()
        {
            return await _context.UniversalSearches.ToListAsync();
        }

        // GET: api/UniversalSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UniversalSearch>> GetUniversalSearch(long id)
        {
            var universalSearch = await _context.UniversalSearches.FindAsync(id);

            if (universalSearch == null)
            {
                return NotFound();
            }

            return universalSearch;
        }

        // PUT: api/UniversalSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversalSearch(long id, UniversalSearch universalSearch)
        {
            if (id != universalSearch.Id)
            {
                return BadRequest();
            }

            _context.Entry(universalSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversalSearchExists(id))
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

        // POST: api/UniversalSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UniversalSearch>> PostUniversalSearch(UniversalSearch universalSearch)
        {
            _context.UniversalSearches.Add(universalSearch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversalSearch", new { id = universalSearch.Id }, universalSearch);
        }

        // DELETE: api/UniversalSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversalSearch(long id)
        {
            var universalSearch = await _context.UniversalSearches.FindAsync(id);
            if (universalSearch == null)
            {
                return NotFound();
            }

            _context.UniversalSearches.Remove(universalSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversalSearchExists(long id)
        {
            return _context.UniversalSearches.Any(e => e.Id == id);
        }
    }
}
