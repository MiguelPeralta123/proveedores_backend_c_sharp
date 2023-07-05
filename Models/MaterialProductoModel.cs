namespace ProveedoresBackendCSharp.Models
{
    public class MaterialProductoModel
    {
        public MaterialProductoModel(string subfamilia, string producto) 
        {
            this.subfamilia = subfamilia;
            this.producto = producto;
        }
        public string subfamilia { get; set; }
        public string producto { get; set; }
    }
}
