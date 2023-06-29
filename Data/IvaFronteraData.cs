using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class IvaFronteraData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<IvaFronteraModel>> getIvaFrontera()
        {
            var list = new List<IvaFronteraModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getIvaFrontera", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var iva_frontera = new IvaFronteraModel((string)reader["opcion"]);
                            list.Add(iva_frontera);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
