using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/rubros")]
    public class RubroController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<RubroModel>>> getRubros()
        {
            var function = new RubroData();
            var list = await function.getRubros();
            return list;
        }
    }
}
