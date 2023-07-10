namespace ProveedoresBackendCSharp.Models
{
    public class MaterialUnidadMedidaModel
    {
        public MaterialUnidadMedidaModel(string tipo, string unidad_medida, string abreviatura)
        {
            this.tipo = tipo;
            this.unidad_medida = unidad_medida;
            this.abreviatura = abreviatura;
        }
        public string tipo { get; set; }
        public string unidad_medida { get; set; }
        public string abreviatura { get; set; }
    }
}
