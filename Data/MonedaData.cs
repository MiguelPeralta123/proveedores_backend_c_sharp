using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MonedaData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MonedaModel>> getMonedas()
        {
            var list = new List<MonedaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMoneda", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var moneda = new MonedaModel((string)reader["opcion"]);
                            list.Add(moneda);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
