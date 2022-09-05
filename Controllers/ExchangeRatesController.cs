using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExchangeWebApi.Data;

namespace ExchangeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly ExchangeOfficeContext _context;

        public ExchangeRatesController(ExchangeOfficeContext context)
        {
            _context = context;
        }

        // GET: api/ExchangeRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExchangeRates>>> GetExchangeRates()
        {
            return await _context.ExchangeRates.ToListAsync();
        }

        // GET: api/ExchangeRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExchangeRates>> GetExchangeRates(int id)
        {
            var exchangeRates = await _context.ExchangeRates.FindAsync(id);

            if (exchangeRates == null)
            {
                return NotFound();
            }

            return exchangeRates;
        }

        // PUT: api/ExchangeRates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExchangeRates(int id, ExchangeRates exchangeRates)
        {
            if (id != exchangeRates.ExchangeRatesId)
            {
                return BadRequest();
            }

            _context.Entry(exchangeRates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeRatesExists(id))
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

        // POST: api/ExchangeRates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExchangeRates>> PostExchangeRates(ExchangeRates exchangeRates)
        {
            _context.ExchangeRates.Add(exchangeRates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExchangeRates", new { id = exchangeRates.ExchangeRatesId }, exchangeRates);
        }

        // DELETE: api/ExchangeRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExchangeRates>> DeleteExchangeRates(int id)
        {
            var exchangeRates = await _context.ExchangeRates.FindAsync(id);
            if (exchangeRates == null)
            {
                return NotFound();
            }

            _context.ExchangeRates.Remove(exchangeRates);
            await _context.SaveChangesAsync();

            return exchangeRates;
        }

        private bool ExchangeRatesExists(int id)
        {
            return _context.ExchangeRates.Any(e => e.ExchangeRatesId == id);
        }
    }
}
