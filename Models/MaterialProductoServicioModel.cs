namespace ProveedoresBackendCSharp.Models
{
    public class MaterialProductoServicioModel
    {
        public MaterialProductoServicioModel(string tipo)
        {
            this.tipo = tipo;
        }
        public string tipo { get; set; }
    }
}
