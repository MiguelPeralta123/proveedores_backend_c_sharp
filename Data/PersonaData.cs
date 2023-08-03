using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class PersonaData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<PersonaModel>> getPersonas()
        {
            var list = new List<PersonaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getPersonas", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var persona = new PersonaModel((string)reader["persona"]);
                            list.Add(persona);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
