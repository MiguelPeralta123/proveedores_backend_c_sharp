namespace ProveedoresBackendCSharp.Models
{
    public class MaterialModel
    {
        public MaterialModel() { }
        public string id_solicitud { get; set; }
        public string nombre { get; set; }
        public string producto_servicio { get; set; }
        public string tipo { get; set; }
        public string familia { get; set; }
        public string subfamilia { get; set; }
        public string unidad_medida { get; set; }
        public bool aprobado_compras { get; set; }
        public bool aprobado_finanzas { get; set; }
        public bool aprobado_sistemas { get; set; }
        public bool rechazado_compras { get; set; }
        public bool rechazado_finanzas { get; set; }
        public bool rechazado_sistemas { get; set; }
        public string? comentarios { get; set; }
    }
}
