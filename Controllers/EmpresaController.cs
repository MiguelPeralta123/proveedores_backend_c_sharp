using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/empresas")]
    public class EmpresaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<EmpresaModel>>> getEmpresas()
        {
            var function = new EmpresaData();
            var list = await function.getEmpresas();
            return list;
        }
    }
}
