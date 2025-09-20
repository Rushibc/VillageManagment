 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillageManagement.Data;
using VillageManagement.Models;

namespace VillageManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarriageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MarriageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/marriage
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<MarriageRecord>>> GetAll()
        {
            return await _context.MarriageRecords.ToListAsync();
        }

        // GET: api/marriage/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<MarriageRecord>> GetById(int id)
        {
            var record = await _context.MarriageRecords.FindAsync(id);
            if (record == null)
                return NotFound();

            return record;
        }

        // POST: api/marriage
        [HttpPost("Create")]
        public async Task<ActionResult<MarriageRecord>> Create(MarriageRecord record)
        {
            _context.MarriageRecords.Add(record);
            _context.SaveChangesAsync(); // Now model.Id is populated

            // Step 2: Generate CertificateNumber using the new Id
            record.CertificateNumber = $"CERT-{record.Id:D5}";

            // Step 3: Update the record with the certificate number
            _context.MarriageRecords.Update(record);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
        }

        // DELETE: api/marriage/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.MarriageRecords.FindAsync(id);
            if (record == null)
                return NotFound();

            _context.MarriageRecords.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/marriage/search?name=...
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MarriageRecord>>> Search([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await _context.MarriageRecords.ToListAsync();

            return await _context.MarriageRecords
                .Where(r =>
                    r.GroomName.Contains(name) ||
                    r.BrideName.Contains(name))
                .ToListAsync();
        }
    }
}
