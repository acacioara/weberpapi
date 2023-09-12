using DatabaseContext.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos.Inventories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.Inventories
{
    [Route("api/suppliers")]
    [ApiController]
    [Authorize]
    public class SuppliersController : ControllerBase
    {
        private readonly ContextConfig _db;
        public SuppliersController(ContextConfig db)
        {
           _db = db;
        }
        // GET: api/<SuppliersController>
        [HttpGet]
        public async Task<ActionResult> GetSuppliers()
        {
            return Ok(await _db.Suppliers.ToListAsync());
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSupplier(Guid id)
        {
            try
            {
                var Supplie = await _db.Suppliers.FindAsync(id);
                if (Supplie == null)
                    return BadRequest(new { message = "Fornecedor não cadastrado" });
                return Ok(Supplie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public async Task<ActionResult> PostSupplier([FromBody] Supplier supplier)
        {
            try
            {
                await _db.Suppliers.AddAsync(supplier);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSupplier(Guid id, [FromBody] Supplier supplier)
        {
            try
            {
                var supplierFinded = await _db.Suppliers.FindAsync(id);
                if (supplierFinded == null)
                    return BadRequest(new { message = "Fornecedor não cadastrado" });

                supplierFinded.CorporateName = supplier.CorporateName;
                supplierFinded.PhoneNumber = supplier.PhoneNumber;
                supplierFinded.Email = supplier.Email;                
                supplierFinded.Street = supplier.Street;
                supplierFinded.Number = supplier.Number;
                supplierFinded.Complemet = supplier.Complemet;
                supplierFinded.Neighborhood = supplier.Neighborhood;
                supplierFinded.City = supplier.City;
                supplierFinded.State = supplier.State;
                supplierFinded.ZipCode = supplier.ZipCode;

                _db.Suppliers.Update(supplierFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(Guid id)
        {
            var supplier = await _db.Suppliers.FindAsync(id);
            if (supplier == null)
                return BadRequest(new { message = "Fornecedor não cadastrado" });
            _db.Remove(supplier);
            await _db.SaveChangesAsync();
            return Ok(supplier);
        }

        // PUT api/<SuppliersController>/5
        [HttpPut()]
        public async Task<ActionResult> AbleDisableSupplier([FromBody] Guid id)
        {
            try
            {
                var supplierFinded = await _db.Suppliers.FindAsync(id);
                if (supplierFinded == null)
                    return BadRequest(new { message = "Fornecedor não cadastrado" });

                supplierFinded.Able = !supplierFinded.Able;

                _db.Suppliers.Update(supplierFinded);
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
