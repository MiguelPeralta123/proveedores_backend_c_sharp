namespace ProveedoresBackendCSharp.Models
{
    public class MaterialFamiliaModel
    {
        public MaterialFamiliaModel(string familia, string subfamilia)
        {
            this.familia = familia;
            this.subfamilia = subfamilia;
        }
        public string familia { get; set; }
        public string subfamilia { get; set; }
    }
}
