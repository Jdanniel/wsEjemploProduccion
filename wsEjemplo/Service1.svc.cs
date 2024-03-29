﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using wsEjemplo.DataContracts.BD_ARS;
using wsEjemplo.Helpers;

namespace wsEjemplo
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        protected DataClassesElvonDataContext contex_ = new DataClassesElvonDataContext();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string addServicio(addODTRequest odt)
        {
            var mensaje = "";
            var val = "";

            if (odt == null)
            {
                throw new ArgumentNullException("ODT");
            }
            try
            {
                Inserts insert = new Inserts();
                insert.onbaseinbox(odt);
                if (odt.FolioTelecarga == "0" || odt.FolioTelecarga == "")
                {
                    Regex reg = new Regex("[^a-zA-Z0-9 ]");
                    string[] desc = odt.Producto.Split('-');
                    var idsegmento = (from aa in contex_.BD_NEGOCIOS where aa.NO_AFILIACION == odt.Afiliacion && aa.ID_CLIENTE == 4 select aa.ID_SEGMENTO).FirstOrDefault();
                    var idservicio = (from a in contex_.C_SERVICIOS where a.DESC_SERVICIO == reg.Replace(odt.TipoServicio.Normalize(NormalizationForm.FormD), "") && a.ID_CLIENTE == 4 && a.STATUS == "ACTIVO" select a.ID_SERVICIO).FirstOrDefault();
                    var idfalla = (from b in contex_.C_FALLAS where b.DESC_FALLA == reg.Replace(odt.SubtipoServicio.Normalize(NormalizationForm.FormD), "") && b.ID_CLIENTE == 4 && b.STATUS == "ACTIVO" select b.ID_FALLA).FirstOrDefault();
                    var idproveedor = (from c in contex_.C_PROVEEDORES_USUARIOS where c.DESC_PROVEEDOR_USUARIO == odt.Proveedor select c.ID_PROVEEDOR_USUARIO).FirstOrDefault();
                    var idarunico = (from d in contex_.BD_CARGAS join e in contex_.C_CLIENTES on d.ID_CLIENTE equals e.ID_CLIENTE where e.ID_CLIENTE == 4 select new { isarunico = e.IS_AR_UNICO == null ? 0 : e.IS_AR_UNICO }).FirstOrDefault();
                    var idproducto = (from e in contex_.C_PRODUCTOS_NEGOCIOS where e.DESC_PRODUCTO_NEGOCIO == odt.Producto select e.ID_PRODUCTO_NEGOCIO).SingleOrDefault();

                    if (idsegmento == null)
                    {
                        idsegmento = 0;
                    }

                    if (odt.ArOdt == "")
                    {
                        mensaje = "El campo de ODT no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Descripcion == "")
                    {
                        mensaje = "El campo descripcion no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Observacion == "")
                    {
                        mensaje = "El campo observacion no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Comercio == "")
                    {
                        mensaje = "El campo comercio no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Domicilio == "")
                    {
                        mensaje = "El campo domicilio no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Colonia == "")
                    {
                        mensaje = "El campo colonia no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Poblacion == "")
                    {
                        mensaje = "El campo poblacion no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Estado == "")
                    {
                        mensaje = "El campo estado no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Cp == "")
                    {
                        mensaje = "El campo CP no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.RazonSocial == "")
                    {
                        mensaje = "El campo Razon Social no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Rfc == "")
                    {
                        mensaje = "El campo RFC no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Proveedor == "")
                    {
                        mensaje = "El campo proveedor no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.FechaEnvio == "")
                    {
                        mensaje = "El campo Fecha Envio no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    //se descomentan lineas para uso de idamex y afiliacion 
                   /* if(odt.AfilAmex.Length < 10 || odt.AfilAmex.Length > 10)
                    {
                        mensaje = "El campo Afiliacion Amex debe contener 10 numeros con opcion de completar con 7 caracteres de texto";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.IdAmex.Length < 8 || odt.IdAmex.Length > 8)
                    {
                        mensaje = "El campo Afiliacion Amex debe contener 10 numeros con opcion de completar con 7 caracteres de texto";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    */
                    //
                    if (odt.Producto == "")
                    {
                        mensaje = "El campo Producto no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Proyecto == "")
                    {
                        mensaje = "El campo proyecto no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.EjecutivoKA == "")
                    {
                        mensaje = "El campo EjecutivoKA no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.EmailEjecutivoKA == "")
                    {
                        mensaje = "El campo EmailEjecutivoKA no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.EjecutivoSucursal == "")
                    {
                        mensaje = "El campo EjecutivoSucursal no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Sucursal == "")
                    {
                        mensaje = "El campo Sucursal no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.EmailEjecutivo == "")
                    {
                        mensaje = "El campo EmailEjecutivo no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.TelEjecutivo == "")
                    {
                        mensaje = "El campo TelEjecutivo no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.TelSucursal == "")
                    {
                        mensaje = "El campo TelSucursal no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.ContactoComercio == "")
                    {
                        mensaje = "El campo ContactoComercio no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Contacto1 == "")
                    {
                        mensaje = "El campo Contacto1 no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (odt.Contacto2 == "")
                    {
                        mensaje = "El campo Contacto2 no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    /*Se agrega campo 27/02/2020*/
                    if (odt.TipoServicio.Normalize(NormalizationForm.FormD) == "BOARDING DIGITAL" && (odt.SubtipoServicio.Normalize(NormalizationForm.FormD) == "CONTRATO DE RECUPERACION DE FIRMA"))
                    {
                        if (odt.Canal == "")
                        {
                            mensaje = "El campo Canal no puede estar vacio";
                            insert.logws(odt.ArOdt, "ERROR", mensaje);
                            return mensaje;
                        }
                        //Se agrega nueva validacion 03/03/2020
                        C_CANALES canal = contex_.C_CANALES.Where(x => x.DESC_CANAL == odt.Canal.TrimEnd()).FirstOrDefault();
                        if(canal == null)
                        {
                            mensaje = "El campo Canal no es valido";
                            insert.logws(odt.ArOdt, "ERROR", mensaje);
                            return mensaje;
                        }
                        //Fin
                    }

                    if (odt.TipoServicio.Normalize(NormalizationForm.FormD) == "INSTALACION DE BOARDING DIGITAL" && (odt.SubtipoServicio.Normalize(NormalizationForm.FormD) == "INSTALACION BD"))
                    {
                        if (odt.Canal == "")
                        {
                            mensaje = "El campo Canal no puede estar vacio";
                            insert.logws(odt.ArOdt, "ERROR", mensaje);
                            return mensaje;
                        }
                        //Se agrega nueva validacion 03/03/2020
                        C_CANALES canal = contex_.C_CANALES.Where(x => x.DESC_CANAL == odt.Canal.TrimEnd()).FirstOrDefault();
                        if (canal == null)
                        {
                            mensaje = "El campo Canal no es valido";
                            insert.logws(odt.ArOdt, "ERROR", mensaje);
                            return mensaje;
                        }
                        //Fin
                    }

                    /*Fin*/
                    /*                if (odt.ModeloTPV == "")
                                    {
                                        mensaje = "El campo ModeloTPV no puede estar vacio";
                                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                                        return mensaje;
                                    }
                                    */
                    if (odt.Carga == "")
                    {
                        mensaje = "El campo Carga no puede estar vacio";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (idservicio == 0)
                    {
                        mensaje = "El servicio ingresado no existe";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (idfalla == 0)
                    {
                        mensaje = "El subtipo de servicio ingresado no existe";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (idproveedor == 0)
                    {
                        mensaje = "El proveedor ingresado no existe";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }
                    if (idproducto == 0)
                    {
                        mensaje = "El producto ingresado no existe";
                        insert.logws(odt.ArOdt, "ERROR", mensaje);
                        return mensaje;
                    }

                    if (idarunico.isarunico == 1)
                    {
                        var totalar = (from f in contex_.BD_AR where f.NO_AR == odt.ArOdt select f.ID_AR).Count();
                        if (totalar >= 1)
                        {
                            mensaje = "ODT Repetido";
                            insert.logws(odt.ArOdt, "ERROR", mensaje);
                            return mensaje;
                        }
                        else
                        {
                            Updates updates = new Updates();
                            Procedures procedures = new Procedures();


                            var idcarga = insert.carga(odt);
                            int idar = insert.ar(odt, idcarga, idservicio, idfalla, idproveedor, idsegmento, idproducto);
                            updates.carga(idcarga);
                            procedures.ingresarServicio(idcarga);
                            updates.arStatus(idar, 32);
                            updates.arStatusText(idar, "Interfaz");
                            insert.bitacoraAr(idar, 1, 32, "Solicitud de servicio esperando confirmacion.");

                            mensaje = "PREODT ASIGNADA " + odt.ArOdt;
                            val = "EXITO";
                        }
                    }
                }
                else
                {
                    mensaje = "El campo FolioTelecarga no puede contener datos.";
                    insert.logws(odt.ArOdt, "ERROR", mensaje);
                    return mensaje;
                }

            }
            catch (Exception ex)
            {
                mensaje = ex.StackTrace +" "+ ex.Message;
                val = "ERROR";
            }
            Inserts inserts = new Inserts();
            inserts.logws(odt.ArOdt, val, mensaje);
            return mensaje;
        }

        public string confirmarOdt(confirmarODTRequest request)
        {
            var mensaje = "";
            var val = "";
            var estado = "";

            if (request == null)
            {
                throw new ArgumentNullException("Request");
            }
            try
            {
                Updates update = new Updates();
                Inserts insert = new Inserts();
                Procedures procedures = new Procedures();

                insert.onbaseinboxconfirmacion(request);

                var idproveedor = (from a in contex_.C_PROVEEDORES_USUARIOS where a.DESC_PROVEEDOR_USUARIO == request.Proveedor select a.ID_PROVEEDOR_USUARIO).FirstOrDefault();
                var descProveedor = (from a in contex_.C_PROVEEDORES_USUARIOS where a.ID_PROVEEDOR_USUARIO == idproveedor select a.DESC_PROVEEDOR_USUARIO).FirstOrDefault();
                var sepomex = (from f in contex_.SEPOMEX join g in contex_.SEPOMEX_ESTADOS on f.d_estado equals g.ID_ESTADO where f.d_CP == request.Cp.TrimEnd() select g.ESTADO).FirstOrDefault();
                var idconectividad = (from b in contex_.C_CONECTIVIDAD where b.DESC_CONECTIVIDAD.Trim().Equals(request.Conectividad.Trim()) && b.ID_CLIENTE == 4 && b.STATUS == "ACTIVO" select b.ID_CONECTIVIDAD).FirstOrDefault();
                var existCP = (from a in contex_.BD_TIPO_PLAZA_CLIENTE_CP where a.CP == request.Cp select a).FirstOrDefault();
                string[] tipoabArray = { "A", "b", "a", "B" };
                int? idtipoEquipo = null;
                //DateTime FECHA_INICIO = new DateTime();
                if (tipoabArray.Any(request.TipoAB.Contains))
                {
                    idtipoEquipo = (from c in contex_.C_TIPO_A_B where c.DESC_TIPO_A_B == request.TipoAB.ToUpper() || c.DESC_TIPO_A_B == request.TipoAB.ToLower() select c.ID_TIPO_A_B).FirstOrDefault();
                }


                if (sepomex == null || sepomex == "")
                {
                    mensaje = "El codigo postal no existe en la base de sepomex";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }

                if (existCP == null)
                {
                    mensaje = "NO SE ENCUENTRA ZONA POR CODIGO POSTAL";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }

                if (sepomex.ToUpper() != RemoveAccentsWithNormalization(request.Estado.ToString().ToUpper()))
                {
                    
                    var existeEstado = (from A in contex_.BD_EQUIVALENCIA_ESTADO where A.DESC_ESTADO == RemoveAccentsWithNormalization(request.Estado.ToUpper()) select A.DESC_ESTADO_EQUIVALENCIA).FirstOrDefault();
                    if(sepomex != existeEstado)
                    {
                    
                        mensaje = "ERROR EN DATOS DEMOGRAFICOS";
                        insert.logws(request.PreOdt, "ERROR", mensaje);
                        return mensaje;
                    
                    }
                    estado = existeEstado;
                    /*
                    request.Estado = existeEstado;*/
                }
                else
                {
                    estado = null;
                }

                var status = new int?[] { 3, 6, 7, 8 };

                var arstatus = (from a in contex_.BD_AR where a.NO_AR == request.PreOdt && status.Contains(a.ID_STATUS_AR) select a).FirstOrDefault();

                var ar = (from a in contex_.BD_AR where a.NO_AR == request.PreOdt && a.ID_STATUS_AR == 32 select a).FirstOrDefault();

                if(ar == null && arstatus != null)
                {
                    mensaje = "La Odt ya existe en el sistema";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }

                if (ar == null)
                {
                    mensaje = "La PreOdt no existe en el sistema";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Afiliacion == "" || request.Afiliacion == "0")
                {
                    mensaje = "El campo afiliacion no debe venir vacio o en cero";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Colonia == "")
                {
                    mensaje = "El campo de Colinia no puede venir vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Poblacion == "")
                {
                    mensaje = "El campo de poblacion no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Estado == "")
                {
                    mensaje = "El campo de Estado no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Cp.Length > 5 || request.Cp.Length < 4)
                {
                    mensaje = "El campo CP debe tener minimo 4 digitos maximo 5";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Proveedor == "")
                {
                    mensaje = "El campo de proveedor no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                /*
                if (request.Producto == "")
                {
                    mensaje = "El campo de producto no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }*/
                if (request.EjecutivoKA == "")
                {
                    mensaje = "El campo de EjecutivoKA no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.EmailEjecutivoKA == "")
                {
                    mensaje = "El campo de EmailEjecutivoKA no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.EjecutivoSucursal == "")
                {
                    mensaje = "El campo de EjecutivoSucursal no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Sucursal == "")
                {
                    mensaje = "El campo de Sucursal no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.TelEjecutivo == "")
                {
                    mensaje = "El campo de TelEjecutivo no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.TelSucursal == "")
                {
                    mensaje = "El campo de TelSucursal no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.ContactoComercio == "")
                {
                    mensaje = "El campo de ContactoComercio no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Descripcion == "")
                {
                    mensaje = "El campo de Descripcion no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Telefono == "")
                {
                    mensaje = "El campo de Telefono no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.Proyecto == "")
                {
                    mensaje = "El campo de Proyecto no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (idproveedor == 0)
                {
                    return mensaje = "El proveedor ingresado no existe";
                }

                //nuevas validaciones para campos nuevos de afiliacionAmex y idAmex

                if (request.AfilAmex.Length > 17 )
                {
                    mensaje = "El campo Afiliacion Amex debe contener 17 numeros con opcion de completar con 7 caracteres de texto";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (request.IdAmex.Length > 17 )
                {
                    mensaje = "El campo Id Amex debe contener 17 numeros con opcion de completar con 7 caracteres de texto";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }

                //


                ar.NO_AR = request.PreOdt;
                ar.NO_AFILIACION = request.Afiliacion;
                ar.COLONIA = request.Colonia;
                //ar.SINTOMA = request.Descripcion;
                ar.BITACORA = request.Descripcion;
                ar.TELEFONO = request.Telefono;
                ar.COLONIA = request.Colonia;
                ar.POBLACION = request.Poblacion;
                if (estado != null)
                {
                    ar.ESTADO = estado;
                }
                else
                {
                    ar.ESTADO = request.Estado;
                }
                ar.CP = request.Cp.Trim();
                ar.CAJA = request.IdCaja;
                ar.ID_PROVEEDOR = idproveedor;
                ar.ID_TECNICO = null;
                ar.CODIGO_INTERVENCION = request.TelSucursal;
                ar.OTORGANTE_TAS = request.Contacto1;
                ar.TELEFONO_COMERCIO = request.Contacto2;
                ar.MOTIVO_RETIPIFICADO = request.EmailServ;
                ar.MOTIVO_COBRO = request.ReferenciaUbicacion;
                ar.DESC_EQUIPO = request.ModeloTPV;
                ar.FEC_INICIO = DateTime.Now;
                ar.FEC_ALTA = DateTime.Now;
                if(idtipoEquipo != null)
                {
                    ar.ID_TIPO_EQUIPO = idtipoEquipo;
                }
                if (idconectividad != 0)
                {
                    ar.ID_CONECTIVIDAD = idconectividad;
                }
                if (request.Proyecto.ToUpper().Equals("SI") || request.Proyecto.ToUpper().Equals("SÍ"))
                {
                    ar.ID_PROYECTO = 1;
                }
                else
                {
                    ar.ID_PROYECTO = 0;
                }
                if (request.Producto != "")
                {
                    var idproducto = (from e in contex_.C_PRODUCTOS_NEGOCIOS where e.DESC_PRODUCTO_NEGOCIO == request.Producto select e.ID_PRODUCTO_NEGOCIO).SingleOrDefault();
                    ar.ID_PRODUCTO = idproducto;
                }
                if (request.FolioTelecarga != "")
                {
                    ar.FOLIO_TELECARGA = request.FolioTelecarga;
                    ar.EQUIPO = request.FolioTelecarga;
                }
                //ingresar variables nuevas 
                var AfilAmexV = request.AfilAmex;
                var IdAmex = request.IdAmex;
                //
                ar.OTORGANTE_SOPORTE_CLIENTE = request.EjecutivoSucursal;
                ar.SINTOMA = request.Sintoma;
                ar.STATUS = "PROCESADO";
                contex_.SubmitChanges();
                var idar = ar.ID_AR;
                insert.terminalAmex(idar, IdAmex, AfilAmexV);
                procedures.actualizarOdt(idar);
                update.arStatus(idar, 3);
                insert.bitacoraAr(idar, 32, 3, "Solicitud de servicio Asignada");

                mensaje = "ODT REGISTRADA:"+ar.NO_AR;
                val = "EXITO CONFIRMACION";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                val = "ERROR CONFIRMACION";
            }
            Inserts inserts = new Inserts();
            inserts.logws(request.PreOdt, val, mensaje);
            return mensaje;
        }
        /*
        public List<BD_AR> getODTafiliacion(string noafiliacion)
        {
            return (from a
                        in contex_.BD_AR
                    where a.NO_AFILIACION == noafiliacion && a.ID_STATUS_AR == 31
                    select a).ToList();
        }
        */

        public List<SP_GET_REPLICAS_ONBASEResult> ODTReplica(getOdtReplicaRequest odt)
        {
            return contex_.SP_GET_REPLICAS_ONBASE(odt.FecIni, odt.FecFin).ToList(); 
        }

        public List<SP_GET_ODT_ONBASEResult> getODT(string odt)
        {
            return contex_.SP_GET_ODT_ONBASE(odt).ToList();
        }

        /*public List<Respuesta> getODT(string odt)
        {
            var idstatusar = new int?[] {6, 7, 8};
            var status = new int?[] {3, 31}; 
            var comentarios = new string[] { "Se crea código de rechazo" };

            var ars = (from a
                            in contex_.BD_AR
                       join b in contex_.C_STATUS_AR
                       on a.ID_STATUS_AR
                       equals b.ID_STATUS_AR
                       where a.NO_AR == odt
                       && a.STATUS == "PROCESADO"
                       select new Respuesta
                       {
                           estatus = b.DESC_STATUS_AR,
                           conclusion = a.DESCRIPCION_TRABAJO,
                           fechaConcluido = "",
                           fechaAlta = Convert.ToDateTime(a.FEC_ALTA).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                           odt = a.NO_AR,
                           motivo = a.ID_STATUS_AR == 7 ? (from cc in contex_.C_CAUSAS_RECHAZO 
                                                           where a.ID_CAUSA_RECHAZO == cc.ID_TRECHAZO 
                                                           && cc.ID_CLIENTE == 4 
                                                           && cc.STATUS == "ACTIVO"
                                                           select cc.DESC_CAUSA_RECHAZO.TrimEnd()).FirstOrDefault() 
                                                        : (a.ID_STATUS_AR == 8 ? (from cc in contex_.BD_AR_CAUSAS_CANCELACION
                                                                                  join bb in contex_.C_CAUSA_CANCELACION
                                                                                  on cc.ID_CAUSA_CANCELACION equals bb.ID_CAUSA_CANCELACION
                                                                                  where cc.ID_AR == a.ID_AR
                                                                                  select bb.DESC_CAUSA_CANCELACION.TrimEnd()).FirstOrDefault() : "")
                       }).ToList();


            return ars;
        }*/

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        public static string RemoveAccentsWithNormalization(string inputString)
        {
            string normalizedString = inputString.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

    }
}
