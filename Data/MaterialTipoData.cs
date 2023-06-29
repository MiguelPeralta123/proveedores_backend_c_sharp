using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MaterialTipoData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MaterialTipoModel>> getTipos()
        {
            var list = new List<MaterialTipoModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialTipo", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var tipo = new MaterialTipoModel((string)reader["tipo"], (string)reader["familia"]);
                            list.Add(tipo);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
