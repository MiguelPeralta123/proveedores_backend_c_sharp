using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/paises")]
    public class PaisController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<PaisModel>>> getPaises()
        {
            var function = new PaisData();
            var list = await function.getPaises();
            return list;
        }
    }
}
