using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace wsEjemplo.DataContracts.BD_ARS
{
    [DataContract]
    public class RespuestaReplicasContract
    {
        [DataMember]
        public string CONCLUSION { get; set; }
        [DataMember]
        public string ODT { get; set; }
        [DataMember]
        public string FECHACONCLUIDO { get; set; }
        [DataMember]
        public string MOTIVO { get; set; }
        [DataMember]
        public string ESTATUS { get; set; }
        [DataMember]
        public string FECHAALTA { get; set; }
    }
}