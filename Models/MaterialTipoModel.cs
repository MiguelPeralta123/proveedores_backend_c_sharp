namespace ProveedoresBackendCSharp.Models
{
    public class MaterialTipoModel
    {
        public MaterialTipoModel(string tipo, string familia) 
        {
            this.tipo = tipo;
            this.familia = familia;
        }
        public string tipo { get; set; }
        public string familia { get; set; }
    }
}
