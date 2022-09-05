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
    public class ClsOperationTypesController : ControllerBase
    {
        private readonly ExchangeOfficeContext _context;

        public ClsOperationTypesController(ExchangeOfficeContext context)
        {
            _context = context;
        }

        // GET: api/ClsOperationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClsOperationType>>> GetClsOperationType()
        {
            return await _context.ClsOperationType.ToListAsync();
        }

        // GET: api/ClsOperationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClsOperationType>> GetClsOperationType(int id)
        {
            var clsOperationType = await _context.ClsOperationType.FindAsync(id);

            if (clsOperationType == null)
            {
                return NotFound();
            }

            return clsOperationType;
        }

        // PUT: api/ClsOperationTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClsOperationType(int id, ClsOperationType clsOperationType)
        {
            if (id != clsOperationType.OperationTypeId)
            {
                return BadRequest();
            }

            _context.Entry(clsOperationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsOperationTypeExists(id))
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

        // POST: api/ClsOperationTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClsOperationType>> PostClsOperationType(ClsOperationType clsOperationType)
        {
            _context.ClsOperationType.Add(clsOperationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClsOperationType", new { id = clsOperationType.OperationTypeId }, clsOperationType);
        }

        // DELETE: api/ClsOperationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClsOperationType>> DeleteClsOperationType(int id)
        {
            var clsOperationType = await _context.ClsOperationType.FindAsync(id);
            if (clsOperationType == null)
            {
                return NotFound();
            }

            _context.ClsOperationType.Remove(clsOperationType);
            await _context.SaveChangesAsync();

            return clsOperationType;
        }

        private bool ClsOperationTypeExists(int id)
        {
            return _context.ClsOperationType.Any(e => e.OperationTypeId == id);
        }
    }
}
