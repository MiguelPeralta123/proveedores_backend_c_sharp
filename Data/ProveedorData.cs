using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class ProveedorData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<ProveedorModel>> getProveedores()
        {
            var list = new List<ProveedorModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getProveedores", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var proveedor = new ProveedorModel();
                            proveedor.id = (int)reader["id"];
                            proveedor.empresa = (string)reader["empresa"];
                            proveedor.codigo = (string)reader["codigo"];
                            proveedor.tipo_alta = (string)reader["tipo_alta"];
                            proveedor.contribuyente = (string)reader["contribuyente"];
                            proveedor.razon_social = (string)reader["razon_social"];
                            proveedor.rfc = (string)reader["rfc"];
                            if (reader["curp"] != DBNull.Value)
                            {
                                proveedor.curp = (string)reader["curp"];
                            }
                            proveedor.regimen_capital = (string)reader["regimen_capital"];
                            proveedor.nombre_fiscal = (string)reader["nombre_fiscal"];
                            proveedor.nombre_comercial = (string)reader["nombre_comercial"];
                            proveedor.uso_cfdi = (string)reader["uso_cfdi"];
                            if (reader["representante_legal"] != DBNull.Value)
                            {
                                proveedor.representante_legal = (string)reader["representante_legal"];
                            }
                            proveedor.telefono_1 = (string)reader["telefono_1"];
                            if (reader["telefono_2"] != DBNull.Value)
                            {
                                proveedor.telefono_2 = (string)reader["telefono_2"];
                            }
                            if (reader["contacto"] != DBNull.Value)
                            {
                                proveedor.contacto = (string)reader["contacto"];
                            }
                            proveedor.grupo = (string)reader["grupo"];
                            proveedor.correo_general = (string)reader["correo_general"];
                            proveedor.correo_pagos = (string)reader["correo_pagos"];
                            if (reader["sitio_web"] != DBNull.Value)
                            {
                                proveedor.sitio_web = (string)reader["sitio_web"];
                            }
                            proveedor.rubro = (string)reader["rubro"];
                            proveedor.tipo_operacion = (string)reader["tipo_operacion"];
                            proveedor.tipo_tercero = (string)reader["tipo_tercero"];
                            proveedor.id_fiscal = (string)reader["id_fiscal"];
                            proveedor.regimen_fiscal = (string)reader["regimen_fiscal"];
                            proveedor.agente_aduanal = (string)reader["agente_aduanal"];
                            proveedor.reg_inc_fiscal = (string)reader["reg_inc_fiscal"];
                            proveedor.impuesto_cedular = (string)reader["impuesto_cedular"];
                            proveedor.venc_s_fecha = (DateTime)reader["venc_s_fecha"];
                            proveedor.dias_entrega_completa = (int)reader["dias_entrega_completa"];
                            proveedor.dias_credito = (int)reader["dias_credito"];
                            proveedor.limite_credito_MN = (decimal)reader["limite_credito_MN"];
                            proveedor.limite_credito_ME = (decimal)reader["limite_credito_ME"];
                            proveedor.monto_credito = (decimal)reader["monto_credito"];
                            proveedor.retencion_iva = (string)reader["retencion_iva"];
                            proveedor.retencion_isr = (string)reader["retencion_isr"];
                            proveedor.iva_frontera = (string)reader["iva_frontera"];
                            proveedor.calle = (string)reader["calle"];
                            proveedor.numero_exterior = (string)reader["numero_exterior"];
                            if (reader["numero_interior"] != DBNull.Value)
                            {
                                proveedor.numero_interior = (string)reader["numero_interior"];
                            }
                            proveedor.codigo_postal = (string)reader["codigo_postal"];
                            proveedor.colonia = (string)reader["colonia"];
                            proveedor.localidad = (string)reader["localidad"];
                            proveedor.municipio = (string)reader["municipio"];
                            proveedor.ciudad = (string)reader["ciudad"];
                            proveedor.estado = (string)reader["estado"];
                            proveedor.pais = (string)reader["pais"];
                            proveedor.banco = (string)reader["banco"];
                            proveedor.cuenta = (string)reader["cuenta"];
                            proveedor.moneda = (string)reader["moneda"];
                            proveedor.clabe = (string)reader["clabe"];
                            if (reader["banco_2"] != DBNull.Value)
                            {
                                proveedor.banco_2 = (string)reader["banco_2"];
                            }
                            if (reader["cuenta_2"] != DBNull.Value)
                            {
                                proveedor.cuenta_2 = (string)reader["cuenta_2"];
                            }
                            if (reader["moneda_2"] != DBNull.Value)
                            {
                                proveedor.moneda_2 = (string)reader["moneda_2"];
                            }
                            if (reader["clabe_2"] != DBNull.Value)
                            {
                                proveedor.clabe_2 = (string)reader["clabe_2"];
                            }
                            proveedor.nombre_constancia = (string)reader["nombre_constancia"];
                            proveedor.ruta_constancia = (string)reader["ruta_constancia"];
                            proveedor.nombre_estado_cuenta = (string)reader["nombre_estado_cuenta"];
                            proveedor.ruta_estado_cuenta = (string)reader["ruta_estado_cuenta"];
                            proveedor.aprobado_compras = (bool)reader["aprobado_compras"];
                            proveedor.aprobado_finanzas = (bool)reader["aprobado_finanzas"];
                            proveedor.aprobado_sistemas = (bool)reader["aprobado_sistemas"];
                            proveedor.aprobadas = (bool)reader["aprobadas"];
                            proveedor.fecha = (DateTime)reader["fecha"];
                            proveedor.usar_portal_prov = (bool)reader["usar_portal_prov"];
                            proveedor.no_aplica_rafaga = (bool)reader["no_aplica_rafaga"];
                            proveedor.no_relacionar_oc = (bool)reader["no_relacionar_oc"];
                            proveedor.folio = (string)reader["folio"];
                            proveedor.id_solicitante = (int)reader["id_solicitante"];
                            proveedor.solicitante = (string)reader["solicitante"];
                            proveedor.rechazado_compras = (bool)reader["rechazado_compras"];
                            proveedor.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            proveedor.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                proveedor.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(proveedor);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<ProveedorModel>> getProveedorById(int id)
        {
            var list = new List<ProveedorModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getProveedorById", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var proveedor = new ProveedorModel();
                            proveedor.id = (int)reader["id"];
                            proveedor.empresa = (string)reader["empresa"];
                            proveedor.codigo = (string)reader["codigo"];
                            proveedor.tipo_alta = (string)reader["tipo_alta"];
                            proveedor.contribuyente = (string)reader["contribuyente"];
                            proveedor.razon_social = (string)reader["razon_social"];
                            proveedor.rfc = (string)reader["rfc"];
                            if (reader["curp"] != DBNull.Value)
                            {
                                proveedor.curp = (string)reader["curp"];
                            }
                            proveedor.regimen_capital = (string)reader["regimen_capital"];
                            proveedor.nombre_fiscal = (string)reader["nombre_fiscal"];
                            proveedor.nombre_comercial = (string)reader["nombre_comercial"];
                            proveedor.uso_cfdi = (string)reader["uso_cfdi"];
                            if (reader["representante_legal"] != DBNull.Value)
                            {
                                proveedor.representante_legal = (string)reader["representante_legal"];
                            }
                            proveedor.telefono_1 = (string)reader["telefono_1"];
                            if (reader["telefono_2"] != DBNull.Value)
                            {
                                proveedor.telefono_2 = (string)reader["telefono_2"];
                            }
                            if (reader["contacto"] != DBNull.Value)
                            {
                                proveedor.contacto = (string)reader["contacto"];
                            }
                            proveedor.grupo = (string)reader["grupo"];
                            proveedor.correo_general = (string)reader["correo_general"];
                            proveedor.correo_pagos = (string)reader["correo_pagos"];
                            if (reader["sitio_web"] != DBNull.Value)
                            {
                                proveedor.sitio_web = (string)reader["sitio_web"];
                            }
                            proveedor.rubro = (string)reader["rubro"];
                            proveedor.tipo_operacion = (string)reader["tipo_operacion"];
                            proveedor.tipo_tercero = (string)reader["tipo_tercero"];
                            proveedor.id_fiscal = (string)reader["id_fiscal"];
                            proveedor.regimen_fiscal = (string)reader["regimen_fiscal"];
                            proveedor.agente_aduanal = (string)reader["agente_aduanal"];
                            proveedor.reg_inc_fiscal = (string)reader["reg_inc_fiscal"];
                            proveedor.impuesto_cedular = (string)reader["impuesto_cedular"];
                            proveedor.venc_s_fecha = (DateTime)reader["venc_s_fecha"];
                            proveedor.dias_entrega_completa = (int)reader["dias_entrega_completa"];
                            proveedor.dias_credito = (int)reader["dias_credito"];
                            proveedor.limite_credito_MN = (decimal)reader["limite_credito_MN"];
                            proveedor.limite_credito_ME = (decimal)reader["limite_credito_ME"];
                            proveedor.monto_credito = (decimal)reader["monto_credito"];
                            proveedor.retencion_iva = (string)reader["retencion_iva"];
                            proveedor.retencion_isr = (string)reader["retencion_isr"];
                            proveedor.iva_frontera = (string)reader["iva_frontera"];
                            proveedor.calle = (string)reader["calle"];
                            proveedor.numero_exterior = (string)reader["numero_exterior"];
                            if (reader["numero_interior"] != DBNull.Value)
                            {
                                proveedor.numero_interior = (string)reader["numero_interior"];
                            }
                            proveedor.codigo_postal = (string)reader["codigo_postal"];
                            proveedor.colonia = (string)reader["colonia"];
                            proveedor.localidad = (string)reader["localidad"];
                            proveedor.municipio = (string)reader["municipio"];
                            proveedor.ciudad = (string)reader["ciudad"];
                            proveedor.estado = (string)reader["estado"];
                            proveedor.pais = (string)reader["pais"];
                            proveedor.banco = (string)reader["banco"];
                            proveedor.cuenta = (string)reader["cuenta"];
                            proveedor.moneda = (string)reader["moneda"];
                            proveedor.clabe = (string)reader["clabe"];
                            if (reader["banco_2"] != DBNull.Value)
                            {
                                proveedor.banco_2 = (string)reader["banco_2"];
                            }
                            if (reader["cuenta_2"] != DBNull.Value)
                            {
                                proveedor.cuenta_2 = (string)reader["cuenta_2"];
                            }
                            if (reader["moneda_2"] != DBNull.Value)
                            {
                                proveedor.moneda_2 = (string)reader["moneda_2"];
                            }
                            if (reader["clabe_2"] != DBNull.Value)
                            {
                                proveedor.clabe_2 = (string)reader["clabe_2"];
                            }
                            proveedor.nombre_constancia = (string)reader["nombre_constancia"];
                            proveedor.ruta_constancia = (string)reader["ruta_constancia"];
                            proveedor.nombre_estado_cuenta = (string)reader["nombre_estado_cuenta"];
                            proveedor.ruta_estado_cuenta = (string)reader["ruta_estado_cuenta"];
                            proveedor.aprobado_compras = (bool)reader["aprobado_compras"];
                            proveedor.aprobado_finanzas = (bool)reader["aprobado_finanzas"];
                            proveedor.aprobado_sistemas = (bool)reader["aprobado_sistemas"];
                            proveedor.aprobadas = (bool)reader["aprobadas"];
                            proveedor.fecha = (DateTime)reader["fecha"];
                            proveedor.usar_portal_prov = (bool)reader["usar_portal_prov"];
                            proveedor.no_aplica_rafaga = (bool)reader["no_aplica_rafaga"];
                            proveedor.no_relacionar_oc = (bool)reader["no_relacionar_oc"];
                            proveedor.folio = (string)reader["folio"];
                            proveedor.id_solicitante = (int)reader["id_solicitante"];
                            proveedor.solicitante = (string)reader["solicitante"];
                            proveedor.rechazado_compras = (bool)reader["rechazado_compras"];
                            proveedor.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            proveedor.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                proveedor.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(proveedor);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task postProveedor(ProveedorModel proveedor)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("postProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empresa", proveedor.empresa);
                    cmd.Parameters.AddWithValue("@codigo", proveedor.codigo);
                    cmd.Parameters.AddWithValue("@tipo_alta", proveedor.tipo_alta);
                    cmd.Parameters.AddWithValue("@contribuyente", proveedor.contribuyente);
                    cmd.Parameters.AddWithValue("@razon_social", proveedor.razon_social);
                    cmd.Parameters.AddWithValue("@rfc", proveedor.rfc);
                    if (!string.IsNullOrEmpty(proveedor.curp))
                    {
                        cmd.Parameters.AddWithValue("@curp", proveedor.curp);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@curp", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@regimen_capital", proveedor.regimen_capital);
                    cmd.Parameters.AddWithValue("@nombre_fiscal", proveedor.nombre_fiscal);
                    cmd.Parameters.AddWithValue("@nombre_comercial", proveedor.nombre_comercial);
                    cmd.Parameters.AddWithValue("@uso_cfdi", proveedor.uso_cfdi);
                    if (!string.IsNullOrEmpty(proveedor.representante_legal))
                    {
                        cmd.Parameters.AddWithValue("@representante_legal", proveedor.representante_legal);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@representante_legal", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@telefono_1", proveedor.telefono_1);
                    if (!string.IsNullOrEmpty(proveedor.telefono_2))
                    {
                        cmd.Parameters.AddWithValue("@telefono_2", proveedor.telefono_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@telefono_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.contacto))
                    {
                        cmd.Parameters.AddWithValue("@contacto", proveedor.contacto);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@contacto", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@grupo", proveedor.grupo);
                    cmd.Parameters.AddWithValue("@correo_general", proveedor.correo_general);
                    cmd.Parameters.AddWithValue("@correo_pagos", proveedor.correo_pagos);
                    if (!string.IsNullOrEmpty(proveedor.sitio_web))
                    {
                        cmd.Parameters.AddWithValue("@sitio_web", proveedor.sitio_web);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@sitio_web", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@rubro", proveedor.rubro);
                    cmd.Parameters.AddWithValue("@tipo_operacion", proveedor.tipo_operacion);
                    cmd.Parameters.AddWithValue("@tipo_tercero", proveedor.tipo_tercero);
                    cmd.Parameters.AddWithValue("@id_fiscal", proveedor.id_fiscal);
                    cmd.Parameters.AddWithValue("@regimen_fiscal", proveedor.regimen_fiscal);
                    cmd.Parameters.AddWithValue("@agente_aduanal", proveedor.agente_aduanal);
                    cmd.Parameters.AddWithValue("@reg_inc_fiscal", proveedor.reg_inc_fiscal);
                    cmd.Parameters.AddWithValue("@impuesto_cedular", proveedor.impuesto_cedular);
                    cmd.Parameters.AddWithValue("@venc_s_fecha", proveedor.venc_s_fecha);
                    cmd.Parameters.AddWithValue("@dias_entrega_completa", proveedor.dias_entrega_completa);
                    cmd.Parameters.AddWithValue("@dias_credito", proveedor.dias_credito);
                    cmd.Parameters.AddWithValue("@limite_credito_MN", proveedor.limite_credito_MN);
                    cmd.Parameters.AddWithValue("@limite_credito_ME", proveedor.limite_credito_ME);
                    cmd.Parameters.AddWithValue("@monto_credito", proveedor.monto_credito);
                    cmd.Parameters.AddWithValue("@retencion_iva", proveedor.retencion_iva);
                    cmd.Parameters.AddWithValue("@retencion_isr", proveedor.retencion_isr);
                    cmd.Parameters.AddWithValue("@iva_frontera", proveedor.iva_frontera);
                    cmd.Parameters.AddWithValue("@calle", proveedor.calle);
                    cmd.Parameters.AddWithValue("@numero_exterior", proveedor.numero_exterior);
                    if (!string.IsNullOrEmpty(proveedor.numero_interior))
                    {
                        cmd.Parameters.AddWithValue("@numero_interior", proveedor.numero_interior);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@numero_interior", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@codigo_postal", proveedor.codigo_postal);
                    cmd.Parameters.AddWithValue("@colonia", proveedor.colonia);
                    cmd.Parameters.AddWithValue("@localidad", proveedor.localidad);
                    cmd.Parameters.AddWithValue("@municipio", proveedor.municipio);
                    cmd.Parameters.AddWithValue("@ciudad", proveedor.ciudad);
                    cmd.Parameters.AddWithValue("@estado", proveedor.estado);
                    cmd.Parameters.AddWithValue("@pais", proveedor.pais);
                    cmd.Parameters.AddWithValue("@banco", proveedor.banco);
                    cmd.Parameters.AddWithValue("@cuenta", proveedor.cuenta);
                    cmd.Parameters.AddWithValue("@moneda", proveedor.moneda);
                    cmd.Parameters.AddWithValue("@clabe", proveedor.clabe);
                    if (!string.IsNullOrEmpty(proveedor.banco_2))
                    {
                        cmd.Parameters.AddWithValue("@banco_2", proveedor.banco_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@banco_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.cuenta_2))
                    {
                        cmd.Parameters.AddWithValue("@cuenta_2", proveedor.cuenta_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cuenta_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.moneda_2))
                    {
                        cmd.Parameters.AddWithValue("@moneda_2", proveedor.moneda_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@moneda_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.clabe_2))
                    {
                        cmd.Parameters.AddWithValue("@clabe_2", proveedor.clabe_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@clabe_2", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@nombre_constancia", proveedor.nombre_constancia);
                    cmd.Parameters.AddWithValue("@ruta_constancia", proveedor.ruta_constancia);
                    cmd.Parameters.AddWithValue("@nombre_estado_cuenta", proveedor.nombre_estado_cuenta);
                    cmd.Parameters.AddWithValue("@ruta_estado_cuenta", proveedor.ruta_estado_cuenta);
                    cmd.Parameters.AddWithValue("@aprobado_compras", false);
                    cmd.Parameters.AddWithValue("@aprobado_finanzas", false);
                    cmd.Parameters.AddWithValue("@aprobado_sistemas", false);
                    cmd.Parameters.AddWithValue("@aprobadas", false);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@usar_portal_prov", proveedor.usar_portal_prov);
                    cmd.Parameters.AddWithValue("@no_aplica_rafaga", proveedor.no_aplica_rafaga);
                    cmd.Parameters.AddWithValue("@no_relacionar_oc", proveedor.no_relacionar_oc);
                    cmd.Parameters.AddWithValue("@folio", proveedor.folio);
                    cmd.Parameters.AddWithValue("@id_solicitante", proveedor.id_solicitante);
                    cmd.Parameters.AddWithValue("@solicitante", proveedor.solicitante);
                    cmd.Parameters.AddWithValue("@rechazado_compras", false);
                    cmd.Parameters.AddWithValue("@rechazado_finanzas", false);
                    cmd.Parameters.AddWithValue("@rechazado_sistemas", false);
                    if (!string.IsNullOrEmpty(proveedor.comentarios))
                    {
                        cmd.Parameters.AddWithValue("@comentarios", proveedor.comentarios);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@comentarios", DBNull.Value);
                    }
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        
        public async Task putProveedor(int id, ProveedorModel proveedor)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("putProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("@empresa", proveedor.empresa);
                    cmd.Parameters.AddWithValue("@codigo", proveedor.codigo);
                    cmd.Parameters.AddWithValue("@tipo_alta", proveedor.tipo_alta);
                    cmd.Parameters.AddWithValue("@contribuyente", proveedor.contribuyente);
                    cmd.Parameters.AddWithValue("@razon_social", proveedor.razon_social);
                    cmd.Parameters.AddWithValue("@rfc", proveedor.rfc);
                    if (!string.IsNullOrEmpty(proveedor.curp))
                    {
                        cmd.Parameters.AddWithValue("@curp", proveedor.curp);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@curp", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@regimen_capital", proveedor.regimen_capital);
                    cmd.Parameters.AddWithValue("@nombre_fiscal", proveedor.nombre_fiscal);
                    cmd.Parameters.AddWithValue("@nombre_comercial", proveedor.nombre_comercial);
                    cmd.Parameters.AddWithValue("@uso_cfdi", proveedor.uso_cfdi);
                    if (!string.IsNullOrEmpty(proveedor.representante_legal))
                    {
                        cmd.Parameters.AddWithValue("@representante_legal", proveedor.representante_legal);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@representante_legal", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@telefono_1", proveedor.telefono_1);
                    if (!string.IsNullOrEmpty(proveedor.telefono_2))
                    {
                        cmd.Parameters.AddWithValue("@telefono_2", proveedor.telefono_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@telefono_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.contacto))
                    {
                        cmd.Parameters.AddWithValue("@contacto", proveedor.contacto);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@contacto", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@grupo", proveedor.grupo);
                    cmd.Parameters.AddWithValue("@correo_general", proveedor.correo_general);
                    cmd.Parameters.AddWithValue("@correo_pagos", proveedor.correo_pagos);
                    if (!string.IsNullOrEmpty(proveedor.sitio_web))
                    {
                        cmd.Parameters.AddWithValue("@sitio_web", proveedor.sitio_web);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@sitio_web", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@rubro", proveedor.rubro);
                    cmd.Parameters.AddWithValue("@tipo_operacion", proveedor.tipo_operacion);
                    cmd.Parameters.AddWithValue("@tipo_tercero", proveedor.tipo_tercero);
                    cmd.Parameters.AddWithValue("@id_fiscal", proveedor.id_fiscal);
                    cmd.Parameters.AddWithValue("@regimen_fiscal", proveedor.regimen_fiscal);
                    cmd.Parameters.AddWithValue("@agente_aduanal", proveedor.agente_aduanal);
                    cmd.Parameters.AddWithValue("@reg_inc_fiscal", proveedor.reg_inc_fiscal);
                    cmd.Parameters.AddWithValue("@impuesto_cedular", proveedor.impuesto_cedular);
                    cmd.Parameters.AddWithValue("@venc_s_fecha", proveedor.venc_s_fecha);
                    cmd.Parameters.AddWithValue("@dias_entrega_completa", proveedor.dias_entrega_completa);
                    cmd.Parameters.AddWithValue("@dias_credito", proveedor.dias_credito);
                    cmd.Parameters.AddWithValue("@limite_credito_MN", proveedor.limite_credito_MN);
                    cmd.Parameters.AddWithValue("@limite_credito_ME", proveedor.limite_credito_ME);
                    cmd.Parameters.AddWithValue("@monto_credito", proveedor.monto_credito);
                    cmd.Parameters.AddWithValue("@retencion_iva", proveedor.retencion_iva);
                    cmd.Parameters.AddWithValue("@retencion_isr", proveedor.retencion_isr);
                    cmd.Parameters.AddWithValue("@iva_frontera", proveedor.iva_frontera);
                    cmd.Parameters.AddWithValue("@calle", proveedor.calle);
                    cmd.Parameters.AddWithValue("@numero_exterior", proveedor.numero_exterior);
                    if (!string.IsNullOrEmpty(proveedor.numero_interior))
                    {
                        cmd.Parameters.AddWithValue("@numero_interior", proveedor.numero_interior);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@numero_interior", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@codigo_postal", proveedor.codigo_postal);
                    cmd.Parameters.AddWithValue("@colonia", proveedor.colonia);
                    cmd.Parameters.AddWithValue("@localidad", proveedor.localidad);
                    cmd.Parameters.AddWithValue("@municipio", proveedor.municipio);
                    cmd.Parameters.AddWithValue("@ciudad", proveedor.ciudad);
                    cmd.Parameters.AddWithValue("@estado", proveedor.estado);
                    cmd.Parameters.AddWithValue("@pais", proveedor.pais);
                    cmd.Parameters.AddWithValue("@banco", proveedor.banco);
                    cmd.Parameters.AddWithValue("@cuenta", proveedor.cuenta);
                    cmd.Parameters.AddWithValue("@moneda", proveedor.moneda);
                    cmd.Parameters.AddWithValue("@clabe", proveedor.clabe);
                    if (!string.IsNullOrEmpty(proveedor.banco_2))
                    {
                        cmd.Parameters.AddWithValue("@banco_2", proveedor.banco_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@banco_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.cuenta_2))
                    {
                        cmd.Parameters.AddWithValue("@cuenta_2", proveedor.cuenta_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cuenta_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.moneda_2))
                    {
                        cmd.Parameters.AddWithValue("@moneda_2", proveedor.moneda_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@moneda_2", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(proveedor.clabe_2))
                    {
                        cmd.Parameters.AddWithValue("@clabe_2", proveedor.clabe_2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@clabe_2", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@aprobado_compras", proveedor.aprobado_compras);
                    cmd.Parameters.AddWithValue("@aprobado_finanzas", proveedor.aprobado_finanzas);
                    cmd.Parameters.AddWithValue("@aprobado_sistemas", proveedor.aprobado_sistemas);
                    cmd.Parameters.AddWithValue("@aprobadas", proveedor.aprobadas);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@usar_portal_prov", proveedor.usar_portal_prov);
                    cmd.Parameters.AddWithValue("@no_aplica_rafaga", proveedor.no_aplica_rafaga);
                    cmd.Parameters.AddWithValue("@no_relacionar_oc", proveedor.no_relacionar_oc);
                    cmd.Parameters.AddWithValue("@rechazado_compras", proveedor.rechazado_compras);
                    cmd.Parameters.AddWithValue("@rechazado_finanzas", proveedor.rechazado_finanzas);
                    cmd.Parameters.AddWithValue("@rechazado_sistemas", proveedor.rechazado_sistemas);
                    if (!string.IsNullOrEmpty(proveedor.comentarios))
                    {
                        cmd.Parameters.AddWithValue("@comentarios", proveedor.comentarios);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@comentarios", DBNull.Value);
                    }
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task deleteProveedor(int id)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("deleteProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
