using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class RetencionIVAData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<RetencionIVAModel>> getOpciones()
        {
            var list = new List<RetencionIVAModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getRetencionIVA", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var opcion = new RetencionIVAModel((string)reader["opcion"]);
                            list.Add(opcion);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
