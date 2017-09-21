using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KraigsList.Data;

namespace KraigsList.Controllers
{
    [Produces("application/json")]
    [Route("api/Ads")]
    public class AdsController : Controller
    {
        private readonly KraigsListContext _context;

        public AdsController(KraigsListContext context)
        {
            _context = context;
        }

        // GET: api/Ads
        [HttpGet]
        public IEnumerable<Ad> GetAd()
        {
            // @Drew - the Include() method allows us to include the composite objects in the data
            // https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
            return _context.Ads.Where(n => !string.IsNullOrEmpty(n.ActiveId)).Include("Images");
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAd([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // @Drew - the Include() method allows us to include the composite objects in the data
            // https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
            var ad = await _context.Ads.Include("Images").SingleOrDefaultAsync(m => m.AdId == id);

            if (ad == null)
            {
                return NotFound();
            }

            return Ok(ad);
        }

        // PUT: api/Ads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAd([FromRoute] int id, [FromBody] Ad ad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ad.AdId)
            {
                return BadRequest();
            }

            _context.Entry(ad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdExists(id))
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

        // POST: api/Ads
        [HttpPost]
        public async Task<IActionResult> PostAd([FromBody] Ad ad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAd", new { id = ad.AdId }, ad);
        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAd([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ad = await _context.Ads.SingleOrDefaultAsync(m => m.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();

            return Ok(ad);
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.AdId == id);
        }
    }
}