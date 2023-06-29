using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class TipoOperacionData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<TipoOperacionModel>> getTipoOperacion()
        {
            var list = new List<TipoOperacionModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getTipoOperacion", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var tipo = new TipoOperacionModel((string)reader["tipo"]);
                            list.Add(tipo);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
