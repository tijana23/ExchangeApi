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
    public class ClsCurrenciesController : ControllerBase
    {
        private readonly ExchangeOfficeContext _context;

        public ClsCurrenciesController(ExchangeOfficeContext context)
        {
            _context = context;
        }

        // GET: api/ClsCurrencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClsCurrency>>> GetClsCurrency()
        {
            return await _context.ClsCurrency.ToListAsync();
        }

        // GET: api/ClsCurrencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClsCurrency>> GetClsCurrency(int id)
        {
            var clsCurrency = await _context.ClsCurrency.FindAsync(id);

            if (clsCurrency == null)
            {
                return NotFound();
            }

            return clsCurrency;
        }

        // PUT: api/ClsCurrencies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClsCurrency(int id, ClsCurrency clsCurrency)
        {
            if (id != clsCurrency.CurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(clsCurrency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsCurrencyExists(id))
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

        // POST: api/ClsCurrencies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClsCurrency>> PostClsCurrency(ClsCurrency clsCurrency)
        {
            _context.ClsCurrency.Add(clsCurrency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClsCurrency", new { id = clsCurrency.CurrencyId }, clsCurrency);
        }

        // DELETE: api/ClsCurrencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClsCurrency>> DeleteClsCurrency(int id)
        {
            var clsCurrency = await _context.ClsCurrency.FindAsync(id);
            if (clsCurrency == null)
            {
                return NotFound();
            }

            _context.ClsCurrency.Remove(clsCurrency);
            await _context.SaveChangesAsync();

            return clsCurrency;
        }

        private bool ClsCurrencyExists(int id)
        {
            return _context.ClsCurrency.Any(e => e.CurrencyId == id);
        }
    }
}
