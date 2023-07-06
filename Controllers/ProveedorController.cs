using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresBackendCSharp.Data;
using ProveedoresBackendCSharp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProveedoresBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/proveedores")]
    public class ProveedorController: ControllerBase
    {
        private readonly ProveedorData proveedorData;

        public ProveedorController()
        {
            proveedorData = new ProveedorData();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ProveedorModel>>> getProveedores()
        {
            var list = await proveedorData.getProveedores();
            return list;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<ProveedorModel>>> getProveedorById(int id)
        {
            var list = await proveedorData.getProveedorById(id);
            return list;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> postProveedor([FromForm] ProveedorModel proveedor, [FromForm] IFormFile constancia, [FromForm] IFormFile estado_cuenta)
        {
            try
            {
                // Obtener el id y nombre del usuario a partir del token
                var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                proveedor.id_solicitante = idClaim != null ? int.Parse(idClaim.Value) : 0;

                var nombreClaim = User.Claims.FirstOrDefault(c => c.Type == "nombre");
                proveedor.solicitante = nombreClaim != null ? nombreClaim.Value : string.Empty;

                // Validar la existencia del primer archivo (constancia de situacion fiscal)
                if (constancia != null && constancia.Length > 0)
                {
                    var timestamp = DateTime.Now.Ticks.ToString();
                    var nombre_constancia = $"{timestamp}_{Path.GetFileName(constancia.FileName)}";
                    var ruta_constancia = Path.Combine(Directory.GetCurrentDirectory(), "Documentos", "Constancias", nombre_constancia);
                    
                    // Crear la carpeta "Documentos/Constancias" en caso de que no exista
                    var directorio_constancia = Path.GetDirectoryName(ruta_constancia);
                    if (!Directory.Exists(directorio_constancia))
                    {
                        Directory.CreateDirectory(directorio_constancia);
                    }

                    // Guardar la constancia
                    using (var stream = new FileStream(ruta_constancia, FileMode.Create))
                    {
                        await constancia.CopyToAsync(stream);
                    }
                    proveedor.nombre_constancia = nombre_constancia;
                    proveedor.ruta_constancia = ruta_constancia;
                }

                // Validar la existencia del segundo archivo (estado de cuenta bancario)
                if (estado_cuenta != null && estado_cuenta.Length > 0)
                {
                    var timestamp = DateTime.Now.Ticks.ToString();
                    var nombre_estado_cuenta = $"{timestamp}_{Path.GetFileName(estado_cuenta.FileName)}";
                    var ruta_estado_cuenta = Path.Combine(Directory.GetCurrentDirectory(), "Documentos", "Estados_cuenta", nombre_estado_cuenta);

                    // Crear la carpeta "Documentos/Estados_cuenta" en caso de que no exista
                    var directorio_estados_cuenta = Path.GetDirectoryName(ruta_estado_cuenta);
                    if (!Directory.Exists(directorio_estados_cuenta))
                    {
                        Directory.CreateDirectory(directorio_estados_cuenta);
                    }

                    // Guardar el estado de cuenta bancario
                    using (var stream = new FileStream(ruta_estado_cuenta, FileMode.Create))
                    {
                        await estado_cuenta.CopyToAsync(stream);
                    }
                    proveedor.nombre_estado_cuenta = nombre_estado_cuenta;
                    proveedor.ruta_estado_cuenta = ruta_estado_cuenta;
                }

                // Guardando el proveedor en la base de datos
                await proveedorData.postProveedor(proveedor);
                return Ok("Proveedor creado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el proveedor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> putProveedor(int id, [FromForm] ProveedorModel proveedor)
        {
            try
            {
                // Verificar si el proveedor existe en la base de datos
                var proveedorExistente = await proveedorData.getProveedorById(id);
                if (proveedorExistente.Count() == 0)
                {
                    return NotFound("Proveedor no encontrado.");
                }
                // Si el proveedor existe, actualizar
                await proveedorData.putProveedor(id, proveedor);
                return Ok("Proveedor modificado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al modificar el proveedor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> deleteProveedor(int id)
        {
            try
            {
                // Verificar si el proveedor existe en la base de datos
                var proveedorExistente = await proveedorData.getProveedorById(id);
                if (proveedorExistente.Count() == 0)
                {
                    return NotFound("Proveedor no encontrado.");
                }
                // Si el proveedor existe, eliminar
                await proveedorData.deleteProveedor(id);
                return Ok("Proveedor eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el proveedor: {ex.Message}");
            }
        }
    }
}
