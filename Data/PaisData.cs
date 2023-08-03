using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class PaisData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<PaisModel>> getPaises()
        {
            var list = new List<PaisModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getPaises", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var pais = new PaisModel((string)reader["pais"]);
                            list.Add(pais);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
