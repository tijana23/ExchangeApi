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
    public class OfficialRatesController : ControllerBase
    {
        private readonly ExchangeOfficeContext _context;

        public OfficialRatesController(ExchangeOfficeContext context)
        {
            _context = context;
        }

        // GET: api/OfficialRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficialRates>>> GetOfficialRates()
        {
            return await _context.OfficialRates.ToListAsync();
        }

        // GET: api/OfficialRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficialRates>> GetOfficialRates(int id)
        {
            var officialRates = await _context.OfficialRates.FindAsync(id);

            if (officialRates == null)
            {
                return NotFound();
            }

            return officialRates;
        }

        // PUT: api/OfficialRates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficialRates(int id, OfficialRates officialRates)
        {
            if (id != officialRates.OfficialRatesId)
            {
                return BadRequest();
            }

            _context.Entry(officialRates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficialRatesExists(id))
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

        // POST: api/OfficialRates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OfficialRates>> PostOfficialRates(OfficialRates officialRates)
        {
            _context.OfficialRates.Add(officialRates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficialRates", new { id = officialRates.OfficialRatesId }, officialRates);
        }

        // DELETE: api/OfficialRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfficialRates>> DeleteOfficialRates(int id)
        {
            var officialRates = await _context.OfficialRates.FindAsync(id);
            if (officialRates == null)
            {
                return NotFound();
            }

            _context.OfficialRates.Remove(officialRates);
            await _context.SaveChangesAsync();

            return officialRates;
        }

        private bool OfficialRatesExists(int id)
        {
            return _context.OfficialRates.Any(e => e.OfficialRatesId == id);
        }
    }
}
