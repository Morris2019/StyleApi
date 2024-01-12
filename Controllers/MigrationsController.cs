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
    public class MigrationsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public MigrationsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/Migrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Migration>>> GetMigrations()
        {
            return await _context.Migrations.ToListAsync();
        }

        // GET: api/Migrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Migration>> GetMigration(int id)
        {
            var migration = await _context.Migrations.FindAsync(id);

            if (migration == null)
            {
                return NotFound();
            }

            return migration;
        }

        // PUT: api/Migrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMigration(int id, Migration migration)
        {
            if (id != migration.Id)
            {
                return BadRequest();
            }

            _context.Entry(migration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MigrationExists(id))
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

        // POST: api/Migrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Migration>> PostMigration(Migration migration)
        {
            _context.Migrations.Add(migration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMigration", new { id = migration.Id }, migration);
        }

        // DELETE: api/Migrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMigration(int id)
        {
            var migration = await _context.Migrations.FindAsync(id);
            if (migration == null)
            {
                return NotFound();
            }

            _context.Migrations.Remove(migration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MigrationExists(int id)
        {
            return _context.Migrations.Any(e => e.Id == id);
        }
    }
}
