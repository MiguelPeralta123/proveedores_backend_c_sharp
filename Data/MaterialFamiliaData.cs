using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MaterialFamiliaData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MaterialFamiliaModel>> getFamilias()
        {
            var list = new List<MaterialFamiliaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialFamilias", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var familia = new MaterialFamiliaModel((string)reader["tipo"], (string)reader["familia"]);
                            list.Add(familia);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialFamiliaModel>> getFamiliasByTipo(string tipo)
        {
            var list = new List<MaterialFamiliaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialFamiliasByTipo", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var familia = new MaterialFamiliaModel((string)reader["tipo"], (string)reader["familia"]);
                            list.Add(familia);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
