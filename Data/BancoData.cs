using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class BancoData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<BancoModel>> getBancos()
        {
            var list = new List<BancoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getBancos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var banco = new BancoModel((string)reader["nombre"], (string)reader["clave"]);
                            list.Add(banco);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
