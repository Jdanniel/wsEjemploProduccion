using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using wsEjemplo.DataContracts.BD_ARS;
using wsEjemplo.Helpers;

namespace wsEjemplo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string addServicio(addODTRequest odt);
        
        [OperationContract]
        string confirmarOdt(confirmarODTRequest request);
/*
        [OperationContract]
        List<Respuesta> getODT(string odt);

        [OperationContract]
        List<SP_GET_REPLICAS_ONBASEResult> ODTReplica(getOdtReplicaRequest odt);
/*
        [OperationContract]
        List<BD_AR> getODTafiliacion(string noafiliacion);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
*/
            // TODO: agregue aquí sus operaciones de servicio
    }


        // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
        [DataContract]
        public class CompositeType
        {
            bool boolValue = true;
            string stringValue = "Hello ";

            [DataMember]
            public bool BoolValue
            {
                get { return boolValue; }
                set { boolValue = value; }
            }

            [DataMember]
            public string StringValue
            {
                get { return stringValue; }
                set { stringValue = value; }
            }
        }

}
