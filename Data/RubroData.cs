using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class RubroData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<RubroModel>> getRubros()
        {
            var list = new List<RubroModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getRubros", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var rubro = new RubroModel((string)reader["rubro"]);
                            list.Add(rubro);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
