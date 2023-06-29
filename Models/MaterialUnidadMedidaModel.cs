namespace ProveedoresBackendCSharp.Models
{
    public class MaterialUnidadMedidaModel
    {
        public MaterialUnidadMedidaModel(string tipo, string unidad_medida)
        {
            this.tipo = tipo;
            this.unidad_medida = unidad_medida;
        }
        public string tipo { get; set; }
        public string unidad_medida { get; set; }
    }
}
