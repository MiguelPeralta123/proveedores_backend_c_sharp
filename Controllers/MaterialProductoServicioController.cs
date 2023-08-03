using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_tipo_alta")]
    public class MaterialProductoServicioController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialProductoServicioModel>>> getMaterialProductoServicio()
        {
            var function = new MaterialProductoServicioData();
            var list = await function.getMaterialProductoServicio();
            return list;
        }
    }
}
