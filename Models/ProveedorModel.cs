namespace ProveedoresBackendCSharp.Models
{
    public class ProveedorModel
    {
        public ProveedorModel(string empresa, string nombre, int limite_credito, bool compras)
        {
            this.empresa = empresa;
            this.nombre = nombre;
            this.limite_credito = limite_credito;
            this.compras = compras;
        }
        public string empresa { get; set; }
        public string nombre { get; set; }
        public int limite_credito { get; set; }
        public bool compras { get; set; }
    }
}
