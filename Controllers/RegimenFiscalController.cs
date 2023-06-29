using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/regimen_fiscal")]
    public class RegimenFiscalController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RegimenFiscalModel>>> getRegimenes()
        {
            var function = new RegimenFiscalData();
            var list = await function.getRegimenes();
            return list;
        }
    }
}
