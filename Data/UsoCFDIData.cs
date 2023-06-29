using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class UsoCFDIData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<UsoCFDIModel>> getUsoCFDI()
        {
            var list = new List<UsoCFDIModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getUsoCFDI", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var uso = new UsoCFDIModel((string)reader["nombre"]);
                            list.Add(uso);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
