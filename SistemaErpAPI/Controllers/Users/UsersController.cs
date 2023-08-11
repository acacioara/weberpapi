using DatabaseContext.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos.Users;
using SistemaErpAPI.Security;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaErpAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContextConfig _db;
        public UsersController(ContextConfig db)
        {
           _db = db;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _db.Users.ToListAsync());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(Guid id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null)
                    return BadRequest(new { message = "Usuário não cadastrado" });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] User user)
        {
            try
            {
                if (await _db.Users.AnyAsync(x => x.Email == user.Email))
                    return NotFound(new { message = "Usuário ja cadastrado com esse email." });

                PasswordSecurity passwordSecurity = new PasswordSecurity(SHA256.Create());
                user.Password = passwordSecurity.PasswordCriptografy(user.Password);
                _db.Users.Add(user);
                _db.SaveChanges();
                return Ok(new { message = "Usuário inserido em nossa base de dados", usuario = user });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(Guid id, [FromBody] User user)
        {
            try
            {
                var userFinded = await _db.Users.FindAsync(id);
                if (userFinded == null)
                    return BadRequest(new { message = "Usuário não cadastrado" });

                userFinded.DateBirth = user.DateBirth;
                userFinded.Email = user.Email;
                userFinded.Name = user.Name;

                _db.Users.Update(userFinded);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
                return BadRequest(new { message = "Usuário não cadastrado" });
            _db.Remove(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
