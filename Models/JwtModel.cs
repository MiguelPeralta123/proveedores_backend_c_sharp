using System.Security.Claims;

namespace ProveedoresBackendCSharp.Models
{
    public class JwtModel
    {
        public string key { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public string subject { get; set; }

        public static dynamic validateToken(ClaimsIdentity identity, List<UsuarioModel> usersList)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Invalid token",
                        result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

                UsuarioModel user = usersList.FirstOrDefault(x => x.id.ToString() == id);

                return new
                {
                    success = true,
                    message = "Token válido",
                    result = user
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Error al validar token: " + ex.Message,
                    result = ""
                };
            }
        }
    }
}
