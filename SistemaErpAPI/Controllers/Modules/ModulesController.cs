using DatabaseContext.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos.Modules;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.Modules
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModulesController : ControllerBase
    {
        private readonly ContextConfig _db;
        public ModulesController(ContextConfig db)
        {
           _db = db;
        }
        // GET: api/<ModulesController>
        [HttpGet]
        public async Task<ActionResult> GetModules()
        {
            return Ok(await _db.Modules.ToListAsync());
        }

        // GET api/<ModulesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetModule(Guid id)
        {
            try
            {
                var module = await _db.Modules.FindAsync(id);
                if (module == null)
                    return BadRequest(null);
                return Ok(module);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ModulesController>
        [HttpPost]
        public async Task<ActionResult> PostModule([FromBody] Module module)
        {
            try
            {
                await _db.Modules.AddAsync(module);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ModulesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutModule(Guid id, [FromBody] Module module)
        {
            try
            {
                var moduleFinded = await _db.Modules.FindAsync(id);
                if (moduleFinded == null)
                    return BadRequest("Módulo não cadastrado");

                moduleFinded.Name = module.Name;
                moduleFinded.Able = module.Able;
                moduleFinded.Code = module.Code;

                _db.Modules.Update(moduleFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ModulesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModule(Guid id)
        {
            var module = await _db.Modules.FindAsync(id);
            if (module == null)
                return BadRequest("Usuário não encontrado");
            _db.Remove(module);
            await _db.SaveChangesAsync();
            return Ok(module);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> InactiveModule(Guid id)
        {
            var module = await _db.Modules.FindAsync(id);
            if (module == null)
                return BadRequest("Usuário não encontrado");

            module.Able = false;
            _db.Modules.Update(module);
            await _db.SaveChangesAsync();
            return Ok(module);
        }
    }
}
