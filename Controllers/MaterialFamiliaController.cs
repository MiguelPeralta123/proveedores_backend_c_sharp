using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_familia")]
    public class MaterialFamiliaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialFamiliaModel>>> getFamilias()
        {
            var function = new MaterialFamiliaData();
            var list = await function.getFamilias();
            return list;
        }
    }
}
