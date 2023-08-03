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
                var list = await proveedorData.getProveedoresCompras();
                return list;
            }
            // Verificar si el solicitante es aprobador de finanzas
            if (esFinanzas)
            {
                var list = await proveedorData.getProveedoresFinanzas();
                return list;
            }
            // Verificar si el solicitante es aprobador de sistemas
            if (esSistemas)
            {
                var list = await proveedorData.getProveedoresSistemas();
                return list;
            }
            // Si es un usuario normal, podrá ver solo sus solicitudes
            else
            {
                var list = await proveedorData.getProveedoresByIdSolicitante(id_solicitante);
                return list;
            }
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
        public async Task<dynamic/*IActionResult*/> postProveedor([FromForm] ProveedorModel proveedor, [FromForm] IFormFile constancia, [FromForm] IFormFile estado_cuenta)
        {
            try
            {
                // Obtener el id y nombre del usuario a partir del token
                var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                proveedor.id_solicitante = idClaim != null ? int.Parse(idClaim.Value) : 0;
                proveedor.id_modificador = proveedor.id_solicitante;

                var nombreClaim = User.Claims.FirstOrDefault(c => c.Type == "nombre");
                proveedor.nombre_solicitante = nombreClaim != null ? nombreClaim.Value : string.Empty;
                proveedor.nombre_modificador = proveedor.nombre_solicitante;

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
                //return Ok("Proveedor creado exitosamente.");
                return new
                {
                    success = true,
                    message = "Proveedor creado exitosamente"
                };
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el proveedor: {ex.Message}");
                return new
                {
                    success = false,
                    message = $"Error al crear el proveedor: {ex.Message}"
                };
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<dynamic/*IActionResult*/> putProveedor(int id, [FromForm] ProveedorModel proveedor)
        {
            try
            {
                // Verificar si el proveedor existe en la base de datos
                var proveedorExistente = await proveedorData.getProveedorById(id);
                if (proveedorExistente.Count() == 0)
                {
                    //return NotFound("Proveedor no encontrado.");
                    return new
                    {
                        success = false,
                        message = "Proveedor no encontrado"
                    };
                }
                
                // Obtener el id y nombre del usuario a partir del token
                var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                proveedor.id_modificador = idClaim != null ? int.Parse(idClaim.Value) : 0;

                var nombreClaim = User.Claims.FirstOrDefault(c => c.Type == "nombre");
                proveedor.nombre_modificador = nombreClaim != null ? nombreClaim.Value : string.Empty;

                // Actualizar el registro en la base de datos
                await proveedorData.putProveedor(id, proveedor);
                //return Ok("Proveedor modificado exitosamente.");
                return new
                {
                    success = true,
                    message = "Proveedor modificado exitosamente"
                };
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, $"Error al modificar el proveedor: {ex.Message}");
                return new
                {
                    success = false,
                    message = $"Error al modificar el proveedor: {ex.Message}"
                };
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<dynamic/*IActionResult*/> deleteProveedor(int id)
        {
            try
            {
                // Verificar si el proveedor existe en la base de datos
                var proveedorExistente = await proveedorData.getProveedorById(id);
                if (proveedorExistente.Count() == 0)
                {
                    //return NotFound("Proveedor no encontrado.");
                    return new
                    {
                        success = false,
                        message = "Proveedor no encontrado"
                    };
                }
                // Si el proveedor existe, eliminar
                await proveedorData.deleteProveedor(id);
                //return Ok("Proveedor eliminado exitosamente.");
                return new
                {
                    success = true,
                    message = "Proveedor eliminado exitosamente"
                };
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el proveedor: {ex.Message}");
                return new
                {
                    success = false,
                    message = $"Error al eliminar el proveedor: {ex.Message}"
                };
            }
        }
    }
}
