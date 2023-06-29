﻿using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class TipoAltaData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<TipoAltaModel>> getTipoAlta()
        {
            var list = new List<TipoAltaModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getTipoAlta", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var tipo = new TipoAltaModel((string)reader["tipo"]);
                            list.Add(tipo);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
