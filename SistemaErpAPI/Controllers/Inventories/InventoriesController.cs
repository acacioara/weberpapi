using DatabaseContext.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos.Inventories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.Inventories
{
    [Route("api/inventories")]
    [ApiController]
    [Authorize]
    public class InventoriesController : ControllerBase
    {
        private readonly ContextConfig _db;
        public InventoriesController(ContextConfig db)
        {
           _db = db;
        }
        // GET: api/<InventoriesController>
        [HttpGet]
        public async Task<ActionResult> GetInventories()
        {
            return Ok(await _db.Inventories.ToListAsync());
        }

        // GET api/<InventoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInventory(Guid id)
        {
            try
            {
                var Inventory = await _db.Inventories.FindAsync(id);
                if (Inventory == null)
                    return BadRequest(new { message = "Item do estoque não cadastrado" });
                return Ok(Inventory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<InventoriesController>
        [HttpPost]
        public async Task<ActionResult> PostInventory([FromBody] Inventory inventory)
        {
            try
            {
                await _db.Inventories.AddAsync(inventory);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InventoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutInventory(Guid id, [FromBody] Inventory inventory)
        {
            try
            {
                var inventoryFinded = await _db.Inventories.FindAsync(id);
                if (inventoryFinded == null)
                    return BadRequest(new { message = "Item do estoque não cadastrado" });

                inventoryFinded.Description = inventory.Description;
                inventoryFinded.SalePrice = inventory.SalePrice;
                inventoryFinded.CostPrice = inventory.CostPrice;                
                inventoryFinded.ProfitPercentage = inventory.ProfitPercentage;                
                inventoryFinded.IdSupplier = inventory.IdSupplier;
                inventoryFinded.IdCategory = inventory.IdCategory;
                inventoryFinded.IdUnitType= inventory.IdUnitType;


                _db.Inventories.Update(inventoryFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<InventoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInventory(Guid id)
        {
            var inventory = await _db.Inventories.FindAsync(id);
            if (inventory == null)
                return BadRequest(new { message = "Item do estoque não cadastrado" });
            _db.Remove(inventory);
            await _db.SaveChangesAsync();
            return Ok(inventory);
        }

        // PUT api/<InventoriesController>/5
        [HttpPut()]
        public async Task<ActionResult> AbleDisableInventory([FromBody] Guid id)
        {
            try
            {
                var inventoryFinded = await _db.Inventories.FindAsync(id);
                if (inventoryFinded == null)
                    return BadRequest(new { message = "Item do estoque não cadastrado" });

                inventoryFinded.Able = !inventoryFinded.Able;

                _db.Inventories.Update(inventoryFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
