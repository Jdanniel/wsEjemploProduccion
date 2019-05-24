using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
                Regex reg = new Regex("[^a-zA-Z0-9 ]");
                string[] desc = odt.Producto.Split('-');
                var idsegmento = (from aa in contex_.BD_NEGOCIOS where aa.NO_AFILIACION == odt.Afiliacion && aa.ID_CLIENTE == 4 select aa.ID_SEGMENTO).FirstOrDefault();
                var idservicio = (from a in contex_.C_SERVICIOS where a.DESC_SERVICIO == reg.Replace(odt.TipoServicio.Normalize(NormalizationForm.FormD), "") && a.ID_CLIENTE == 4 select a.ID_SERVICIO).FirstOrDefault();
                var idfalla = (from b in contex_.C_FALLAS where b.DESC_FALLA == reg.Replace(odt.SubtipoServicio.Normalize(NormalizationForm.FormD), "") && b.ID_CLIENTE == 4 select b.ID_FALLA).FirstOrDefault();
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
                /*
                if(odt.AfilAmex.Length < 10 || odt.AfilAmex.Length > 10)
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
                }*/
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
                if (odt.Canal == "")
                {
                    mensaje = "El campo canal no puede estar vacio";
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
                        var idar = insert.ar(odt, idcarga, idservicio, idfalla, idproveedor, idsegmento, idproducto);
                        /*
                        if (!odt.AfilAmex.Equals("") && !odt.IdAmex.Equals(""))
                        {
                            insert.terminalAmex(idar, odt.IdAmex, odt.AfilAmex);
                        }*/

                        updates.carga(idcarga);
                        procedures.ingresarServicio(idcarga);
                        procedures.liberarCarga(idcarga);
                        updates.arStatus(idar, 32);
                        updates.arStatusText(idar,"Interfaz");
                        insert.bitacoraAr(idar, 2, 32, "Solicitud de servicio esperando confirmacion.");

                        mensaje = "PREODT ASIGNADA " + odt.ArOdt;
                        val = "EXITO";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
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

            if (request == null)
            {
                throw new ArgumentNullException("Request");
            }
            try
            {
                Updates update = new Updates();
                Inserts insert = new Inserts();

                insert.onbaseinboxconfirmacion(request);

                var idproveedor = (from a in contex_.C_PROVEEDORES_USUARIOS where a.DESC_PROVEEDOR_USUARIO == request.Proveedor select a.ID_PROVEEDOR_USUARIO).FirstOrDefault();
                var descProveedor = (from a in contex_.C_PROVEEDORES_USUARIOS where a.ID_PROVEEDOR_USUARIO == idproveedor select a.DESC_PROVEEDOR_USUARIO).FirstOrDefault();
                var sepomex = (from f in contex_.SEPOMEX join g in contex_.SEPOMEX_ESTADOS on f.d_estado equals g.ID_ESTADO where f.d_CP == request.Cp.TrimEnd() select g.ESTADO).FirstOrDefault();

                if (sepomex == null)
                {
                    mensaje = "El codigo postal no existe en la base de sepomex";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
                if (sepomex != request.Estado)
                {
                    mensaje = "El CP no coincide con el estado";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }

                var ar = (from a in contex_.BD_AR where a.NO_AR == request.PreOdt && a.ID_STATUS_AR == 32 select a).FirstOrDefault();

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
                if (request.Canal == "")
                {
                    mensaje = "El campo de canal no puede estar vacio";
                    insert.logws(request.PreOdt, "ERROR", mensaje);
                    return mensaje;
                }
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

                ar.NO_AR = request.PreOdt;
                ar.NO_AFILIACION = request.Afiliacion;
                ar.COLONIA = request.Colonia;
                //ar.SINTOMA = request.Descripcion;
                ar.BITACORA = request.Descripcion;
                ar.TELEFONO = request.Telefono;
                ar.COLONIA = request.Colonia;
                ar.POBLACION = request.Poblacion;
                ar.ESTADO = request.Estado;
                ar.CP = request.Cp;
                ar.CAJA = request.IdCaja;
                ar.ID_PROVEEDOR = idproveedor;
                ar.CODIGO_INTERVENCION = request.TelSucursal;
                ar.TELEFONO_COMERCIO = request.Contacto2;
                ar.MOTIVO_RETIPIFICADO = request.EmailServ;
                ar.DIRECCION_ALTERNA_COMERCIO = request.ReferenciaUbicacion;
                ar.DESC_EQUIPO = request.ModeloTPV;
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
                    ar.FOLIO_TELECARGA = Convert.ToInt32(request.FolioTelecarga);
                }
                ar.OTORGANTE_SOPORTE_CLIENTE = request.EjecutivoSucursal;
                ar.SINTOMA = request.Sintoma;
                ar.STATUS = "PROCESADO";
                contex_.SubmitChanges();
                var idar = ar.ID_AR;
                update.arStatus(idar, 3);
                insert.bitacoraAr(idar, 31, 3, "Solicitud de servicio Asignada");

                mensaje = "ODT REGISTRADA:"+ar.NO_AR;
                val = "EXITO CONFIRMACION";
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
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
        public List<Respuesta> getODT(string odt)
        {
            var ars = (from a
                            in contex_.BD_AR
                       join b in contex_.C_STATUS_AR
                       on a.ID_STATUS_AR
                       equals b.ID_STATUS_AR
                       where a.NO_AR == odt
                       select new Respuesta
                       {
                           estatus = b.DESC_STATUS_AR,
                           conclusion = a.DESCRIPCION_TRABAJO,
                           fechaConcluido = Convert.ToString(a.FEC_CIERRE),
                           odt = a.NO_AR,
                           motivo = ""
                       }).ToList();
            return ars;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

    }
}
