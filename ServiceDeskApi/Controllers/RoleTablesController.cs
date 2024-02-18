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
    public class RoleTablesController : ControllerBase
    {
        private readonly Capstone1Context _context;

        public RoleTablesController(Capstone1Context context)
        {
            _context = context;
        }

        // GET: api/RoleTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleTable>>> GetRoleTables()
        {
            return await _context.RoleTables.ToListAsync();
        }

        // GET: api/RoleTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleTable>> GetRoleTable(int id)
        {
            var roleTable = await _context.RoleTables.FindAsync(id);

            if (roleTable == null)
            {
                return NotFound();
            }

            return roleTable;
        }

        // PUT: api/RoleTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleTable(int id, RoleTable roleTable)
        {
            if (id != roleTable.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(roleTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleTableExists(id))
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

        // POST: api/RoleTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleTable>> PostRoleTable(RoleTable roleTable)
        {
            _context.RoleTables.Add(roleTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleTableExists(roleTable.RoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoleTable", new { id = roleTable.RoleId }, roleTable);
        }

        // DELETE: api/RoleTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleTable(int id)
        {
            var roleTable = await _context.RoleTables.FindAsync(id);
            if (roleTable == null)
            {
                return NotFound();
            }

            _context.RoleTables.Remove(roleTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleTableExists(int id)
        {
            return _context.RoleTables.Any(e => e.RoleId == id);
        }
    }
}
