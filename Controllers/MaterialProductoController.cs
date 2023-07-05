using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_productos")]
    public class MaterialProductoController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialProductoModel>>> getProductos()
        {
            var function = new MaterialProductoData();
            var list = await function.getProductos();
            return list;
        }

        [HttpGet("{subfamilia}")]
        [Authorize]
        public async Task<ActionResult<List<MaterialProductoModel>>> getProductosBySubfamilia(string subfamilia)
        {
            var function = new MaterialProductoData();
            var list = await function.getProductosBySubfamilia(subfamilia);
            return list;
        }
    }
}
