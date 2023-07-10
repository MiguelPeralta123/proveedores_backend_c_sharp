using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class MaterialUnidadMedidaData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<MaterialUnidadMedidaModel>> getUnidadesMedida()
        {
            var list = new List<MaterialUnidadMedidaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialUnidadMedida", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var unidad_medida = new MaterialUnidadMedidaModel((string)reader["tipo"], (string)reader["unidad_medida"], (string)reader["abreviatura"]);
                            list.Add(unidad_medida);
                        }
                        return list;
                    }
                }
            }
        }

        public async Task<List<MaterialUnidadMedidaModel>> getUnidadesMedidaByTipo(string tipo)
        {
            var list = new List<MaterialUnidadMedidaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getMaterialUnidadMedidaByTipo", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var unidad_medida = new MaterialUnidadMedidaModel((string)reader["tipo"], (string)reader["unidad_medida"], (string)reader["abreviatura"]);
                            list.Add(unidad_medida);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
