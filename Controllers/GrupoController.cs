using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/grupos")]
    public class GrupoController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<GrupoModel>>> getGrupos()
        {
            var function = new GrupoData();
            var list = await function.getGrupos();
            return list;
        }
    }
}
