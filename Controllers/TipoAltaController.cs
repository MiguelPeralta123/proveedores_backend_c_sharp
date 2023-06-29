using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/tipo_alta")]
    public class TipoAltaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TipoAltaModel>>> getTipoAlta()
        {
            var function = new TipoAltaData();
            var list = await function.getTipoAlta();
            return list;
        }
    }
}
