using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class UsuarioData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<UsuarioModel>> GetUsers()
        {
            var list = new List<UsuarioModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getUsuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var usuario = new UsuarioModel();
                            usuario.id = (int)reader["id"];
                            usuario.username = (string)reader["username"];
                            usuario.password = (string)reader["password"];
                            usuario.nombre = (string)reader["nombre"];
                            usuario.puesto = (string)reader["puesto"];
                            usuario.correo = (string)reader["correo"];
                            usuario.comprador = (bool)reader["comprador"];
                            usuario.aprob_compras = (bool)reader["aprob_compras"];
                            usuario.aprob_finanzas = (bool)reader["aprob_finanzas"];
                            usuario.aprob_sistemas = (bool)reader["aprob_sistemas"];
                            usuario.admin = (bool)reader["admin"];
                            list.Add(usuario);
                        }
                        return list;
                    }
                }
            }
        }

        /*
        public async Task postUser(UsuarioModel parameters)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("postUser", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("username", parameters.username);
                    cmd.Parameters.AddWithValue("password", parameters.password);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task putUser(UsuarioModel parameters)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("putUser", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parameters.id);
                    cmd.Parameters.AddWithValue("username", parameters.username);
                    cmd.Parameters.AddWithValue("password", parameters.password);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task deleteUser(int id)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("deleteUser", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<UsuarioModel>> getUserById(int id)
        {
            var list = new List<UsuarioModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getUserById", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var user = new UsuarioModel((string)reader["username"], (string)reader["password"]);
                            list.Add(user);
                        }
                        return list;
                    }
                }
            }
        }
        */
    }
}
