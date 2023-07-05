namespace ProveedoresBackendCSharp.Models
{
    public class UsuarioModel
    {
        public UsuarioModel() { }
        public int? id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? nombre { get; set; }
        public string? puesto { get; set; }
        public string? correo { get; set; }
        public bool? comprador { get; set; }
        public bool? aprob_compras { get; set; }
        public bool? aprob_finanzas { get; set; }
        public bool aprob_sistemas { get; set; }
        public bool? admin { get; set; }
    }
}
