using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PELICULAS.ENTIDADES;

namespace PELICULA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoresController : ControllerBase
    {
        private readonly DataContext _context;

        public DirectoresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Directores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirector()
        {
          if (_context.Directores == null)
          {
              return NotFound();
          }

            var data = _context.Peliculas.Include(p => p.Director);
            return await _context.Directores.Include(p=>p.Peliculas).ToListAsync();
        }

        // GET: api/Directores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
          if (_context.Directores == null)
          {
              return NotFound();
          }


            var director =  _context.Directores.Include(p => p.Peliculas).First(p=> p.Id == id);

            if (director == null)
            {
                return NotFound();
            }

            return director;
        }

        // PUT: api/Directores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(int id, Director director)
        {
            if (id != director.Id)
            {
                return BadRequest();
            }

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Directores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Director>> PostDirector(Director director)
        {
          if (_context.Directores == null)
          {
              return Problem("Entity set 'DataContext.Director'  is null.");
          }
            _context.Directores.Add(director);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirector", new { id = director.Id }, director);
        }

        // DELETE: api/Directores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            if (_context.Directores == null)
            {
                return NotFound();
            }
            var director = await _context.Directores.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            _context.Directores.Remove(director);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorExists(int id)
        {
            return (_context.Directores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
