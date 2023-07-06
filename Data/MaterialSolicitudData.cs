using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MaterialSolicitudData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MaterialSolicitudModel>> getMaterialSolicitudes()
        {
            var list = new List<MaterialSolicitudModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialSolicitudes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var solicitud = new MaterialSolicitudModel();
                            solicitud.id_solicitud = (string)reader["id_solicitud"];
                            solicitud.empresa = (string)reader["empresa"];
                            solicitud.id_solicitante = (int)reader["id_solicitante"];
                            solicitud.solicitante = (string)reader["solicitante"];
                            solicitud.fecha = (DateTime)reader["fecha"];
                            solicitud.aprobado_compras = (bool)reader["aprobado_compras"];
                            solicitud.aprobado_finanzas = (bool)reader["aprobado_finanzas"];
                            solicitud.aprobado_sistemas = (bool)reader["aprobado_sistemas"];
                            solicitud.rechazado_compras = (bool)reader["rechazado_compras"];
                            solicitud.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            solicitud.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            solicitud.justificacion = (string)reader["justificacion"];
                            list.Add(solicitud);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialSolicitudModel>> getMaterialSolicitudById(int id)
        {
            var list = new List<MaterialSolicitudModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialSolicitudById", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var solicitud = new MaterialSolicitudModel();
                            solicitud.id_solicitud = (string)reader["id_solicitud"];
                            solicitud.empresa = (string)reader["empresa"];
                            solicitud.id_solicitante = (int)reader["id_solicitante"];
                            solicitud.solicitante = (string)reader["solicitante"];
                            solicitud.fecha = (DateTime)reader["fecha"];
                            solicitud.aprobado_compras = (bool)reader["aprobado_compras"];
                            solicitud.aprobado_finanzas = (bool)reader["aprobado_finanzas"];
                            solicitud.aprobado_sistemas = (bool)reader["aprobado_sistemas"];
                            solicitud.rechazado_compras = (bool)reader["rechazado_compras"];
                            solicitud.rechazado_finanzas = (bool)reader["rechazado_finanzas"];
                            solicitud.rechazado_sistemas = (bool)reader["rechazado_sistemas"];
                            solicitud.justificacion = (string)reader["justificacion"];
                            list.Add(solicitud);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task postMaterialSolicitud(MaterialSolicitudModel solicitud)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("postMaterialSolicitud", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_solicitud", solicitud.id_solicitud);
                    cmd.Parameters.AddWithValue("@empresa", solicitud.empresa);
                    cmd.Parameters.AddWithValue("@id_solicitante", solicitud.id_solicitante);
                    cmd.Parameters.AddWithValue("@solicitante", solicitud.solicitante);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@aprobado_compras", false);
                    cmd.Parameters.AddWithValue("@aprobado_finanzas", false);
                    cmd.Parameters.AddWithValue("@aprobado_sistemas", false);
                    cmd.Parameters.AddWithValue("@rechazado_compras", false);
                    cmd.Parameters.AddWithValue("@rechazado_finanzas", false);
                    cmd.Parameters.AddWithValue("@rechazado_sistemas", false);
                    cmd.Parameters.AddWithValue("@justificacion", solicitud.justificacion);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task putMaterialSolicitud(int id, MaterialSolicitudModel solicitud)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("putMaterialSolicitud", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("@empresa", solicitud.empresa);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@aprobado_compras", solicitud.aprobado_compras);
                    cmd.Parameters.AddWithValue("@aprobado_finanzas", solicitud.aprobado_finanzas);
                    cmd.Parameters.AddWithValue("@aprobado_sistemas", solicitud.aprobado_sistemas);
                    cmd.Parameters.AddWithValue("@rechazado_compras", solicitud.rechazado_compras);
                    cmd.Parameters.AddWithValue("@rechazado_finanzas", solicitud.rechazado_finanzas);
                    cmd.Parameters.AddWithValue("@rechazado_sistemas", solicitud.rechazado_sistemas);
                    cmd.Parameters.AddWithValue("@justificacion", solicitud.justificacion);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task deleteMaterialSolicitud(int id)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("deleteMaterialSolicitud", sql))
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
