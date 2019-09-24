using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public List<SP_GET_REPLICAS_ONBASEResult> ODTReplica(getOdtReplicaRequest odt)
        {
            return contex_.SP_GET_REPLICAS_ONBASE(odt.FecIni, odt.FecFin).ToList();
        }
    }
}
