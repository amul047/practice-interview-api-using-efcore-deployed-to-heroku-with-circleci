using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrepPeered.Api.Data;
using PrepPeered.Api.Entities;

namespace PrepPeered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeniorityLevelsController : ControllerBase
    {
        private readonly PrepPeeredDbContext _context;

        public SeniorityLevelsController(PrepPeeredDbContext context)
        {
            _context = context;
        }

        // GET: api/SeniorityLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeniorityLevel>>> GetSeniorityLevels()
        {
            return await _context.SeniorityLevels.ToListAsync();
        }

        // GET: api/SeniorityLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeniorityLevel>> GetSeniorityLevel(long id)
        {
            var seniorityLevel = await _context.SeniorityLevels.FindAsync(id);

            if (seniorityLevel == null)
            {
                return NotFound();
            }

            return seniorityLevel;
        }

        // PUT: api/SeniorityLevels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeniorityLevel(long id, SeniorityLevel seniorityLevel)
        {
            if (id != seniorityLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(seniorityLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeniorityLevelExists(id))
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

        // POST: api/SeniorityLevels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SeniorityLevel>> PostSeniorityLevel(SeniorityLevel seniorityLevel)
        {
            _context.SeniorityLevels.Add(seniorityLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeniorityLevel", new { id = seniorityLevel.Id }, seniorityLevel);
        }

        // DELETE: api/SeniorityLevels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeniorityLevel>> DeleteSeniorityLevel(long id)
        {
            var seniorityLevel = await _context.SeniorityLevels.FindAsync(id);
            if (seniorityLevel == null)
            {
                return NotFound();
            }

            _context.SeniorityLevels.Remove(seniorityLevel);
            await _context.SaveChangesAsync();

            return seniorityLevel;
        }

        private bool SeniorityLevelExists(long id)
        {
            return _context.SeniorityLevels.Any(e => e.Id == id);
        }
    }
}
