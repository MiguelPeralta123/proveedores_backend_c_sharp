using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MaterialData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MaterialModel>> getMateriales()
        {
            var list = new List<MaterialModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMateriales", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var material = new MaterialModel();
                            material.empresa = (string)reader["empresa"];
                            material.id_solicitante = (int)reader["id_solicitante"];
                            material.nombre_solicitante = (string)reader["nombre_solicitante"];
                            material.fecha_creacion = (DateTime)reader["fecha_creacion"];
                            material.id_modificador = (int)reader["id_modificador"];
                            material.nombre_modificador = (string)reader["nombre_modificador"];
                            material.fecha_modificacion = (DateTime)reader["fecha_modificacion"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            if (reader["marca"] != DBNull.Value)
                            {
                                material.marca = (string)reader["marca"];
                            }
                            material.nombre = (string)reader["nombre"];
                            if (reader["parte_modelo"] != DBNull.Value)
                            {
                                material.parte_modelo = (string)reader["parte_modelo"];
                            }
                            if (reader["nombre_comun"] != DBNull.Value)
                            {
                                material.nombre_comun = (string)reader["nombre_comun"];
                            }
                            if (reader["medida"] != DBNull.Value)
                            {
                                material.medida = (string)reader["medida"];
                            }
                            if (reader["ing_activo"] != DBNull.Value)
                            {
                                material.ing_activo = (string)reader["ing_activo"];
                            }
                            if (reader["tipo_producto"] != DBNull.Value)
                            {
                                material.tipo_producto = (string)reader["tipo_producto"];
                            }
                            if (reader["alias"] != DBNull.Value)
                            {
                                material.alias = (string)reader["alias"];
                            }
                            material.unidad = (string)reader["unidad"];
                            if (reader["iva"] != DBNull.Value)
                            {
                                material.iva = (string)reader["iva"];
                            }
                            if (reader["ieps"] != DBNull.Value)
                            {
                                material.ieps = (string)reader["ieps"];
                            }
                            if (reader["proposito"] != DBNull.Value)
                            {
                                material.proposito = (string)reader["proposito"];
                            }
                            if (reader["es_importado"] != DBNull.Value)
                            {
                                material.es_importado = (bool)reader["es_importado"];
                            }
                            if (reader["es_material_empaque"] != DBNull.Value)
                            {
                                material.es_material_empaque = (bool)reader["es_material_empaque"];
                            }
                            if (reader["es_prod_terminado"] != DBNull.Value)
                            {
                                material.es_prod_terminado = (bool)reader["es_prod_terminado"];
                            }
                            material.compras = (bool)reader["compras"];
                            material.finanzas = (bool)reader["finanzas"];
                            material.sistemas = (bool)reader["sistemas"];
                            material.aprobado = (bool)reader["aprobado"];
                            material.rechazado_compras = (bool)reader["rechazado_compras"];
                            material.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            material.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                material.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(material);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialModel>> getMaterialById(int id)
        {
            var list = new List<MaterialModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialById", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var material = new MaterialModel();
                            material.empresa = (string)reader["empresa"];
                            material.id_solicitante = (int)reader["id_solicitante"];
                            material.nombre_solicitante = (string)reader["nombre_solicitante"];
                            material.fecha_creacion = (DateTime)reader["fecha_creacion"];
                            material.id_modificador = (int)reader["id_modificador"];
                            material.nombre_modificador = (string)reader["nombre_modificador"];
                            material.fecha_modificacion = (DateTime)reader["fecha_modificacion"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            if (reader["marca"] != DBNull.Value)
                            {
                                material.marca = (string)reader["marca"];
                            }
                            material.nombre = (string)reader["nombre"];
                            if (reader["parte_modelo"] != DBNull.Value)
                            {
                                material.parte_modelo = (string)reader["parte_modelo"];
                            }
                            if (reader["nombre_comun"] != DBNull.Value)
                            {
                                material.nombre_comun = (string)reader["nombre_comun"];
                            }
                            if (reader["medida"] != DBNull.Value)
                            {
                                material.medida = (string)reader["medida"];
                            }
                            if (reader["ing_activo"] != DBNull.Value)
                            {
                                material.ing_activo = (string)reader["ing_activo"];
                            }
                            if (reader["tipo_producto"] != DBNull.Value)
                            {
                                material.tipo_producto = (string)reader["tipo_producto"];
                            }
                            if (reader["alias"] != DBNull.Value)
                            {
                                material.alias = (string)reader["alias"];
                            }
                            material.unidad = (string)reader["unidad"];
                            if (reader["iva"] != DBNull.Value)
                            {
                                material.iva = (string)reader["iva"];
                            }
                            if (reader["ieps"] != DBNull.Value)
                            {
                                material.ieps = (string)reader["ieps"];
                            }
                            if (reader["proposito"] != DBNull.Value)
                            {
                                material.proposito = (string)reader["proposito"];
                            }
                            if (reader["es_importado"] != DBNull.Value)
                            {
                                material.es_importado = (bool)reader["es_importado"];
                            }
                            if (reader["es_material_empaque"] != DBNull.Value)
                            {
                                material.es_material_empaque = (bool)reader["es_material_empaque"];
                            }
                            if (reader["es_prod_terminado"] != DBNull.Value)
                            {
                                material.es_prod_terminado = (bool)reader["es_prod_terminado"];
                            }
                            material.compras = (bool)reader["compras"];
                            material.finanzas = (bool)reader["finanzas"];
                            material.sistemas = (bool)reader["sistemas"];
                            material.aprobado = (bool)reader["aprobado"];
                            material.rechazado_compras = (bool)reader["rechazado_compras"];
                            material.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            material.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                material.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(material);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialModel>> getMaterialesCompras()
        {
            var list = new List<MaterialModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialesCompras", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var material = new MaterialModel();
                            material.empresa = (string)reader["empresa"];
                            material.id_solicitante = (int)reader["id_solicitante"];
                            material.nombre_solicitante = (string)reader["nombre_solicitante"];
                            material.fecha_creacion = (DateTime)reader["fecha_creacion"];
                            material.id_modificador = (int)reader["id_modificador"];
                            material.nombre_modificador = (string)reader["nombre_modificador"];
                            material.fecha_modificacion = (DateTime)reader["fecha_modificacion"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            if (reader["marca"] != DBNull.Value)
                            {
                                material.marca = (string)reader["marca"];
                            }
                            material.nombre = (string)reader["nombre"];
                            if (reader["parte_modelo"] != DBNull.Value)
                            {
                                material.parte_modelo = (string)reader["parte_modelo"];
                            }
                            if (reader["nombre_comun"] != DBNull.Value)
                            {
                                material.nombre_comun = (string)reader["nombre_comun"];
                            }
                            if (reader["medida"] != DBNull.Value)
                            {
                                material.medida = (string)reader["medida"];
                            }
                            if (reader["ing_activo"] != DBNull.Value)
                            {
                                material.ing_activo = (string)reader["ing_activo"];
                            }
                            if (reader["tipo_producto"] != DBNull.Value)
                            {
                                material.tipo_producto = (string)reader["tipo_producto"];
                            }
                            if (reader["alias"] != DBNull.Value)
                            {
                                material.alias = (string)reader["alias"];
                            }
                            material.unidad = (string)reader["unidad"];
                            if (reader["iva"] != DBNull.Value)
                            {
                                material.iva = (string)reader["iva"];
                            }
                            if (reader["ieps"] != DBNull.Value)
                            {
                                material.ieps = (string)reader["ieps"];
                            }
                            if (reader["proposito"] != DBNull.Value)
                            {
                                material.proposito = (string)reader["proposito"];
                            }
                            if (reader["es_importado"] != DBNull.Value)
                            {
                                material.es_importado = (bool)reader["es_importado"];
                            }
                            if (reader["es_material_empaque"] != DBNull.Value)
                            {
                                material.es_material_empaque = (bool)reader["es_material_empaque"];
                            }
                            if (reader["es_prod_terminado"] != DBNull.Value)
                            {
                                material.es_prod_terminado = (bool)reader["es_prod_terminado"];
                            }
                            material.compras = (bool)reader["compras"];
                            material.finanzas = (bool)reader["finanzas"];
                            material.sistemas = (bool)reader["sistemas"];
                            material.aprobado = (bool)reader["aprobado"];
                            material.rechazado_compras = (bool)reader["rechazado_compras"];
                            material.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            material.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                material.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(material);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialModel>> getMaterialesFinanzas()
        {
            var list = new List<MaterialModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialesFinanzas", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var material = new MaterialModel();
                            material.empresa = (string)reader["empresa"];
                            material.id_solicitante = (int)reader["id_solicitante"];
                            material.nombre_solicitante = (string)reader["nombre_solicitante"];
                            material.fecha_creacion = (DateTime)reader["fecha_creacion"];
                            material.id_modificador = (int)reader["id_modificador"];
                            material.nombre_modificador = (string)reader["nombre_modificador"];
                            material.fecha_modificacion = (DateTime)reader["fecha_modificacion"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            if (reader["marca"] != DBNull.Value)
                            {
                                material.marca = (string)reader["marca"];
                            }
                            material.nombre = (string)reader["nombre"];
                            if (reader["parte_modelo"] != DBNull.Value)
                            {
                                material.parte_modelo = (string)reader["parte_modelo"];
                            }
                            if (reader["nombre_comun"] != DBNull.Value)
                            {
                                material.nombre_comun = (string)reader["nombre_comun"];
                            }
                            if (reader["medida"] != DBNull.Value)
                            {
                                material.medida = (string)reader["medida"];
                            }
                            if (reader["ing_activo"] != DBNull.Value)
                            {
                                material.ing_activo = (string)reader["ing_activo"];
                            }
                            if (reader["tipo_producto"] != DBNull.Value)
                            {
                                material.tipo_producto = (string)reader["tipo_producto"];
                            }
                            if (reader["alias"] != DBNull.Value)
                            {
                                material.alias = (string)reader["alias"];
                            }
                            material.unidad = (string)reader["unidad"];
                            if (reader["iva"] != DBNull.Value)
                            {
                                material.iva = (string)reader["iva"];
                            }
                            if (reader["ieps"] != DBNull.Value)
                            {
                                material.ieps = (string)reader["ieps"];
                            }
                            if (reader["proposito"] != DBNull.Value)
                            {
                                material.proposito = (string)reader["proposito"];
                            }
                            if (reader["es_importado"] != DBNull.Value)
                            {
                                material.es_importado = (bool)reader["es_importado"];
                            }
                            if (reader["es_material_empaque"] != DBNull.Value)
                            {
                                material.es_material_empaque = (bool)reader["es_material_empaque"];
                            }
                            if (reader["es_prod_terminado"] != DBNull.Value)
                            {
                                material.es_prod_terminado = (bool)reader["es_prod_terminado"];
                            }
                            material.compras = (bool)reader["compras"];
                            material.finanzas = (bool)reader["finanzas"];
                            material.sistemas = (bool)reader["sistemas"];
                            material.aprobado = (bool)reader["aprobado"];
                            material.rechazado_compras = (bool)reader["rechazado_compras"];
                            material.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            material.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                material.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(material);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialModel>> getMaterialesSistemas()
        {
            var list = new List<MaterialModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialesSistemas", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var material = new MaterialModel();
                            material.empresa = (string)reader["empresa"];
                            material.id_solicitante = (int)reader["id_solicitante"];
                            material.nombre_solicitante = (string)reader["nombre_solicitante"];
                            material.fecha_creacion = (DateTime)reader["fecha_creacion"];
                            material.id_modificador = (int)reader["id_modificador"];
                            material.nombre_modificador = (string)reader["nombre_modificador"];
                            material.fecha_modificacion = (DateTime)reader["fecha_modificacion"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            if (reader["marca"] != DBNull.Value)
                            {
                                material.marca = (string)reader["marca"];
                            }
                            material.nombre = (string)reader["nombre"];
                            if (reader["parte_modelo"] != DBNull.Value)
                            {
                                material.parte_modelo = (string)reader["parte_modelo"];
                            }
                            if (reader["nombre_comun"] != DBNull.Value)
                            {
                                material.nombre_comun = (string)reader["nombre_comun"];
                            }
                            if (reader["medida"] != DBNull.Value)
                            {
                                material.medida = (string)reader["medida"];
                            }
                            if (reader["ing_activo"] != DBNull.Value)
                            {
                                material.ing_activo = (string)reader["ing_activo"];
                            }
                            if (reader["tipo_producto"] != DBNull.Value)
                            {
                                material.tipo_producto = (string)reader["tipo_producto"];
                            }
                            if (reader["alias"] != DBNull.Value)
                            {
                                material.alias = (string)reader["alias"];
                            }
                            material.unidad = (string)reader["unidad"];
                            if (reader["iva"] != DBNull.Value)
                            {
                                material.iva = (string)reader["iva"];
                            }
                            if (reader["ieps"] != DBNull.Value)
                            {
                                material.ieps = (string)reader["ieps"];
                            }
                            if (reader["proposito"] != DBNull.Value)
                            {
                                material.proposito = (string)reader["proposito"];
                            }
                            if (reader["es_importado"] != DBNull.Value)
                            {
                                material.es_importado = (bool)reader["es_importado"];
                            }
                            if (reader["es_material_empaque"] != DBNull.Value)
                            {
                                material.es_material_empaque = (bool)reader["es_material_empaque"];
                            }
                            if (reader["es_prod_terminado"] != DBNull.Value)
                            {
                                material.es_prod_terminado = (bool)reader["es_prod_terminado"];
                            }
                            material.compras = (bool)reader["compras"];
                            material.finanzas = (bool)reader["finanzas"];
                            material.sistemas = (bool)reader["sistemas"];
                            material.aprobado = (bool)reader["aprobado"];
                            material.rechazado_compras = (bool)reader["rechazado_compras"];
                            material.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            material.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                material.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(material);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialModel>> getMaterialesByIdSolicitante(int id_solicitante)
        {
            var list = new List<MaterialModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialesByIdSolicitante", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id_solicitante", id_solicitante);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var material = new MaterialModel();
                            material.empresa = (string)reader["empresa"];
                            material.id_solicitante = (int)reader["id_solicitante"];
                            material.nombre_solicitante = (string)reader["nombre_solicitante"];
                            material.fecha_creacion = (DateTime)reader["fecha_creacion"];
                            material.id_modificador = (int)reader["id_modificador"];
                            material.nombre_modificador = (string)reader["nombre_modificador"];
                            material.fecha_modificacion = (DateTime)reader["fecha_modificacion"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            if (reader["marca"] != DBNull.Value)
                            {
                                material.marca = (string)reader["marca"];
                            }
                            material.nombre = (string)reader["nombre"];
                            if (reader["parte_modelo"] != DBNull.Value)
                            {
                                material.parte_modelo = (string)reader["parte_modelo"];
                            }
                            if (reader["nombre_comun"] != DBNull.Value)
                            {
                                material.nombre_comun = (string)reader["nombre_comun"];
                            }
                            if (reader["medida"] != DBNull.Value)
                            {
                                material.medida = (string)reader["medida"];
                            }
                            if (reader["ing_activo"] != DBNull.Value)
                            {
                                material.ing_activo = (string)reader["ing_activo"];
                            }
                            if (reader["tipo_producto"] != DBNull.Value)
                            {
                                material.tipo_producto = (string)reader["tipo_producto"];
                            }
                            if (reader["alias"] != DBNull.Value)
                            {
                                material.alias = (string)reader["alias"];
                            }
                            material.unidad = (string)reader["unidad"];
                            if (reader["iva"] != DBNull.Value)
                            {
                                material.iva = (string)reader["iva"];
                            }
                            if (reader["ieps"] != DBNull.Value)
                            {
                                material.ieps = (string)reader["ieps"];
                            }
                            if (reader["proposito"] != DBNull.Value)
                            {
                                material.proposito = (string)reader["proposito"];
                            }
                            if (reader["es_importado"] != DBNull.Value)
                            {
                                material.es_importado = (bool)reader["es_importado"];
                            }
                            if (reader["es_material_empaque"] != DBNull.Value)
                            {
                                material.es_material_empaque = (bool)reader["es_material_empaque"];
                            }
                            if (reader["es_prod_terminado"] != DBNull.Value)
                            {
                                material.es_prod_terminado = (bool)reader["es_prod_terminado"];
                            }
                            material.compras = (bool)reader["compras"];
                            material.finanzas = (bool)reader["finanzas"];
                            material.sistemas = (bool)reader["sistemas"];
                            material.aprobado = (bool)reader["aprobado"];
                            material.rechazado_compras = (bool)reader["rechazado_compras"];
                            material.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            material.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            if (reader["comentarios"] != DBNull.Value)
                            {
                                material.comentarios = (string)reader["comentarios"];
                            }
                            list.Add(material);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task postMaterial(MaterialModel material)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("postMaterial", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empresa", material.empresa);
                    cmd.Parameters.AddWithValue("@id_solicitante", material.id_solicitante);
                    cmd.Parameters.AddWithValue("@nombre_solicitante", material.nombre_solicitante);
                    cmd.Parameters.AddWithValue("@fecha_creacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id_modificador", material.id_modificador);
                    cmd.Parameters.AddWithValue("@nombre_modificador", material.nombre_modificador);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@familia", material.familia);
                    cmd.Parameters.AddWithValue("@subfamilia", material.subfamilia);
                    if (!string.IsNullOrEmpty(material.marca))
                    {
                        cmd.Parameters.AddWithValue("@marca", material.marca);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@marca", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@nombre", material.nombre);
                    if (!string.IsNullOrEmpty(material.parte_modelo))
                    {
                        cmd.Parameters.AddWithValue("@parte_modelo", material.parte_modelo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@parte_modelo", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.nombre_comun))
                    {
                        cmd.Parameters.AddWithValue("@nombre_comun", material.nombre_comun);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@nombre_comun", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.medida))
                    {
                        cmd.Parameters.AddWithValue("@medida", material.medida);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@medida", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.ing_activo))
                    {
                        cmd.Parameters.AddWithValue("@ing_activo", material.ing_activo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ing_activo", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.tipo_producto))
                    {
                        cmd.Parameters.AddWithValue("@tipo_producto", material.tipo_producto);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tipo_producto", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.alias))
                    {
                        cmd.Parameters.AddWithValue("@alias", material.alias);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@alias", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@unidad", material.unidad);
                    if (!string.IsNullOrEmpty(material.iva))
                    {
                        cmd.Parameters.AddWithValue("@iva", material.iva);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@iva", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.ieps))
                    {
                        cmd.Parameters.AddWithValue("@ieps", material.ieps);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ieps", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@proposito", material.proposito);
                    cmd.Parameters.AddWithValue("@es_importado", material.es_importado);
                    cmd.Parameters.AddWithValue("@es_material_empaque", material.es_material_empaque);
                    cmd.Parameters.AddWithValue("@es_prod_terminado", material.es_prod_terminado);
                    cmd.Parameters.AddWithValue("@compras", true);
                    cmd.Parameters.AddWithValue("@finanzas", false);
                    cmd.Parameters.AddWithValue("@sistemas", false);
                    cmd.Parameters.AddWithValue("@aprobado", false);
                    cmd.Parameters.AddWithValue("@rechazado_compras", false);
                    cmd.Parameters.AddWithValue("@rechazado_finanzas", false);
                    cmd.Parameters.AddWithValue("@rechazado_sistemas", false);
                    if (!string.IsNullOrEmpty(material.comentarios))
                    {
                        cmd.Parameters.AddWithValue("@comentarios", material.comentarios);
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

        public async Task putMaterial(int id, MaterialModel material)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("putMaterial", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("@empresa", material.empresa);
                    cmd.Parameters.AddWithValue("@id_modificador", material.id_modificador);
                    cmd.Parameters.AddWithValue("@nombre_modificador", material.nombre_modificador);
                    cmd.Parameters.AddWithValue("@fecha_modificacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@familia", material.familia);
                    cmd.Parameters.AddWithValue("@subfamilia", material.subfamilia);
                    if (!string.IsNullOrEmpty(material.marca))
                    {
                        cmd.Parameters.AddWithValue("@marca", material.marca);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@marca", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@nombre", material.nombre);
                    if (!string.IsNullOrEmpty(material.parte_modelo))
                    {
                        cmd.Parameters.AddWithValue("@parte_modelo", material.parte_modelo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@parte_modelo", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.nombre_comun))
                    {
                        cmd.Parameters.AddWithValue("@nombre_comun", material.nombre_comun);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@nombre_comun", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.medida))
                    {
                        cmd.Parameters.AddWithValue("@medida", material.medida);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@medida", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.ing_activo))
                    {
                        cmd.Parameters.AddWithValue("@ing_activo", material.ing_activo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ing_activo", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.tipo_producto))
                    {
                        cmd.Parameters.AddWithValue("@tipo_producto", material.tipo_producto);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tipo_producto", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.alias))
                    {
                        cmd.Parameters.AddWithValue("@alias", material.alias);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@alias", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@unidad", material.unidad);
                    if (!string.IsNullOrEmpty(material.iva))
                    {
                        cmd.Parameters.AddWithValue("@iva", material.iva);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@iva", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(material.ieps))
                    {
                        cmd.Parameters.AddWithValue("@ieps", material.ieps);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ieps", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@proposito", material.proposito);
                    cmd.Parameters.AddWithValue("@es_importado", material.es_importado);
                    cmd.Parameters.AddWithValue("@es_material_empaque", material.es_material_empaque);
                    cmd.Parameters.AddWithValue("@es_prod_terminado", material.es_prod_terminado);
                    cmd.Parameters.AddWithValue("@compras", material.compras);
                    cmd.Parameters.AddWithValue("@finanzas", material.finanzas);
                    cmd.Parameters.AddWithValue("@sistemas", material.sistemas);
                    cmd.Parameters.AddWithValue("@aprobado", material.aprobado);
                    cmd.Parameters.AddWithValue("@rechazado_compras", material.rechazado_compras);
                    cmd.Parameters.AddWithValue("@rechazado_finanzas", material.rechazado_finanzas);
                    cmd.Parameters.AddWithValue("@rechazado_sistemas", material.rechazado_sistemas);
                    if (!string.IsNullOrEmpty(material.comentarios))
                    {
                        cmd.Parameters.AddWithValue("@comentarios", material.comentarios);
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

        public async Task deleteMaterial(int id)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("deleteMaterial", sql))
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
