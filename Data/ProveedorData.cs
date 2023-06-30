using ProveedoresBackendCSharp.Connection;
using ProveedoresBackendCSharp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProveedoresBackendCSharp.Data
{
    public class ProveedorData
    {
        ConnectionDB cn = new ConnectionDB();

        public async Task<List<ProveedorModel>> getProveedores()
        {
            var list = new List<ProveedorModel>();
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("getProveedores_provisionales", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var proveedor = new ProveedorModel();
                            proveedor.empresa = (string)reader["empresa"];
                            proveedor.nombre = (string)reader["nombre"];
                            proveedor.limite_credito = (int)reader["limite_credito"];
                            proveedor.compras = (bool)reader["compras"];
                            proveedor.nombre_constancia = (string)reader["nombre_constancia"];
                            proveedor.ruta_constancia = (string)reader["ruta_constancia"];
                            proveedor.nombre_estado_cuenta = (string)reader["nombre_estado_cuenta"];
                            proveedor.ruta_estado_cuenta = (string)reader["ruta_estado_cuenta"];
                            list.Add(proveedor);
                        }
                        return list;
                    }
                }
            }
        }

        // CODIGO DE CHATGPT

        public async Task postProveedor(ProveedorModel proveedor)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("postProveedorProvisional", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empresa", proveedor.empresa);
                    cmd.Parameters.AddWithValue("@nombre", proveedor.nombre);
                    cmd.Parameters.AddWithValue("@limite_credito", proveedor.limite_credito);
                    cmd.Parameters.AddWithValue("@compras", proveedor.compras);
                    cmd.Parameters.AddWithValue("@nombre_constancia", proveedor.nombre_constancia);
                    cmd.Parameters.AddWithValue("@ruta_constancia", proveedor.ruta_constancia);
                    cmd.Parameters.AddWithValue("@nombre_estado_cuenta", proveedor.nombre_estado_cuenta);
                    cmd.Parameters.AddWithValue("@ruta_estado_cuenta", proveedor.ruta_estado_cuenta);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // AQUI TERMINA CHATGPT
    }
}
