using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceDeskApi.Models;

namespace ServiceDeskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTablesController : ControllerBase
    {
        private readonly Capstone1Context _context;

        public StatusTablesController(Capstone1Context context)
        {
            _context = context;
        }

        // GET: api/StatusTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusTable>>> GetStatusTables()
        {
            return await _context.StatusTables.ToListAsync();
        }

        // GET: api/StatusTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusTable>> GetStatusTable(int id)
        {
            var statusTable = await _context.StatusTables.FindAsync(id);

            if (statusTable == null)
            {
                return NotFound();
            }

            return statusTable;
        }

        // PUT: api/StatusTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusTable(int id, StatusTable statusTable)
        {
            if (id != statusTable.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(statusTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusTableExists(id))
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

        // POST: api/StatusTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusTable>> PostStatusTable(StatusTable statusTable)
        {
            _context.StatusTables.Add(statusTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatusTableExists(statusTable.StatusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStatusTable", new { id = statusTable.StatusId }, statusTable);
        }

        // DELETE: api/StatusTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusTable(int id)
        {
            var statusTable = await _context.StatusTables.FindAsync(id);
            if (statusTable == null)
            {
                return NotFound();
            }

            _context.StatusTables.Remove(statusTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusTableExists(int id)
        {
            return _context.StatusTables.Any(e => e.StatusId == id);
        }
    }
}
