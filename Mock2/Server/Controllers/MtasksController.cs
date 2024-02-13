using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mock2.Shared.Domain;
using Mock2.Server.Data;

namespace Mock2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MtasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MtasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Mtasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mtask>>> GetMtasks()
        {
          if (_context.Mtasks == null)
          {
              return NotFound();
          }
            return await _context.Mtasks.ToListAsync();
        }

        // GET: api/Mtasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mtask>> GetMtask(int id)
        {
          if (_context.Mtasks == null)
          {
              return NotFound();
          }
            var mtask = await _context.Mtasks.FindAsync(id);

            if (mtask == null)
            {
                return NotFound();
            }

            return mtask;
        }

        // PUT: api/Mtasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtask(int id, Mtask mtask)
        {
            if (id != mtask.Id)
            {
                return BadRequest();
            }

            _context.Entry(mtask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtaskExists(id))
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

        // POST: api/Mtasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mtask>> PostMtask(Mtask mtask)
        {
          if (_context.Mtasks == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Mtasks'  is null.");
          }
            _context.Mtasks.Add(mtask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtask", new { id = mtask.Id }, mtask);
        }

        // DELETE: api/Mtasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtask(int id)
        {
            if (_context.Mtasks == null)
            {
                return NotFound();
            }
            var mtask = await _context.Mtasks.FindAsync(id);
            if (mtask == null)
            {
                return NotFound();
            }

            _context.Mtasks.Remove(mtask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MtaskExists(int id)
        {
            return (_context.Mtasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
