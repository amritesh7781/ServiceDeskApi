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
    public class DepartmentTablesController : ControllerBase
    {
        private readonly Capstone1Context _context;

        public DepartmentTablesController(Capstone1Context context)
        {
            _context = context;
        }

        // GET: api/DepartmentTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentTable>>> GetDepartmentTables()
        {
            return await _context.DepartmentTables.ToListAsync();
        }

        // GET: api/DepartmentTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentTable>> GetDepartmentTable(int id)
        {
            var departmentTable = await _context.DepartmentTables.FindAsync(id);

            if (departmentTable == null)
            {
                return NotFound();
            }

            return departmentTable;
        }

        // PUT: api/DepartmentTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentTable(int id, DepartmentTable departmentTable)
        {
            if (id != departmentTable.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(departmentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentTableExists(id))
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

        // POST: api/DepartmentTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentTable>> PostDepartmentTable(DepartmentTable departmentTable)
        {
            _context.DepartmentTables.Add(departmentTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartmentTableExists(departmentTable.DepartmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepartmentTable", new { id = departmentTable.DepartmentId }, departmentTable);
        }

        // DELETE: api/DepartmentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentTable(int id)
        {
            var departmentTable = await _context.DepartmentTables.FindAsync(id);
            if (departmentTable == null)
            {
                return NotFound();
            }

            _context.DepartmentTables.Remove(departmentTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentTableExists(int id)
        {
            return _context.DepartmentTables.Any(e => e.DepartmentId == id);
        }
    }
}
