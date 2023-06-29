using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/iva_frontera")]
    public class IvaFronteraController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<IvaFronteraModel>>> getIvaFrontera()
        {
            var function = new IvaFronteraData();
            var list = await function.getIvaFrontera();
            return list;
        }
    }
}
