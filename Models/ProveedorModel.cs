﻿namespace ProveedoresBackendCSharp.Models
{
    public class ProveedorModel
    {
        public ProveedorModel() { }
        public int id { get; set; }
        public string empresa { get; set; }
        public int? id_solicitante { get; set; }
        public string? nombre_solicitante { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int? id_modificador { get; set; }
        public string? nombre_modificador { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public string tipo_alta { get; set; }
        public string persona { get; set; }
        public string razon_social { get; set; }
        public string rfc { get; set; }
        public string? curp { get; set; }
        public string regimen_capital { get; set; }
        public string nombre_fiscal { get; set; }
        public string nombre_comercial { get; set; }
        public string uso_cfdi { get; set; }
        public string? representante_legal { get; set; }
        public string telefono_1 { get; set; }
        public string? telefono_2 { get; set; }
        public string? contacto { get; set; }
        public string grupo { get; set; }
        public string correo_general { get; set; }
        public string correo_pagos { get; set; }
        public string? sitio_web { get; set; }
        public string rubro { get; set; }
        public string tipo_operacion { get; set; }
        public string tipo_tercero { get; set; }
        public string id_fiscal { get; set; }
        public string regimen_fiscal { get; set; }
        public string agente_aduanal { get; set; }
        public string reg_inc_fiscal { get; set; }
        public string impuesto_cedular { get; set; }
        public DateTime venc_s_fecha { get; set; }
        public int dias_entrega_completa { get; set; }
        public int dias_credito { get; set; }
        public decimal limite_credito_MN { get; set; }
        public decimal limite_credito_ME { get; set; }
        public decimal monto_credito { get; set; }
        public string retencion_iva { get; set; }
        public string retencion_isr { get; set; }
        public string iva_frontera { get; set; }
        public string calle { get; set; }
        public string numero_exterior { get; set; }
        public string? numero_interior { get; set; }
        public string codigo_postal { get; set; }
        public string colonia { get; set; }
        public string localidad { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string banco { get; set; }
        public string cuenta { get; set; }
        public string moneda { get; set; }
        public string clabe { get; set; }
        public string? banco_2 { get; set; }
        public string? cuenta_2 { get; set; }
        public string? moneda_2 { get; set; }
        public string? clabe_2 { get; set; }
        public string? nombre_constancia { get; set; }
        public string? ruta_constancia { get; set; }
        public string? nombre_estado_cuenta { get; set; }
        public string? ruta_estado_cuenta { get; set; }
        public bool usar_portal_prov { get; set; }
        public bool no_aplica_rafaga { get; set; }
        public bool no_relacionar_oc { get; set; }
        public string folio { get; set; }
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
