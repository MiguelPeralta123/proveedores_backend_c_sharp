namespace ProveedoresBackendCSharp.Models
{
    public class MaterialSubfamiliaModel
    {
        public MaterialSubfamiliaModel(string familia, string subfamilia)
        {
            this.familia = familia;
            this.subfamilia = subfamilia;
        }
        public string familia { get; set; }
        public string subfamilia { get; set; }
    }
}
