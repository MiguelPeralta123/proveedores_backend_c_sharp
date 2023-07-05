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
                            material.id_solicitud = (string)reader["id_solicitud"];
                            material.nombre = (string)reader["nombre"];
                            material.producto_servicio = (string)reader["producto_servicio"];
                            material.tipo = (string)reader["tipo"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            material.unidad_medida = (string)reader["unidad_medida"];
                            material.aprobado_compras = (bool)reader["aprobado_compras"];
                            material.aprobado_finanzas = (bool)reader["aprobado_finanzas"];
                            material.aprobado_sistemas = (bool)reader["aprobado_sistemas"];
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
                            material.id_solicitud = (string)reader["id_solicitud"];
                            material.nombre = (string)reader["nombre"];
                            material.producto_servicio = (string)reader["producto_servicio"];
                            material.tipo = (string)reader["tipo"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            material.unidad_medida = (string)reader["unidad_medida"];
                            material.aprobado_compras = (bool)reader["aprobado_compras"];
                            material.aprobado_finanzas = (bool)reader["aprobado_finanzas"];
                            material.aprobado_sistemas = (bool)reader["aprobado_sistemas"];
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

        public async Task<List<MaterialModel>> getMaterialByIdSolicitud(string id_solicitud)
        {
            var list = new List<MaterialModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialByIdSolicitud", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id_solicitud", id_solicitud);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var material = new MaterialModel();
                            material.id_solicitud = (string)reader["id_solicitud"];
                            material.nombre = (string)reader["nombre"];
                            material.producto_servicio = (string)reader["producto_servicio"];
                            material.tipo = (string)reader["tipo"];
                            material.familia = (string)reader["familia"];
                            material.subfamilia = (string)reader["subfamilia"];
                            material.unidad_medida = (string)reader["unidad_medida"];
                            material.aprobado_compras = (bool)reader["aprobado_compras"];
                            material.aprobado_finanzas = (bool)reader["aprobado_finanzas"];
                            material.aprobado_sistemas = (bool)reader["aprobado_sistemas"];
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
                    cmd.Parameters.AddWithValue("@id_solicitud", material.id_solicitud);
                    cmd.Parameters.AddWithValue("@nombre", material.nombre);
                    cmd.Parameters.AddWithValue("@producto_servicio", material.producto_servicio);
                    cmd.Parameters.AddWithValue("@tipo", material.tipo);
                    cmd.Parameters.AddWithValue("@familia", material.familia);
                    cmd.Parameters.AddWithValue("@subfamilia", material.subfamilia);
                    cmd.Parameters.AddWithValue("@unidad_medida", material.unidad_medida);
                    cmd.Parameters.AddWithValue("@aprobado_compras", false);
                    cmd.Parameters.AddWithValue("@aprobado_finanzas", false);
                    cmd.Parameters.AddWithValue("@aprobado_sistemas", false);
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
                    cmd.Parameters.AddWithValue("@nombre", material.nombre);
                    cmd.Parameters.AddWithValue("@producto_servicio", material.producto_servicio);
                    cmd.Parameters.AddWithValue("@tipo", material.tipo);
                    cmd.Parameters.AddWithValue("@familia", material.familia);
                    cmd.Parameters.AddWithValue("@subfamilia", material.subfamilia);
                    cmd.Parameters.AddWithValue("@unidad_medida", material.unidad_medida);
                    cmd.Parameters.AddWithValue("@aprobado_compras", false);
                    cmd.Parameters.AddWithValue("@aprobado_finanzas", false);
                    cmd.Parameters.AddWithValue("@aprobado_sistemas", false);
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
