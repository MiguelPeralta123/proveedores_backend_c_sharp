using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MaterialSubfamiliaData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MaterialSubfamiliaModel>> getSubfamilias()
        {
            var list = new List<MaterialSubfamiliaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialSubfamilia", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var subfamilia = new MaterialSubfamiliaModel((string)reader["subfamilia"], (string)reader["producto"]);
                            list.Add(subfamilia);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
