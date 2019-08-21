using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace wsEjemplo.DataContracts.BD_ARS
{
    [DataContract]
    public class getOdtReplicaRequest
    {
        [DataMember]
        public string FecIni { get; set; }
        [DataMember]
        public string FecFin { get; set; }
    }
}