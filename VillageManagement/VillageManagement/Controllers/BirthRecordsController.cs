using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillageManagement.Data;
using VillageManagement.DTO.BirthRegistryAPI.DTOs;
using VillageManagement.DTO;
using VillageManagement.Models;

namespace VillageManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BirthRecordsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BirthRecordsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BirthRecords
        [HttpGet("GetBirthRecord")]
        public async Task<ActionResult<IEnumerable<BirthRecord>>> GetBirthRecords()
        {
            return await _context.BirthRecords.ToListAsync();
        }

        // GET: api/BirthRecords/5
        [HttpGet("GetBirthRecordById/{id}")]
        public async Task<ActionResult<BirthRecord>> GetBirthRecord(int id)
        {
            var birthRecord = await _context.BirthRecords.FindAsync(id);

            if (birthRecord == null)
            {
                return NotFound();
            }

            return birthRecord;
        }

        // PUT: api/BirthRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutBirthRecord/{id}")]
        public async Task<IActionResult> PutBirthRecord(int id, BirthRecord birthRecord)
        {
            if (id != birthRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(birthRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirthRecordExists(id))
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

        // POST: api/BirthRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<BirthRecord>> Create(BirthRecord input)
        //{
        //    input.Id = 0; // 👈 Force it to be zero so EF lets SQL generate the ID

        //    _context.BirthRecords.Add(input);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetBirthRecord), new { id = input.Id }, input);
        //}


        // DELETE: api/BirthRecords/5
        [HttpDelete("DeleteBirthRecord/{id}")]
        public async Task<IActionResult> DeleteBirthRecord(int id)
        {
            var birthRecord = await _context.BirthRecords.FindAsync(id);
            if (birthRecord == null)
            {
                return NotFound();
            }

            _context.BirthRecords.Remove(birthRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("CreateBirthRecord")]
        public async Task<ActionResult<BirthRecordReadDto>> Create([FromBody] BirthRecordCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var birthRecord = new BirthRecord
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                PlaceOfBirth = dto.PlaceOfBirth,
                FatherName = dto.FatherName,
                MotherName = dto.MotherName,
                Address = dto.Address,
                RegisteredBy = dto.RegisteredBy,
                RegistrationDate = DateTime.UtcNow
            };

            _context.BirthRecords.Add(birthRecord);
            await _context.SaveChangesAsync();

            // Optionally return a ReadDto
            var result = new BirthRecordReadDto
            {
                Id = birthRecord.Id,
                FullName = birthRecord.FullName,
                BirthDate = birthRecord.BirthDate,
                Gender = birthRecord.Gender,
                PlaceOfBirth = birthRecord.PlaceOfBirth,
                FatherName = birthRecord.FatherName,
                MotherName = birthRecord.MotherName,
                Address = birthRecord.Address,
                RegisteredBy = birthRecord.RegisteredBy,
                RegistrationDate = birthRecord.RegistrationDate
            };

            return CreatedAtAction(nameof(GetBirthRecord), new { id = birthRecord.Id }, result);
        }


        private bool BirthRecordExists(int id)
        {
            return _context.BirthRecords.Any(e => e.Id == id);
        }
    }
}
