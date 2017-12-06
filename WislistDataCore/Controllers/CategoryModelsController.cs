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
    [Route("api/CategoryModels")]
    public class CategoryModelsController : Controller
    {
        private readonly WislistDataCoreContext _context;

        public CategoryModelsController(WislistDataCoreContext context)
        {
            _context = context;
        }

        // GET: api/CategoryModels
        [HttpGet]
        public IEnumerable<CategoryModel> GetCategoryModel()
        {
            return _context.CategoryModel;
        }

        // GET: api/CategoryModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryModel = await _context.CategoryModel.SingleOrDefaultAsync(m => m.CategoryID == id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(categoryModel);
        }

        // PUT: api/CategoryModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryModel([FromRoute] int id, [FromBody] CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryModel.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id))
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

        // POST: api/CategoryModels
        [HttpPost]
        public async Task<IActionResult> PostCategoryModel([FromBody] CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CategoryModel.Add(categoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryModel", new { id = categoryModel.CategoryID }, categoryModel);
        }

        // DELETE: api/CategoryModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryModel = await _context.CategoryModel.SingleOrDefaultAsync(m => m.CategoryID == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            _context.CategoryModel.Remove(categoryModel);
            await _context.SaveChangesAsync();

            return Ok(categoryModel);
        }

        private bool CategoryModelExists(int id)
        {
            return _context.CategoryModel.Any(e => e.CategoryID == id);
        }
    }
}