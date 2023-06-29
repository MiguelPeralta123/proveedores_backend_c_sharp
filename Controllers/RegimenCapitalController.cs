using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/regimen_capital")]
    public class RegimenCapitalController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RegimenCapitalModel>>> getRegimenes()
        {
            var function = new RegimenCapitalData();
            var list = await function.getRegimenes();
            return list;
        }
    }
}
