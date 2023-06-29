using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/tipo_operacion")]
    public class TipoOperacionController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TipoOperacionModel>>> getTipoOperacion()
        {
            var function = new TipoOperacionData();
            var list = await function.getTipoOperacion();
            return list;
        }
    }
}
