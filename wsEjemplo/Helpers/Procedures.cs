﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsEjemplo.Helpers
{
    public class Procedures
    {
        protected DataClassesElvonDataContext contex_ = new DataClassesElvonDataContext();
        public void ingresarServicio(int idcarga)
        {
            contex_.SP_INGRESAR_ARCHIVO1(idcarga, 67);
            contex_.SubmitChanges();
        }

        public void liberarCarga(int idcarga)
        {
            contex_.SP_LIBERAR_CARGA(idcarga, 67);
            contex_.SubmitChanges();
        }
    }
}