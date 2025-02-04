﻿using System;
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
    public class DashboardsController : ControllerBase
    {
        private readonly PrepPeeredDbContext _context;

        public DashboardsController(PrepPeeredDbContext context)
        {
            _context = context;
        }

        // GET: api/Dashboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dashboard>>> GetDashboards()
        {
            return await _context.Dashboards.ToListAsync();
        }

        // GET: api/Dashboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dashboard>> GetDashboard(long id)
        {
            var dashboard = await _context.Dashboards.FindAsync(id);

            if (dashboard == null)
            {
                return NotFound();
            }

            return dashboard;
        }

        // PUT: api/Dashboards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashboard(long id, Dashboard dashboard)
        {
            if (id != dashboard.Id)
            {
                return BadRequest();
            }

            _context.Entry(dashboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardExists(id))
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

        // POST: api/Dashboards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dashboard>> PostDashboard(Dashboard dashboard)
        {
            _context.Dashboards.Add(dashboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDashboard", new { id = dashboard.Id }, dashboard);
        }

        // DELETE: api/Dashboards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dashboard>> DeleteDashboard(long id)
        {
            var dashboard = await _context.Dashboards.FindAsync(id);
            if (dashboard == null)
            {
                return NotFound();
            }

            _context.Dashboards.Remove(dashboard);
            await _context.SaveChangesAsync();

            return dashboard;
        }

        private bool DashboardExists(long id)
        {
            return _context.Dashboards.Any(e => e.Id == id);
        }
    }
}
