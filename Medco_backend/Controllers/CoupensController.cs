using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedcoDBcontext;
using Medco_backend.Models;

namespace Medco_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoupensController : ControllerBase
    {
        private readonly MedcoDBContext _context;

        public CoupensController(MedcoDBContext context)
        {
            _context = context;
        }

        // GET: api/Coupens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coupen>>> GetCoupens()
        {
            return await _context.Coupens.ToListAsync();
        }

        // GET: api/Coupens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coupen>> GetCoupen(int id)
        {
            var coupen = await _context.Coupens.FindAsync(id);

            if (coupen == null)
            {
                return NotFound();
            }

            return coupen;
        }

         // GET: api/Coupens/Coupen/BALM50
        [HttpGet("Coupen/{code}")]
        public async Task<ActionResult<Product>> GetByCoupenCode(string code)
        {
            var coupon = _context.Coupens.Where(x => x.Coupencode == code).AsQueryable();
            if (coupon == null)
            {
                return NotFound();
            }
            return Ok(coupon);
        }

        [HttpPost("Redeem")]
        public IActionResult Redeem([FromBody] Coupen codeObj)
        {
            if (codeObj == null)
            {
                return BadRequest();
            }
            else
            {
                var code = codeObj.Coupencode;
                var couponDetails = _context.Coupens.Where(x => x.Coupencode == code);
                var coupen = _context.Coupens.Where(a =>
                a.Coupencode == code).FirstOrDefault();
                if (coupen != null)
                {
                    return Ok(couponDetails);
                }

                else
                {
                    return NotFound(new
                    {
                        Statuscode = 404,
                        Message = "Coupon not found"
                    });
                }
            }
        }

        // PUT: api/Coupens/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutCoupen(int id, Coupen coupen)
        {
            if (id != coupen.Cid)
            {
                return BadRequest();
            }

            _context.Entry(coupen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoupenExists(id))
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

        // POST: api/Coupens
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddCoupen")]
        public async Task<ActionResult<Coupen>> PostCoupen(Coupen coupen)
        {
            _context.Coupens.Add(coupen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoupen", new { id = coupen.Cid }, coupen);
        }

        // DELETE: api/Coupens/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Coupen>> DeleteCoupen(int id)
        {
            var coupen = await _context.Coupens.FindAsync(id);
            if (coupen == null)
            {
                return NotFound();
            }

            _context.Coupens.Remove(coupen);
            await _context.SaveChangesAsync();

            return coupen;
        }

        private bool CoupenExists(int id)
        {
            return _context.Coupens.Any(e => e.Cid == id);
        }
    }
}
