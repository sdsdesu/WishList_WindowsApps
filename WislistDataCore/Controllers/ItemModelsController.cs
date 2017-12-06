using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WislistDataCore.Models;

namespace WislistDataCore.Controllers
{
    [Produces("application/json")]
    [Route("api/ItemModels")]
    public class ItemModelsController : Controller
    {
        private readonly WislistDataCoreContext _context;

        public ItemModelsController(WislistDataCoreContext context)
        {
            _context = context;
        }

        // GET: api/ItemModels
        [HttpGet]
        public IEnumerable<ItemModel> GetItemModel()
        {
            return _context.ItemModel;
        }

        // GET: api/ItemModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemModel = await _context.ItemModel.SingleOrDefaultAsync(m => m.ItemId == id);

            if (itemModel == null)
            {
                return NotFound();
            }

            return Ok(itemModel);
        }

        // PUT: api/ItemModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemModel([FromRoute] int id, [FromBody] ItemModel itemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemModel.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemModelExists(id))
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

        // POST: api/ItemModels
        [HttpPost]
        public async Task<IActionResult> PostItemModel([FromBody] ItemModel itemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ItemModel.Add(itemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemModel", new { id = itemModel.ItemId }, itemModel);
        }

        // DELETE: api/ItemModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemModel = await _context.ItemModel.SingleOrDefaultAsync(m => m.ItemId == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            _context.ItemModel.Remove(itemModel);
            await _context.SaveChangesAsync();

            return Ok(itemModel);
        }

        private bool ItemModelExists(int id)
        {
            return _context.ItemModel.Any(e => e.ItemId == id);
        }
    }
}