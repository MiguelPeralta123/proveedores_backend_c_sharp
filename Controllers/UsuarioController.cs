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
    [Route("api/login")]
    public class UsuarioController: ControllerBase
    {
        public IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<dynamic> Login([FromBody] Object UsuarioData)
        {
            var credentials = JsonConvert.DeserializeObject<dynamic>(UsuarioData.ToString());
            string username = credentials.username.ToString();
            string password = credentials.password.ToString();

            List<UsuarioModel> usersList = await getUsers();
            var user = usersList.Where(x => x.username == username && x.password == password).FirstOrDefault();

            if (user == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<JwtModel>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", user.id.ToString()),
                new Claim("username", user.username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(jwt.issuer, jwt.audience, claims, expires: DateTime.Now.AddHours(24), signingCredentials: signin);
            //var token = new JwtSecurityToken(jwt.issuer, jwt.audience, claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: signin);

            return new
            {
                success = true,
                message = "Inicio de sesión correcto",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        [HttpGet]
        [Authorize]
        public async Task<List<UsuarioModel>> getUsers()
        {
            var function = new UsuarioData();
            var list = await function.GetUsers();
            return list;
        }
    }
}
