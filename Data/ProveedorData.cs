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
                            var proveedor = new ProveedorModel((string)reader["empresa"], (string)reader["nombre"], 
                                (int)reader["limite_credito"], (bool)reader["compras"]);
                            list.Add(proveedor);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
