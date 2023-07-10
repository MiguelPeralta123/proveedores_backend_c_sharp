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
            var list = await materialData.getMateriales();
            return list;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<MaterialModel>>> getMaterialById(int id)
        {
            var list = await materialData.getMaterialById(id);
            return list;
        }

        /*
        [HttpGet("solicitudes/{id_solicitud}")]
        [Authorize]
        public async Task<ActionResult<List<MaterialModel>>> getMaterialByIdSolicitud(string id_solicitud)
        {
            var list = await materialData.getMaterialByIdSolicitud(id_solicitud);
            return list;
        }
        */

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> postMaterial([FromForm] MaterialModel material)
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
                return Ok("Material creado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el material: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> putMaterial(int id, [FromForm] MaterialModel material)
        {
            try
            {
                // Verificar si el registro existe en la base de datos
                var registroExistente = await materialData.getMaterialById(id);
                if (registroExistente.Count() == 0)
                {
                    return NotFound("Material no encontrado.");
                }
                // Si el registro existe, actualizar

                // Obtener el id y nombre del usuario a partir del token
                var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                material.id_modificador = idClaim != null ? int.Parse(idClaim.Value) : 0;

                var nombreClaim = User.Claims.FirstOrDefault(c => c.Type == "nombre");
                material.nombre_modificador = nombreClaim != null ? nombreClaim.Value : string.Empty;

                // Actualizar el registro en la base de datos
                await materialData.putMaterial(id, material);
                return Ok("Material modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al modificar el material: {ex.Message}");
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
