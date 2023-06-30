namespace ProveedoresBackendCSharp.Models
{
    public class ProveedorModel
    {
        public ProveedorModel() { }
        /*public ProveedorModel(string empresa, string nombre, int limite_credito, bool compras)
        {
            this.empresa = empresa;
            this.nombre = nombre;
            this.limite_credito = limite_credito;
            this.compras = compras;
        }*/
        public string empresa { get; set; }
        public string nombre { get; set; }
        public int limite_credito { get; set; }
        public bool compras { get; set; }
        public string? ruta_constancia { get; set; }
        public string? nombre_constancia { get; set; }
        public string? ruta_estado_cuenta { get; set; }
        public string? nombre_estado_cuenta { get; set; }
    }
}
