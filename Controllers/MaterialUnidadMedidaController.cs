using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_unidad_medida")]
    public class MaterialUnidadMedidaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialUnidadMedidaModel>>> getUnidadesMedida()
        {
            var function = new MaterialUnidadMedidaData();
            var list = await function.getUnidadesMedida();
            return list;
        }
    }
}
