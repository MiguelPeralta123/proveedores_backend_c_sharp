using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class ContribuyenteData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<ContribuyenteModel>> getContribuyentes()
        {
            var list = new List<ContribuyenteModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getContribuyentes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var contribuyente = new ContribuyenteModel((string)reader["tipo"]);
                            list.Add(contribuyente);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
