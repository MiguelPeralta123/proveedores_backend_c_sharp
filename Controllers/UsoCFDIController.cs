using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/uso_cfdi")]
    public class UsoCFDIController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UsoCFDIModel>>> getUsoCFDI()
        {
            var function = new UsoCFDIData();
            var list = await function.getUsoCFDI();
            return list;
        }
    }
}
