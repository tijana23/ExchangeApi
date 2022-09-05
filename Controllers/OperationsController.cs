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
    public class OperationsController : ControllerBase
    {
        private readonly ExchangeOfficeContext _context;

        public OperationsController(ExchangeOfficeContext context)
        {
            _context = context;
        }

        // GET: api/Operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operations>>> GetOperations()
        {
            return await _context.Operations.ToListAsync();
        }

        // GET: api/Operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operations>> GetOperations(int id)
        {
            var operations = await _context.Operations.FindAsync(id);

            if (operations == null)
            {
                return NotFound();
            }

            return operations;
        }

        // PUT: api/Operations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperations(int id, Operations operations)
        {
            if (id != operations.OperationId)
            {
                return BadRequest();
            }

            _context.Entry(operations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationsExists(id))
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

        // POST: api/Operations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Operations>> PostOperations(Operations operations)
        {
            _context.Operations.Add(operations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperations", new { id = operations.OperationId }, operations);
        }

        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operations>> DeleteOperations(int id)
        {
            var operations = await _context.Operations.FindAsync(id);
            if (operations == null)
            {
                return NotFound();
            }

            _context.Operations.Remove(operations);
            await _context.SaveChangesAsync();

            return operations;
        }

        private bool OperationsExists(int id)
        {
            return _context.Operations.Any(e => e.OperationId == id);
        }
    }
}
