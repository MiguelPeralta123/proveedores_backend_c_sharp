using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProveedoresBackendCSharp.Models;
using ProveedoresBackendCSharp.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        public IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("api/login")]
        [HttpPost]
        public async Task<dynamic> Login([FromForm] UsuarioModel usuario)
        {
            string username = usuario.username;
            string password = usuario.password;

            List<UsuarioModel> usersList = await getUsers();
            var user = usersList.Where(x => x.username == username && x.password == password).FirstOrDefault();

            if (user == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    jwt = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<JwtModel>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", user.id.ToString()),
                new Claim("nombre", user.nombre),
                new Claim("aprob_compras", user.aprob_compras.ToString()),
                new Claim("aprob_finanzas", user.aprob_finanzas.ToString()),
                new Claim("aprob_sistemas", user.aprob_sistemas.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(jwt.issuer, jwt.audience, claims, expires: DateTime.Now.AddDays(1), signingCredentials: signin);

            return new
            {
                success = true,
                message = "Inicio de sesión correcto",
                jwt = new JwtSecurityTokenHandler().WriteToken(token),
                user
            };
        }

        /*[Route("api/login")]
        [HttpGet]
        [Authorize]*/
        private async Task<List<UsuarioModel>> getUsers()
        {
            var function = new UsuarioData();
            var list = await function.GetUsers();
            return list;
        }

        // Funcionality to delete a token
        /*[Route("api/logout")]
        [HttpPost]
        public async Task<dynamic> Logout()
        {

            var jwt = _configuration.GetSection("Jwt").Get<JwtModel>();

            var token = new JwtSecurityToken(jwt.issuer, jwt.audience, claims, expires: DateTime.Now.AddDays(1), signingCredentials: signin);

            return new
            {
                success = true,
                message = "Inicio de sesión correcto",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }*/
    }
}
