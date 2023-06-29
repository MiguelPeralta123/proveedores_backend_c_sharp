using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/retencion_iva")]
    public class RetencionIVAController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RetencionIVAModel>>> getOpciones()
        {
            var function = new RetencionIVAData();
            var list = await function.getOpciones();
            return list;
        }
    }
}
