using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class RegimenCapitalData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<RegimenCapitalModel>> getRegimenes()
        {
            var list = new List<RegimenCapitalModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getRegimenCapital", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var regimen = new RegimenCapitalModel((string)reader["nombre"], (string)reader["clave"]);
                            list.Add(regimen);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
