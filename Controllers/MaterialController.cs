using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/materiales")]
    public class MaterialController: ControllerBase
    {
        private readonly MaterialData materialData;

        public MaterialController()
        {
            materialData = new MaterialData();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialModel>>> getMateriales()
        {
            // Obtener la informacion del usuario a partir del token
            var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            var id_solicitante = idClaim != null ? int.Parse(idClaim.Value) : 0;
            var comprasClaim = User.Claims.FirstOrDefault(c => c.Type == "aprob_compras");
            var esCompras = comprasClaim != null ? bool.Parse(comprasClaim.Value) : false;
            var finanzasClaim = User.Claims.FirstOrDefault(c => c.Type == "aprob_finanzas");
            var esFinanzas = finanzasClaim != null ? bool.Parse(finanzasClaim.Value) : false;
            var sistemasClaim = User.Claims.FirstOrDefault(c => c.Type == "aprob_sistemas");
            var esSistemas = sistemasClaim != null ? bool.Parse(sistemasClaim.Value) : false;

            // Verificar si el solicitante es aprobador de compras
            if (esCompras)
            {
                var list = await materialData.getMaterialesCompras();
                return list;
            }
            // Verificar si el solicitante es aprobador de finanzas
            if (esFinanzas)
            {
                var list = await materialData.getMaterialesFinanzas();
                return list;
            }
            // Verificar si el solicitante es aprobador de sistemas
            if (esSistemas)
            {
                var list = await materialData.getMaterialesSistemas();
                return list;
            }
            // Si es un usuario normal, podrá ver solo sus solicitudes
            else
            {
                var list = await materialData.getMaterialesByIdSolicitante(id_solicitante);
                return list;
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<MaterialModel>>> getMaterialById(int id)
        {
            var list = await materialData.getMaterialById(id);
            return list;
        }

        [HttpPost]
        [Authorize]
        public async Task<dynamic/*IActionResult*/> postMaterial([FromForm] MaterialModel material)
        {
            try
            {
                // Obtener el id y nombre del usuario a partir del token
                var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                material.id_solicitante = idClaim != null ? int.Parse(idClaim.Value) : 0;
                material.id_modificador = material.id_solicitante;

                var nombreClaim = User.Claims.FirstOrDefault(c => c.Type == "nombre");
                material.nombre_solicitante = nombreClaim != null ? nombreClaim.Value : string.Empty;
                material.nombre_modificador = material.nombre_solicitante;

                // Guardar el material en la base de datos
                await materialData.postMaterial(material);
                //return Ok("Material creado exitosamente.");
                return new
                {
                    success = true,
                    message = "Solicitud de material creada exitosamente"
                };
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el material: {ex.Message}");
                return new
                {
                    success = false,
                    message = $"Error al crear la solicitud de material: {ex.Message}"
                };
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<dynamic/*IActionResult*/> putMaterial(int id, [FromForm] MaterialModel material)
        {
            try
            {
                // Verificar si el registro existe en la base de datos
                var registroExistente = await materialData.getMaterialById(id);
                if (registroExistente.Count() == 0)
                {
                    //return NotFound("Material no encontrado.");
                    return new
                    {
                        success = false,
                        message = "Material no encontrado"
                    };
                }

                // Obtener el id y nombre del usuario a partir del token
                var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                material.id_modificador = idClaim != null ? int.Parse(idClaim.Value) : 0;

                var nombreClaim = User.Claims.FirstOrDefault(c => c.Type == "nombre");
                material.nombre_modificador = nombreClaim != null ? nombreClaim.Value : string.Empty;

                // Actualizar el registro en la base de datos
                await materialData.putMaterial(id, material);
                //return Ok("Material modificado exitosamente.");
                return new
                {
                    success = true,
                    message = "Material modificado exitosamente"
                };
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, $"Error al modificar el material: {ex.Message}");
                return new
                {
                    success = false,
                    message = $"Error al modificar el material: {ex.Message}"
                };
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> deleteMaterial(int id)
        {
            try
            {
                // Verificar si el registro existe en la base de datos
                var registroExistente = await materialData.getMaterialById(id);
                if (registroExistente.Count() == 0)
                {
                    return NotFound("Material no encontrado.");
                }
                // Si el registro existe, eliminar
                await materialData.deleteMaterial(id);
                return Ok("Material eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el material: {ex.Message}");
            }
        }
    }
}
