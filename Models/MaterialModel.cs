namespace ProveedoresBackendCSharp.Models
{
    public class MaterialModel
    {
        public MaterialModel() { }
        public string empresa { get; set; }
        public int id_solicitante { get; set; }
        public string? nombre_solicitante { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int id_modificador { get; set; }
        public string? nombre_modificador { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string tipo_alta { get; set; }
        public string familia { get; set; }
        public string subfamilia { get; set; }
        public string? marca { get; set; }
        public string nombre { get; set; }
        public string? parte_modelo { get; set; }
        public string? nombre_comun { get; set; }
        public string? medida { get; set; }
        public string? ing_activo { get; set; }
        public string? tipo_producto { get; set; }
        public string? alias { get; set; }
        public string unidad { get; set; }
        public string? iva { get; set; }
        public string? ieps { get; set; }
        public string proposito { get; set; }
        public bool es_importado { get; set; }
        public bool es_material_empaque { get; set; }
        public bool es_prod_terminado { get; set; }
        public bool compras { get; set; }
        public bool finanzas { get; set; }
        public bool sistemas { get; set; }
        public bool aprobado { get; set; }
        public bool rechazado_compras { get; set; }
        public bool rechazado_finanzas { get; set; }
        public bool rechazado_sistemas { get; set; }
        public string? comentarios { get; set; }
    }
}
