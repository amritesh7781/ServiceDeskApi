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
    public class GroupTablesController : ControllerBase
    {
        private readonly Capstone1Context _context;

        public GroupTablesController(Capstone1Context context)
        {
            _context = context;
        }

        // GET: api/GroupTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupTable>>> GetGroupTables()
        {
            return await _context.GroupTables.ToListAsync();
        }

        // GET: api/GroupTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTable>> GetGroupTable(int id)
        {
            var groupTable = await _context.GroupTables.FindAsync(id);

            if (groupTable == null)
            {
                return NotFound();
            }

            return groupTable;
        }

        // PUT: api/GroupTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupTable(int id, GroupTable groupTable)
        {
            if (id != groupTable.GroupId)
            {
                return BadRequest();
            }

            _context.Entry(groupTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupTableExists(id))
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

        // POST: api/GroupTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupTable>> PostGroupTable(GroupTable groupTable)
        {
            _context.GroupTables.Add(groupTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupTableExists(groupTable.GroupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGroupTable", new { id = groupTable.GroupId }, groupTable);
        }

        // DELETE: api/GroupTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupTable(int id)
        {
            var groupTable = await _context.GroupTables.FindAsync(id);
            if (groupTable == null)
            {
                return NotFound();
            }

            _context.GroupTables.Remove(groupTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupTableExists(int id)
        {
            return _context.GroupTables.Any(e => e.GroupId == id);
        }
    }
}
