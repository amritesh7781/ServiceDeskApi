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
    public class TicketTablesController : ControllerBase
    {
        private readonly Capstone1Context _context;

        public TicketTablesController(Capstone1Context context)
        {
            _context = context;
        }

        // GET: api/TicketTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketTable>>> GetTicketTables()
        {
            return await _context.TicketTables.ToListAsync();
        }

        // GET: api/TicketTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketTable>> GetTicketTable(int id)
        {
            var ticketTable = await _context.TicketTables.FindAsync(id);

            if (ticketTable == null)
            {
                return NotFound();
            }

            return ticketTable;
        }

        // PUT: api/TicketTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketTable(int id, TicketTable ticketTable)
        {
            if (id != ticketTable.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(ticketTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketTableExists(id))
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

        // POST: api/TicketTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketTable>> PostTicketTable(TicketTable ticketTable)
        {
            _context.TicketTables.Add(ticketTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketTableExists(ticketTable.TicketId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTicketTable", new { id = ticketTable.TicketId }, ticketTable);
        }

        // DELETE: api/TicketTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketTable(int id)
        {
            var ticketTable = await _context.TicketTables.FindAsync(id);
            if (ticketTable == null)
            {
                return NotFound();
            }

            _context.TicketTables.Remove(ticketTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketTableExists(int id)
        {
            return _context.TicketTables.Any(e => e.TicketId == id);
        }
    }
}
