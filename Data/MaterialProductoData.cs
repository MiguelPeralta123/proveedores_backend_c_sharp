using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MaterialProductoData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MaterialProductoModel>> getProductos()
        {
            var list = new List<MaterialProductoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var producto = new MaterialProductoModel((string)reader["subfamilia"], (string)reader["producto"]);
                            list.Add(producto);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialProductoModel>> getProductosBySubfamilia(string subfamilia)
        {
            var list = new List<MaterialProductoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialProductosBySubfamilia", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("subfamilia", subfamilia);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var producto = new MaterialProductoModel((string)reader["subfamilia"], (string)reader["producto"]);
                            list.Add(producto);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
