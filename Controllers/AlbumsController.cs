using System;
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
    public class AlbumsController : ControllerBase
    {
        private readonly MainContext _context;

        public AlbumsController(MainContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> Getalbums()
        {
          if (_context.albums == null)
          {
              return NotFound();
          }
            return await _context.albums.ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
          if (_context.albums == null)
          {
              return NotFound();
          }
            var album = await _context.albums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        [HttpGet("albumbyband/{bandId}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumByBandId(int bandId)
        {
            if (_context.albums == null)
            {
                return NotFound();
            }
            var albums = await _context.albums.Where(album => album.bandId == bandId).ToListAsync();
            if (albums == null || albums.Count == 0)
            {
                return NotFound();
            }
            return albums;
        }

        // PUT: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAlbum(Album album)
        {

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(album.albumId))
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



        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
          if (_context.albums == null)
          {
              return Problem("Entity set 'MainContext.albums'  is null.");
          }
            _context.albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.albumId }, album);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            if (_context.albums == null)
            {
                return NotFound();
            }
            var album = await _context.albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return (_context.albums?.Any(e => e.albumId == id)).GetValueOrDefault();
        }
    }
}
