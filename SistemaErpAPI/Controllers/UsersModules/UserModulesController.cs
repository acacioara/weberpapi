using DatabaseContext.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Models.Modelos.Modules;
using Models.Modelos.UserModules;
using SistemaErpAPI.Security;
using System.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.UsersModules
{
    [Route("api/user-modules")]
    [ApiController]
    [Authorize]
    public class UserModulesController : ControllerBase
    {
        private readonly ContextConfig _db;
        private IConfiguration configuration;
        public UserModulesController(ContextConfig db, IConfiguration configuration)
        {
            _db = db;
            this.configuration = configuration;
        }

        // POST api/<UserModulesController>
        [HttpPost]
        public async Task<ActionResult> PostUsersModules([FromBody] UserModules userModules)
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
        public async Task<ActionResult> RemoveUsersModules([FromBody] UserModules userModules)
        {
            var userModulesFinded = await _db.UserModules.FirstOrDefaultAsync(x => x.IdUser == userModules.IdUser && x.IdModule == userModules.IdModule);
            if (userModulesFinded == null)
                return BadRequest(new { message = "Registro não encontrado" });
            _db.Remove(userModulesFinded);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetUsersModules()
        {
            try
            {
                List<Module> modules = new List<Module>();

                var idUser = GetIdUserLogged();
                if (idUser == Guid.Empty)
                    throw new ArgumentException("Erro ao retronar o id do usuário logado.");

                var idsModules = await _db.UserModules.Where(x => x.IdUser == idUser).ToListAsync();
                foreach (var item in idsModules)
                    modules.Add(await _db.Modules.FirstAsync(x => x.Id == item.IdModule && x.Able == true));

                return Ok(modules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Guid GetIdUserLogged()
        {
            try
            {
                JwtTokenGenerete jwt = new JwtTokenGenerete(configuration);
                return jwt.GetLoggedId(Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", ""));
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
