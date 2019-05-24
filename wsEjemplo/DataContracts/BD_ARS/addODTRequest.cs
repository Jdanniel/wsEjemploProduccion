using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace wsEjemplo.DataContracts.BD_ARS
{
    [DataContract]
    public class addODTRequest
    {
        [DataMember]
        public string ArOdt { get; set; }
        [DataMember]
        public string TipoServicio { get; set; }
        [DataMember]
        public string SubtipoServicio { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Afiliacion { get; set; }
        [DataMember]
        public string Comercio { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        public string Colonia { get; set; }
        [DataMember]
        public string Poblacion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Cp { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string Rfc { get; set; }
        [DataMember]
        public string Proveedor { get; set; }
        [DataMember]
        public string FechaEnvio { get; set; }
        [DataMember]
        public string AfilAmex { get; set; }
        [DataMember]
        public string IdAmex { get; set; }
        [DataMember]
        public string Producto { get; set; }
        [DataMember]
        public string NumRollos { get; set; }
        [DataMember]
        public string IdCaja { get; set; }
        [DataMember]
        public string Contacto1 { get; set; }
        [DataMember]
        public string Contacto2 { get; set; }
        [DataMember]
        public string EmailServ { get; set; }
        [DataMember]
        public string EmailEjecutivo { get; set; }
        [DataMember]
        public string EmailRespuesta { get; set; }
        [DataMember]
        public string Proyecto { get; set; }
        [DataMember]
        public string PreOdt { get; set; }
        [DataMember]
        public string Mcc { get; set; }
        [DataMember]
        public string Canal { get; set; }
        [DataMember]
        public string EjecutivoKA { get; set; }
        [DataMember]
        public string EmailEjecutivoKA { get; set; }
        [DataMember]
        public string EjecutivoSucursal { get; set; }
        [DataMember]
        public string Sucursal { get; set; }
        [DataMember]
        public string TelEjecutivo { get; set; }
        [DataMember]
        public string TelSucursal { get; set; }
        [DataMember]
        public string ContactoComercio { get; set; }
        [DataMember]
        public string ReferenciaUbicacion { get; set; }
        [DataMember]
        public string HorarioAtencion { get; set; }
        [DataMember]
        public string DiasAtencion { get; set; }
        [DataMember]
        public string CodigoProducto { get; set; }
        [DataMember]
        public string ModeloTPV { get; set; }
        [DataMember]
        public string Carga { get; set; }
        [DataMember]
        public string FolioTelecarga { get; set; }
        [DataMember]
        public string Conectividad { get; set; }
    }
}