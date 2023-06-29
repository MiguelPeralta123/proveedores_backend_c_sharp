using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class RegimenFiscalData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<RegimenFiscalModel>> getRegimenes()
        {
            var list = new List<RegimenFiscalModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getRegimenFiscal", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var regimen = new RegimenFiscalModel((string)reader["tipo"]);
                            list.Add(regimen);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
