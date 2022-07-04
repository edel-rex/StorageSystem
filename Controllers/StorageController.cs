using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly AppContext _context;

        public StorageController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Storage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storages>>> GetStorages()
        {
          if (_context.Storages == null)
          {
              return NotFound();
          }
            return await _context.Storages.ToListAsync();
        }

        // GET: api/Storage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Storages>> GetStorages(int id)
        {
          if (_context.Storages == null)
          {
              return NotFound();
          }
            var storages = await _context.Storages.FindAsync(id);

            if (storages == null)
            {
                return NotFound();
            }

            return storages;
        }

        // PUT: api/Storage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorages(int id, Storages storages)
        {
            if (id != storages.Id)
            {
                return BadRequest();
            }

            _context.Entry(storages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoragesExists(id))
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

        // POST: api/Storage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Storages>> PostStorages(Storages storages)
        {
          if (_context.Storages == null)
          {
              return Problem("Entity set 'AppContext.Storages'  is null.");
          }
            _context.Storages.Add(storages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorages", new { id = storages.Id }, storages);
        }

        // DELETE: api/Storage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorages(int id)
        {
            if (_context.Storages == null)
            {
                return NotFound();
            }
            var storages = await _context.Storages.FindAsync(id);
            if (storages == null)
            {
                return NotFound();
            }

            _context.Storages.Remove(storages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoragesExists(int id)
        {
            return (_context.Storages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
