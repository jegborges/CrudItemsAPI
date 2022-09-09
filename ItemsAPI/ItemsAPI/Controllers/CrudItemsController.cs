using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItemsAPI.Models;

namespace ItemsAPI.Controllers
{
    [Route("api/cruditems")]
    [ApiController]
    public class CrudItemsController : ControllerBase
    {
        private readonly CrudContext _context;

        public CrudItemsController(CrudContext context)
        {
            _context = context;
        }

        // GET: api/CrudItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrudItem>>> GetCrudItems()
        {
            return await _context.CrudItems.ToListAsync();
        }

        // GET: api/CrudItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CrudItem>> GetCrudItem(long id)
        {
            var crudItem = await _context.CrudItems.FindAsync(id);

            if (crudItem == null)
            {
                return NotFound();
            }

            return crudItem;
        }

        // PUT: api/CrudItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrudItem(long id, CrudItem crudItem)
        {
            if (id != crudItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(crudItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrudItemExists(id))
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

        // POST: api/CrudItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CrudItem>> PostCrudItem(CrudItem crudItem)
        {
            _context.CrudItems.Add(crudItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCrudItem), new { id = crudItem.Id }, crudItem);
        }

        // DELETE: api/CrudItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrudItem(long id)
        {
            var crudItem = await _context.CrudItems.FindAsync(id);
            if (crudItem == null)
            {
                return NotFound();
            }

            _context.CrudItems.Remove(crudItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrudItemExists(long id)
        {
            return _context.CrudItems.Any(e => e.Id == id);
        }
    }
}
