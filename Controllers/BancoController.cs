using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/bancos")]
    public class BancoController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<BancoModel>>> getBancos()
        {
            var function = new BancoData();
            var list = await function.getBancos();
            return list;
        }
    }
}
