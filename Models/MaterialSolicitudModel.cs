namespace ProveedoresBackendCSharp.Models
{
    public class MaterialSolicitudModel
    {
        public MaterialSolicitudModel() { }
        public string id_solicitud { get; set; }
        public string empresa { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha { get; set; }
        public bool aprobado_compras { get; set; }
        public bool aprobado_finanzas { get; set; }
        public bool aprobado_sistemas { get; set; }
        public bool rechazado_compras { get; set; }
        public bool rechazado_finanzas { get; set; }
        public bool rechazado_sistemas { get; set; }
        public string justificacion { get; set; }
    }
}
