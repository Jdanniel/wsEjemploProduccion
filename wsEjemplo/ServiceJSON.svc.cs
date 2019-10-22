using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using wsEjemplo.DataContracts.BD_ARS;

namespace wsEjemplo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceJSON" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceJSON.svc o ServiceJSON.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceJSON : IServiceJSON
    {
        protected DataClassesElvonDataContext contex_ = new DataClassesElvonDataContext();
        public string ODTReplica(getOdtReplicaRequest odt)
        {
            List<SP_GET_REPLICAS_ONBASEResult> lista = contex_.SP_GET_REPLICAS_ONBASE(odt.FecIni, odt.FecFin).ToList();
            List<RespuestaReplicasContract> replicas = new List<RespuestaReplicasContract>();
            foreach (SP_GET_REPLICAS_ONBASEResult datos in lista)
            {
                RespuestaReplicasContract respuesta = new RespuestaReplicasContract()
                {
                    CONCLUSION = datos.CONCLUSION,
                    ESTATUS = datos.ESTATUS,
                    FECHACONCLUIDO = datos.FECHACONCLUIDO,
                    MOTIVO = datos.MOTIVO,
                    ODT = datos.ODT,
                    FECHAALTA = datos.FECHAALTA
                };
                replicas.Add(respuesta);
            }
            string json;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<RespuestaReplicasContract>));
                ser.WriteObject(ms, replicas);
                json = System.Text.Encoding.UTF8.GetString(ms.GetBuffer(), 0, Convert.ToInt16(ms.Length));
            }
            return json.Replace(@"\","");
        }
    }
}
