using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<PersonaModel>>> getPersonas()
        {
            var function = new PersonaData();
            var list = await function.getPersonas();
            return list;
        }
    }
}
