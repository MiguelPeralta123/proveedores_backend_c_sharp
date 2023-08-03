using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/estados")]
    public class EstadoController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<EstadoModel>>> getEstados()
        {
            var function = new EstadoData();
            var list = await function.getEstados();
            return list;
        }

        [HttpGet("{pais}")]
        [Authorize]
        public async Task<ActionResult<List<EstadoModel>>> getEstadosByPais(string pais)
        {
            var function = new EstadoData();
            var list = await function.getEstadosByPais(pais);
            return list;
        }
    }
}
