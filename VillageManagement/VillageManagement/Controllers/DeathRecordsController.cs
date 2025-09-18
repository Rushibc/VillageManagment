using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillageManagement.Data;
using VillageManagement.Models;

namespace VillageManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeathRecordsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeathRecordsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/DeathRecords
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<DeathRecord>>> GetAll(string? name = null)
        {
            var query = _context.DeathRecords.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(dr => dr.FullName.Contains(name));
            }

            return await query.ToListAsync();
        }

        // ✅ GET: api/DeathRecords/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<DeathRecord>> GetById(int id)
        {
            var record = await _context.DeathRecords.FindAsync(id);
            if (record == null)
                return NotFound();

            return record;
        }

        // ✅ POST: api/DeathRecords
        [HttpPost("Create")]
        public async Task<ActionResult<DeathRecord>> Create([FromBody] DeathRecord deathRecord)
        {
            _context.DeathRecords.Add(deathRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = deathRecord.Id }, deathRecord);
        }

        // ✅ DELETE: api/DeathRecords/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.DeathRecords.FindAsync(id);
            if (record == null)
                return NotFound();

            _context.DeathRecords.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
