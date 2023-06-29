namespace ProveedoresBackendCSharp.Models
{
    public class UsuarioModel
    {
        public UsuarioModel(string username, string password, string nombre, string puesto, string correo,
            bool comprador, bool aprob_compras, bool aprob_finanzas, bool aprob_sistemas, bool admin)
        {
            this.username = username;
            this.password = password;
            this.nombre = nombre;
            this.puesto = puesto;
            this.correo = correo;
            this.comprador = comprador;
            this.aprob_compras = aprob_compras;
            this.aprob_finanzas = aprob_finanzas;
            this.aprob_sistemas = aprob_sistemas;
            this.admin = admin;
        }
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string puesto { get; set; }
        public string correo { get; set; }
        public bool comprador { get; set; }
        public bool aprob_compras { get; set; }
        public bool aprob_finanzas { get; set; }
        public bool aprob_sistemas { get; set; }
        public bool admin { get; set; }
    }
}
