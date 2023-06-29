using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/retencion_isr")]
    public class RetencionISRController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RetencionISRModel>>> getOpciones()
        {
            var function = new RetencionISRData();
            var list = await function.getOpciones();
            return list;
        }
    }
}
