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
    public class SetupChecksController : ControllerBase
    {
        private readonly PrepPeeredDbContext _context;

        public SetupChecksController(PrepPeeredDbContext context)
        {
            _context = context;
        }

        // GET: api/SetupChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SetupCheck>>> GetSetupChecks()
        {
            return await _context.SetupChecks.ToListAsync();
        }

        // GET: api/SetupChecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SetupCheck>> GetSetupCheck(long id)
        {
            var setupCheck = await _context.SetupChecks.FindAsync(id);

            if (setupCheck == null)
            {
                return NotFound();
            }

            return setupCheck;
        }

        // PUT: api/SetupChecks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetupCheck(long id, SetupCheck setupCheck)
        {
            if (id != setupCheck.Id)
            {
                return BadRequest();
            }

            _context.Entry(setupCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetupCheckExists(id))
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

        // POST: api/SetupChecks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SetupCheck>> PostSetupCheck(SetupCheck setupCheck)
        {
            _context.SetupChecks.Add(setupCheck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSetupCheck", new { id = setupCheck.Id }, setupCheck);
        }

        // DELETE: api/SetupChecks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SetupCheck>> DeleteSetupCheck(long id)
        {
            var setupCheck = await _context.SetupChecks.FindAsync(id);
            if (setupCheck == null)
            {
                return NotFound();
            }

            _context.SetupChecks.Remove(setupCheck);
            await _context.SaveChangesAsync();

            return setupCheck;
        }

        private bool SetupCheckExists(long id)
        {
            return _context.SetupChecks.Any(e => e.Id == id);
        }
    }
}
