using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProveedoresBackendCSharp.Data
{
    public class EmpresaData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<EmpresaModel>> getEmpresas()
        {
            var list = new List<EmpresaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getEmpresas", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var empresa = new EmpresaModel((string)reader["nombre"]);
                            list.Add(empresa);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
