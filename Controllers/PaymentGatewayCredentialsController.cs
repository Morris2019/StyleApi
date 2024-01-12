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
    public class PaymentGatewayCredentialsController : ControllerBase
    {
        private readonly urbanstyleContext _context;

        public PaymentGatewayCredentialsController(urbanstyleContext context)
        {
            _context = context;
        }

        // GET: api/PaymentGatewayCredentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentGatewayCredential>>> GetPaymentGatewayCredentials()
        {
            return await _context.PaymentGatewayCredentials.ToListAsync();
        }

        // GET: api/PaymentGatewayCredentials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentGatewayCredential>> GetPaymentGatewayCredential(int id)
        {
            var paymentGatewayCredential = await _context.PaymentGatewayCredentials.FindAsync(id);

            if (paymentGatewayCredential == null)
            {
                return NotFound();
            }

            return paymentGatewayCredential;
        }

        // PUT: api/PaymentGatewayCredentials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentGatewayCredential(int id, PaymentGatewayCredential paymentGatewayCredential)
        {
            if (id != paymentGatewayCredential.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentGatewayCredential).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentGatewayCredentialExists(id))
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

        // POST: api/PaymentGatewayCredentials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentGatewayCredential>> PostPaymentGatewayCredential(PaymentGatewayCredential paymentGatewayCredential)
        {
            _context.PaymentGatewayCredentials.Add(paymentGatewayCredential);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentGatewayCredential", new { id = paymentGatewayCredential.Id }, paymentGatewayCredential);
        }

        // DELETE: api/PaymentGatewayCredentials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentGatewayCredential(int id)
        {
            var paymentGatewayCredential = await _context.PaymentGatewayCredentials.FindAsync(id);
            if (paymentGatewayCredential == null)
            {
                return NotFound();
            }

            _context.PaymentGatewayCredentials.Remove(paymentGatewayCredential);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentGatewayCredentialExists(int id)
        {
            return _context.PaymentGatewayCredentials.Any(e => e.Id == id);
        }
    }
}
