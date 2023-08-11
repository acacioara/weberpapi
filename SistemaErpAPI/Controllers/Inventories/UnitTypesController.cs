using DatabaseContext.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos.Inventories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.Inventories
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitTypesController : ControllerBase
    {
        private readonly ContextConfig _db;
        public UnitTypesController(ContextConfig db)
        {
           _db = db;
        }
        // GET: api/<UnitTypesController>
        [HttpGet]
        public async Task<ActionResult> GetUnitTypes()
        {
            return Ok(await _db.UnitTypes.ToListAsync());
        }

        // GET api/<UnitTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUnitType(Guid id)
        {
            try
            {
                var unitType = await _db.UnitTypes.FindAsync(id);
                if (unitType == null)
                    return BadRequest(new { message = "Tipo de unidade não cadastrado" });
                return Ok(unitType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UnitTypesController>
        [HttpPost]
        public async Task<ActionResult> PostUnitType([FromBody] UnitType unitType)
        {
            try
            {
                await _db.UnitTypes.AddAsync(unitType);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UnitTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUnitType(Guid id, [FromBody] UnitType unitType)
        {
            try
            {
                var unitTypeFinded = await _db.UnitTypes.FindAsync(id);
                if (unitTypeFinded == null)
                    return BadRequest(new { message = "Tipo de unidade não cadastrado" });

                unitTypeFinded.Description = unitType.Description;                

                _db.UnitTypes.Update(unitTypeFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UnitTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUnitType(Guid id)
        {
            var unitTypes = await _db.UnitTypes.FindAsync(id);
            if (unitTypes == null)
                return BadRequest(new { message = "Tipo de unidade não cadastrado" });
            _db.Remove(unitTypes);
            await _db.SaveChangesAsync();
            return Ok(unitTypes);
        }
    }
}
