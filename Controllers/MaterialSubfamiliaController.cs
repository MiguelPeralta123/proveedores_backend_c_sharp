using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_subfamilias")]
    public class MaterialSubfamiliaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialSubfamiliaModel>>> getSubfamilias()
        {
            var function = new MaterialSubfamiliaData();
            var list = await function.getSubfamilias();
            return list;
        }

        [HttpGet("{familia}")]
        [Authorize]
        public async Task<ActionResult<List<MaterialSubfamiliaModel>>> getSubfamiliasByFamilia(string familia)
        {
            var function = new MaterialSubfamiliaData();
            var list = await function.getSubfamiliasByFamilia(familia);
            return list;
        }
    }
}
