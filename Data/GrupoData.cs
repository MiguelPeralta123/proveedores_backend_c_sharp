using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class GrupoData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<GrupoModel>> getGrupos()
        {
            var list = new List<GrupoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getGrupos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var grupo = new GrupoModel((string)reader["grupo"]);
                            list.Add(grupo);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
