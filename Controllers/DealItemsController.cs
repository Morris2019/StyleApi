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
    public class DealItemsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public DealItemsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/DealItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealItem>>> GetDealItems()
        {
            return await _context.DealItems.ToListAsync();
        }

        // GET: api/DealItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DealItem>> GetDealItem(int id)
        {
            var dealItem = await _context.DealItems.FindAsync(id);

            if (dealItem == null)
            {
                return NotFound();
            }

            return dealItem;
        }

        // PUT: api/DealItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealItem(int id, DealItem dealItem)
        {
            if (id != dealItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(dealItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealItemExists(id))
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

        // POST: api/DealItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DealItem>> PostDealItem(DealItem dealItem)
        {
            _context.DealItems.Add(dealItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDealItem", new { id = dealItem.Id }, dealItem);
        }

        // DELETE: api/DealItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealItem(int id)
        {
            var dealItem = await _context.DealItems.FindAsync(id);
            if (dealItem == null)
            {
                return NotFound();
            }

            _context.DealItems.Remove(dealItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealItemExists(int id)
        {
            return _context.DealItems.Any(e => e.Id == id);
        }
    }
}
