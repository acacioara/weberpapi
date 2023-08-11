using DatabaseContext.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos.UserModules;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.UsersModules
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserModulesController : ControllerBase
    {
        private readonly ContextConfig _db;
        public UserModulesController(ContextConfig db)
        {
           _db = db;
        }

        // POST api/<UserModulesController>
        [HttpPost]
        public async Task<ActionResult> PostUserModels([FromBody] UserModules userModules)
        {
            try
            {
                await _db.UserModules.AddAsync(userModules);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UserModulesController>/5
        [HttpDelete]
        public async Task<ActionResult> RemoveUserModels([FromBody] UserModules userModules)
        {
            var userModulesFinded = await _db.UserModules.FirstOrDefaultAsync(x => x.IdUser == userModules.IdUser && x.IdModule == userModules.IdModule);
            if (userModulesFinded == null)
                return BadRequest(new { message = "Registro não encontrado" });
            _db.Remove(userModulesFinded);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{idUser}")]
        public async Task<ActionResult> GetUserModels(Guid idUser)
        {
            try
            {
                return Ok(await _db.UserModules.Where(x => x.IdUser == idUser).ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
