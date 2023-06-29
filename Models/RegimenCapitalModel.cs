namespace ProveedoresBackendCSharp.Models
{
    public class RegimenCapitalModel
    {
        public RegimenCapitalModel(string nombre, string clave)
        {
            this.nombre = nombre;
            this.clave = clave;
        }
        public string nombre { get; set; }
        public string clave { get; set; }
    }
}
