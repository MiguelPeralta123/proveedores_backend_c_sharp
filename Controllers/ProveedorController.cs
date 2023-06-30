using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/proveedores")]
    public class ProveedorController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ProveedorModel>>> getProveedores()
        {
            var function = new ProveedorData();
            var list = await function.getProveedores();
            return list;
        }
    }
}
