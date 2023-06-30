using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/monedas")]
    public class MonedaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MonedaModel>>> getMonedas()
        {
            var function = new MonedaData();
            var list = await function.getMonedas();
            return list;
        }
    }
}
