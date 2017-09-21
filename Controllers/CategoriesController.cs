using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KraigsList.Data;
using System.Data.SqlClient;

namespace KraigsList.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly KraigsListContext _context;

        public CategoriesController(KraigsListContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> GetCategory()
        {
            return _context.Categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // First, get the category data
            var category = await _context.Categories
                                        //  .Include(m => m.Ads)
                                        //  .ThenInclude(m => m.Images)
                                         .SingleOrDefaultAsync(m => m.CategoryId == id);

            // Then, get all the ads for this category id that have a valid ActiveId value
            var ads = await _context.Ads.Include(m => m.Images)
                                        .Where(m => !string.IsNullOrEmpty(m.ActiveId) && m.CategoryId == id)
                                        .ToListAsync();

            if (category == null)
            {                
                return NotFound();
            }
            else if (ads != null) 
            {
                category.Ads = ads;
            }

            return Ok(category);
        }

        // // PUT: api/Categories/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] Category category)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if (id != category.CategoryId)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(category).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!CategoryExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Categories
        // [HttpPost]
        // public async Task<IActionResult> PostCategory([FromBody] Category category)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     _context.Categories.Add(category);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        // }

        // // DELETE: api/Categories/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var category = await _context.Categories.SingleOrDefaultAsync(m => m.CategoryId == id);
        //     if (category == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Categories.Remove(category);
        //     await _context.SaveChangesAsync();

        //     return Ok(category);
        // }

        // private bool CategoryExists(int id)
        // {
        //     return _context.Categories.Any(e => e.CategoryId == id);
        // }
    }
}