using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/contribuyente")]
    public class ContribuyenteController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ContribuyenteModel>>> getContribuyentes()
        {
            var function = new ContribuyenteData();
            var list = await function.getContribuyentes();
            return list;
        }
    }
}
