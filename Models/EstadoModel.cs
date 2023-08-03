namespace ProveedoresBackendCSharp.Models
{
    public class EstadoModel
    {
        public EstadoModel(string pais, string estado)
        {
            this.pais = pais;
            this.estado = estado;
        }
        public string pais { get; set; }
        public string estado { get; set; }
    }
}
