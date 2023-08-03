using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class EstadoData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<EstadoModel>> getEstados()
        {
            var list = new List<EstadoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getEstados", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var estado = new EstadoModel((string)reader["pais"], (string)reader["estado"]);
                            list.Add(estado);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<EstadoModel>> getEstadosByPais(string pais)
        {
            var list = new List<EstadoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getEstadosByPais", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("pais", pais);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var estado = new EstadoModel((string)reader["pais"], (string)reader["estado"]);
                            list.Add(estado);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
