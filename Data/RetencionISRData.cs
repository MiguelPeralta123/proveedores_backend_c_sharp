using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class RetencionISRData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<RetencionISRModel>> getOpciones()
        {
            var list = new List<RetencionISRModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getRetencionISR", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var opcion = new RetencionISRModel((string)reader["opcion"]);
                            list.Add(opcion);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
