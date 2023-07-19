﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Metall_Fest.models;

namespace Metall_Fest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly MainContext _context;

        public BandsController(MainContext context)
        {
            _context = context;
        }

        // GET: api/Bands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Band>>> Getbands()
        {
          if (_context.bands == null)
          {
              return NotFound();
          }
            return await _context.bands.ToListAsync();
        }

        // GET: api/Bands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Band>> GetBand(int id)
        {
          if (_context.bands == null)
          {
              return NotFound();
          }
            var band = await _context.bands.FindAsync(id);

            if (band == null)
            {
                return NotFound();
            }

            return band;
        }

        // PUT: api/Bands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBand(int id, Band band)
        {
            if (id != band.bandId)
            {
                return BadRequest();
            }

            _context.Entry(band).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BandExists(id))
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

        // POST: api/Bands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Band>> PostBand(Band band)
        {
          if (_context.bands == null)
          {
              return Problem("Entity set 'MainContext.bands'  is null.");
          }
            _context.bands.Add(band);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBand", new { id = band.bandId }, band);
        }

        // DELETE: api/Bands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            if (_context.bands == null)
            {
                return NotFound();
            }
            var band = await _context.bands.FindAsync(id);
            if (band == null)
            {
                return NotFound();
            }

            _context.bands.Remove(band);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BandExists(int id)
        {
            return (_context.bands?.Any(e => e.bandId == id)).GetValueOrDefault();
        }
    }
}
