using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStart_Test.DataBase;
using TechStart_Test.Models;

namespace TechStart_Test.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PharmacyInventoryController : ControllerBase
    {
        private readonly Context _context;

        public PharmacyInventoryController(Context context)
        {
            _context = context;
        }

        // GET: api/PharmacyInventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharmacyInventory>>> GetPharmacyInventory()
        {
            return await _context.PharmacyInventory.ToListAsync();
        }

        // GET: api/PharmacyInventory/5
        [HttpGet("{idPharmacy}/{itemNumber}")]
        public async Task<ActionResult<PharmacyInventory>> GetPharmacyInventory(int idPharmacy, int itemNumber)
        {
            var pharmacyInventory = await _context.PharmacyInventory.FindAsync(idPharmacy, itemNumber);
            //var pharmacyInventory = await _context.PharmacyInventory.FirstOrDefaultAsync(t => t.IdPharmacy == idPharmacy && t.ItemNumber == itemNumber);
            
            if (pharmacyInventory == null)
            {
                return NotFound();
            }

            return pharmacyInventory;
        }

        // PUT: api/PharmacyInventory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{idPharmacy}/{itemNumber}")]
        public async Task<IActionResult> Update(int idPharmacy, int itemNumber, PharmacyInventory pharmacyInventory)
        {

            if (idPharmacy != pharmacyInventory.IdPharmacy)
            {
                return BadRequest();
            }
            else if(itemNumber != pharmacyInventory.ItemNumber)
            {
                return BadRequest();
            }

            _context.Entry(pharmacyInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyInventoryExists(idPharmacy, itemNumber))
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

        // POST: api/PharmacyInventory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PharmacyInventory>> Create(PharmacyInventory pharmacyInventory)
        {

            if (pharmacyInventory.QuantityOnHand <= 0)
            {
                return BadRequest("Quantity on hand can´t be less than 0");
            }

            var pharmacyExists = await _context.Pharmacy.AnyAsync(t => t.IdPharmacy == pharmacyInventory.IdPharmacy);
            if (!pharmacyExists)
            {
                return BadRequest("Pharmacy must be created");
            }

            var itemExists = await _context.Item.AnyAsync(t => t.ItemNumber == pharmacyInventory.ItemNumber);
            if (!itemExists)
            {
                return BadRequest("Item must be created");
            }

            _context.PharmacyInventory.Add(pharmacyInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PharmacyInventoryExists(pharmacyInventory.IdPharmacy, pharmacyInventory.ItemNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPharmacyInventory", new { id = pharmacyInventory.IdPharmacy }, pharmacyInventory);
        }

        // DELETE: api/PharmacyInventory/5
        [HttpDelete("{idPharmacy}/{itemNumber}")]
        public async Task<ActionResult<PharmacyInventory>> Delete(int idPharmacy, int itemNumber)
        {
            var pharmacyInventory = await _context.PharmacyInventory.FindAsync(idPharmacy, itemNumber);
            if (pharmacyInventory == null)
            {
                return NotFound();
            }

            _context.PharmacyInventory.Remove(pharmacyInventory);
            await _context.SaveChangesAsync();

            return pharmacyInventory;
        }

        private bool PharmacyInventoryExists(int idPharmacy, int itemNumber)
        {
            return _context.PharmacyInventory.Any(e => e.IdPharmacy == idPharmacy && e.ItemNumber == itemNumber);
        }
    }
}
