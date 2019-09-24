using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using wsEjemplo.DataContracts.BD_ARS;

namespace wsEjemplo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceJSON" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceJSON
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  BodyStyle = WebMessageBodyStyle.Bare,
                  UriTemplate = "/Replicas.json")]
        List<SP_GET_REPLICAS_ONBASEResult> ODTReplica(getOdtReplicaRequest odt);
    }
}
