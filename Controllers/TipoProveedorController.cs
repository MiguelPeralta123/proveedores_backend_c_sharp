using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/tipo_proveedor")]
    public class TipoProveedorController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TipoProveedorModel>>> getTipoProveedor()
        {
            var function = new TipoProveedorData();
            var list = await function.getTipoProveedor();
            return list;
        }
    }
}
