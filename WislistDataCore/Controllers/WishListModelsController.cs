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
    [Route("api/WishListModels")]
    public class WishListModelsController : Controller
    {
        private readonly WislistDataCoreContext _context;

        public WishListModelsController(WislistDataCoreContext context)
        {
            _context = context;
        }

        // GET: api/WishListModels
        [HttpGet]
        public IEnumerable<WishListModel> GetWishListModel()
        {
            return _context.WishListModel;
        }

        // GET: api/WishListModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wishListModel = await _context.WishListModel.SingleOrDefaultAsync(m => m.ListId == id);

            if (wishListModel == null)
            {
                return NotFound();
            }

            return Ok(wishListModel);
        }

        // PUT: api/WishListModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishListModel([FromRoute] int id, [FromBody] WishListModel wishListModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wishListModel.ListId)
            {
                return BadRequest();
            }

            _context.Entry(wishListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishListModelExists(id))
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

        // POST: api/WishListModels
        [HttpPost]
        public async Task<IActionResult> PostWishListModel([FromBody] WishListModel wishListModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WishListModel.Add(wishListModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishListModel", new { id = wishListModel.ListId }, wishListModel);
        }

        // DELETE: api/WishListModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wishListModel = await _context.WishListModel.SingleOrDefaultAsync(m => m.ListId == id);
            if (wishListModel == null)
            {
                return NotFound();
            }

            _context.WishListModel.Remove(wishListModel);
            await _context.SaveChangesAsync();

            return Ok(wishListModel);
        }

        private bool WishListModelExists(int id)
        {
            return _context.WishListModel.Any(e => e.ListId == id);
        }
    }
}