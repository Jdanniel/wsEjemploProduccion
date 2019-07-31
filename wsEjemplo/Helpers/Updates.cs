using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsEjemplo.Helpers
{
    public class Updates
    {
        protected DataClassesElvonDataContext contex_ = new DataClassesElvonDataContext();
        public void carga(int idcarga)
        {
            var carga = (from a in contex_.BD_CARGAS where a.ID_CARGA == idcarga select a).FirstOrDefault();
            carga.ID_STATUS_CARGA = 2;
            contex_.SubmitChanges();
        }

        public void arStatus(int idar, int idstatus)
        {
            BD_AR ar = (from a in contex_.BD_AR where a.ID_AR == idar select a).FirstOrDefault();
            ar.ID_STATUS_AR = idstatus;
            contex_.SubmitChanges();
        }

        public void arStatusText(int idar, string estatus){
            var ar = (from a in contex_.BD_AR where a.ID_AR == idar && a.ID_STATUS_AR == 32 select a).FirstOrDefault();
            ar.STATUS = estatus;
            contex_.SubmitChanges();
        }

        public void arNegocio(int idar, string afiliacion)
        {
            var negocio = (from a in contex_.BD_NEGOCIOS where a.NO_AFILIACION == afiliacion select a).FirstOrDefault();
        }
        public int arConfirma(BD_AR ar)
        {
            //contex_.BD_AR.InsertOnSubmit(ar);
            contex_.SubmitChanges();
            return ar.ID_AR;
        }
    }
}