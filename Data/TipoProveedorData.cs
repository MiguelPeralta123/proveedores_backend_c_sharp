using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class TipoProveedorData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<TipoProveedorModel>> getTipoProveedor()
        {
            var list = new List<TipoProveedorModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getTipoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var tipo = new TipoProveedorModel((string)reader["tipo"]);
                            list.Add(tipo);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
