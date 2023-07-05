using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/material_solicitudes")]
    public class MaterialSolicitudController: ControllerBase
    {
        private readonly MaterialSolicitudData materialSolicitudData;

        public MaterialSolicitudController()
        {
            materialSolicitudData = new MaterialSolicitudData();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<MaterialSolicitudModel>>> getMaterialSolicitudes()
        {
            var list = await materialSolicitudData.getMaterialSolicitudes();
            return list;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<MaterialSolicitudModel>>> getMaterialSolicitudById(int id)
        {
            var list = await materialSolicitudData.getMaterialSolicitudById(id);
            return list;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> postMaterialSolicitud([FromForm] MaterialSolicitudModel solicitud)
        {
            try
            {
                await materialSolicitudData.postMaterialSolicitud(solicitud);
                return Ok("Solicitud de material creada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear la solicitud de material: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> putMaterialSolicitud(int id, [FromForm] MaterialSolicitudModel solicitud)
        {
            try
            {
                // Verificar si el registro existe en la base de datos
                var registroExistente = await materialSolicitudData.getMaterialSolicitudById(id);
                if (registroExistente.Count() == 0)
                {
                    return NotFound("Solicitud de material no encontrada.");
                }
                // Si el registro existe, actualizar
                await materialSolicitudData.putMaterialSolicitud(id, solicitud);
                return Ok("Solicitud de material modificada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al modificar la solicitud de material: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> deleteMaterialSolicitud(int id)
        {
            try
            {
                // Verificar si el registro existe en la base de datos
                var registroExistente = await materialSolicitudData.getMaterialSolicitudById(id);
                if (registroExistente.Count() == 0)
                {
                    return NotFound("Solicitud de material no encontrada.");
                }
                // Si el registro existe, eliminar
                await materialSolicitudData.deleteMaterialSolicitud(id);
                return Ok("Solicitud de material eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la solicitud de material: {ex.Message}");
            }
        }
    }
}
