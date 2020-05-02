using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrepPeered.Api.Data;
using PrepPeered.Api.Entities;

namespace PrepPeered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipsController : ControllerBase
    {
        private readonly PrepPeeredDbContext _context;

        public TipsController(PrepPeeredDbContext context)
        {
            _context = context;
        }

        // GET: api/Tips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tip>>> GetTips()
        {
            return await _context.Tips.ToListAsync();
        }

        // GET: api/Tips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tip>> GetTip(long id)
        {
            var tip = await _context.Tips.FindAsync(id);

            if (tip == null)
            {
                return NotFound();
            }

            return tip;
        }

        // PUT: api/Tips/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTip(long id, Tip tip)
        {
            if (id != tip.Id)
            {
                return BadRequest();
            }

            _context.Entry(tip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/Tips
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tip>> PostTip(Tip tip)
        {
            _context.Tips.Add(tip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTip", new { id = tip.Id }, tip);
        }

        // DELETE: api/Tips/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tip>> DeleteTip(long id)
        {
            var tip = await _context.Tips.FindAsync(id);
            if (tip == null)
            {
                return NotFound();
            }

            _context.Tips.Remove(tip);
            await _context.SaveChangesAsync();

            return tip;
        }

        private bool TipExists(long id)
        {
            return _context.Tips.Any(e => e.Id == id);
        }
    }
}