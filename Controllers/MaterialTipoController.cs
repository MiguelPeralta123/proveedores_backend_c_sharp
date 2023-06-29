using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_tipo")]
    public class MaterialTipoController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialTipoModel>>> getTipos()
        {
            var function = new MaterialTipoData();
            var list = await function.getTipos();
            return list;
        }
    }
}
