using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_unidades")]
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

        [HttpGet("{tipo}")]
        [Authorize]
        public async Task<ActionResult<List<MaterialUnidadMedidaModel>>> getUnidadesMedidaByTipo(string tipo)
        {
            var function = new MaterialUnidadMedidaData();
            var list = await function.getUnidadesMedidaByTipo(tipo);
            return list;
        }
    }
}
