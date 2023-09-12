using DatabaseContext.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Models.Requests;
using NuGet.Protocol.Plugins;
using SistemaErpAPI.Security;
using System.Security.Cryptography;

namespace SistemaErpAPI.Controllers.Logon
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration configuration;
        private ContextConfig _db;
        public LoginController(ContextConfig db, IConfiguration configuration)
        {
            this._db = db;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Authencaticate(LoginRequest login)
        {
            try
            {
                JwtTokenGenerete jwtTokenGenerete = new JwtTokenGenerete(configuration);
                PasswordSecurity password = new PasswordSecurity(SHA256.Create());
                var user = await _db.Users.FirstAsync(x => x.Email == login.Email);
                if (user == null)
                    return BadRequest(new { message = "Usuário e/ou senha inválidos" });

                if (!password.PasswordVerify(login.Password, user.Password))
                    return BadRequest(new { message = "Usuário e/ou senha inválidos" });

                return Ok(new { message = "Usuário autenticado com sucesso!", token = jwtTokenGenerete.GetToken(user) });
            }
            catch (Exception ex)
                {
                return BadRequest(new { message = "Usuário e/ou senha inválidos", innerException = ex.Message });
            }
        }

        [HttpGet()]
        public async Task<ActionResult> IsAuthencaticate()
        {
            try
            {
                string token = Request.Headers[HeaderNames.Authorization][0].ToString();
                JwtTokenGenerete jwtTokenGenerete = new JwtTokenGenerete(configuration);
                return Ok(new { message = "Status de validação do token.", isValidToken = jwtTokenGenerete.IsTokenValid(token) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Usuário e/ou senha inválidos", innerException = ex.Message });
            }
        }

        [HttpGet("Logout")]
        public ActionResult<bool> Logout()
        {
            try
            {
                Request.Headers.Clear();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
