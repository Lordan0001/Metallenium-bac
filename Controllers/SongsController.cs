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
    public class SongsController : ControllerBase
    {
        private readonly MainContext _context;

        public SongsController(MainContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> Getsongs()
        {
          if (_context.songs == null)
          {
              return NotFound();
          }
            return await _context.songs.ToListAsync();
        }

        [HttpGet("songsbyalbum/{id}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsByAlbum(int id)
        {
            if (_context.songs == null)
            {
                return NotFound();
            }
            var songs = await _context.songs.Where(song => song.albumId == id).ToListAsync();
            if (songs == null || songs.Count == 0)
            {
                return NotFound();
            }
            return songs;
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
          if (_context.songs == null)
          {
              return NotFound();
          }
            var song = await _context.songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.songId)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
          if (_context.songs == null)
          {
              return Problem("Entity set 'MainContext.songs'  is null.");
          }
            _context.songs.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.songId }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            if (_context.songs == null)
            {
                return NotFound();
            }
            var song = await _context.songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return (_context.songs?.Any(e => e.songId == id)).GetValueOrDefault();
        }
    }
}
