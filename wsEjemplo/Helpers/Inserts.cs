using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wsEjemplo.DataContracts.BD_ARS;

namespace wsEjemplo.Helpers
{
    public class Inserts
    {
        protected DataClassesElvonDataContext contex_ = new DataClassesElvonDataContext();

        public int carga(addODTRequest odt)
        {
            DateTime dateTimeServer = contex_.ExecuteQuery<DateTime>("SELECT GETDATE() Fecha").SingleOrDefault();
            string dateTime2String = dateTimeServer.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            BD_CARGAS carga = new BD_CARGAS();
            carga.ID_CLIENTE = 4;
            carga.FECHA = dateTimeServer;
            carga.ID_ATTACH_ARCHIVO1 = null;
            carga.ID_STATUS_CARGA = 1;
            carga.ID_USUARIO_ALTA = 67;
            carga.STATUS = "ACTIVO";
            carga.FEC_ALTA = dateTimeServer;
            contex_.BD_CARGAS.InsertOnSubmit(carga);
            contex_.SubmitChanges();
            return carga.ID_CARGA;
        }

        public int ar(addODTRequest odt, int idcarga, int idservicio, int idfalla, int idproveedor, int? idsegmento, int idproducto)
        {
            var descProveedor = (from a in contex_.C_PROVEEDORES_USUARIOS where a.ID_PROVEEDOR_USUARIO == idproveedor select a.DESC_PROVEEDOR_USUARIO).FirstOrDefault();
            var idconectividad = (from b in contex_.C_CONECTIVIDAD where b.DESC_CONECTIVIDAD == odt.Conectividad select b.ID_CONECTIVIDAD).FirstOrDefault();
            BD_AR newODT = new BD_AR();
            //newODT.FEC_INICIO = DateTime.Now;
            //newODT.ID_PROYECTO = odt.Proyecto;
            newODT.BITACORA = odt.Descripcion;
            newODT.CAJA = odt.IdCaja;
            newODT.CODIGO_INTERVENCION = odt.Sucursal;
            newODT.COLONIA = odt.Colonia;
            newODT.ID_CONECTIVIDAD = idconectividad;
            newODT.CORREO_EJECUTIVO = odt.EmailEjecutivo;
            newODT.CP = odt.Cp;
            newODT.DESC_EQUIPO = odt.ModeloTPV;
            newODT.DESC_NEGOCIO = odt.Comercio;
            newODT.DIRECCION = odt.Domicilio;
            newODT.MOTIVO_COBRO = odt.ReferenciaUbicacion;
            newODT.ESTADO = odt.Estado;
            newODT.FALLA_ENCONTRADA = odt.Rfc;
            newODT.FEC_ALTA = DateTime.Now;
            newODT.FEC_CONVENIO = DateTime.Now;
            newODT.FEC_INICIO = Convert.ToDateTime(odt.FechaEnvio);
            newODT.FOLIO_TELECARGA = odt.FolioTelecarga == "" ? 0 : Convert.ToInt32(odt.FolioTelecarga);
            newODT.EQUIPO = odt.FolioTelecarga;
            newODT.ID_CARGA = idcarga;
            newODT.ID_CLIENTE = 4;
            newODT.ID_FALLA = idfalla;
            newODT.ID_PRODUCTO = idproducto;
            newODT.ID_PROVEEDOR = idproveedor;
            newODT.ID_SEGMENTO = 476;
            newODT.ID_SERVICIO = idservicio;
            newODT.ID_STATUS_AR = 1;
            newODT.ID_TECNICO = 67;
            newODT.ID_TIPO_EQUIPO = 2;
            newODT.INSUMOS = Convert.ToInt32(odt.NumRollos);
            newODT.IS_ACTUALIZACION = 0;
            newODT.IS_FOLLOW_DISPATCH = 0;
            newODT.IS_INGRESO_MANUAL = 0;
            newODT.IS_INSTALACION = 0;
            newODT.IS_PROGRAMADO = 0;
            newODT.IS_RETIRO = 0;
            newODT.IS_SUSTITUCION = 0;
            newODT.MOTIVO_RETIPIFICADO = odt.EmailServ;
            newODT.NO_AFILIACION = odt.Afiliacion;
            newODT.NO_AR = odt.ArOdt;
            newODT.NO_DIAS_LIBERACION = 0;
            newODT.NOTAS_REMEDY = odt.RazonSocial;
            newODT.OTORGANTE_SOPORTE_CLIENTE = odt.EjecutivoSucursal;
            newODT.OTORGANTE_VOBO_TERCEROS = odt.EmailServ;
            newODT.POBLACION = odt.Poblacion;
            newODT.SEGMENTO = 476;
            newODT.SINTOMA = odt.Observacion;
            newODT.STATUS = "PENDIENTE";
            newODT.TELEFONO = odt.Telefono;
            newODT.OTORGANTE_TAS = odt.Contacto1;
            newODT.TELEFONO_COMERCIO = odt.Contacto2;
            newODT.TIPO_FALLA = idfalla;
            newODT.TIPO_SERVICIO = idservicio;
            if(odt.Proyecto.ToUpper().Equals("SI") || odt.Proyecto.ToUpper().Equals("SÍ"))
            {
                newODT.ID_PROYECTO = 1;
            }
            else
            {
                newODT.ID_PROYECTO = 0;
            }
            /*
            if (!odt.AfilAmex.Equals("") && !odt.IdAmex.Equals(""))
            {
                newODT.TERMINAL_AMEX = 1;
            }*/

            contex_.BD_AR.InsertOnSubmit(newODT);
            contex_.SubmitChanges();

            return newODT.ID_AR;
        }

        public void terminalAmex(int idar, string idterminal, string afiliacionamex)
        {
            BD_AR_TERMINAL_ASOCIADA_AMEX terminal = new BD_AR_TERMINAL_ASOCIADA_AMEX();
            terminal.ID_AR = idar;
            terminal.ID_TERMINAL_AMEX = idterminal;
            terminal.AFILIACION_TERMINAL_AMEX = afiliacionamex;
            terminal.ID_USUARIO_ALTA = 67;
            terminal.FEC_ALTA = DateTime.Now;
            contex_.BD_AR_TERMINAL_ASOCIADA_AMEX.InsertOnSubmit(terminal);
            contex_.SubmitChanges();
        }

        public void onbaseinboxconfirmacion(confirmarODTRequest odt)
        {
                BD_ONBASE_INBOX_CONFIRMACION confirma = new BD_ONBASE_INBOX_CONFIRMACION();
                confirma.AFILIACION = odt.Afiliacion;
                confirma.CANAL = odt.Canal;
                confirma.COLONIA = odt.Colonia;
                confirma.CONECTIVIDAD = odt.Conectividad;
                confirma.CONTACTO1 = odt.Contacto1;
                confirma.CONTACTO2 = odt.Contacto2;
                confirma.CONTACTOCOMERCIO = odt.ContactoComercio;
                confirma.CP = odt.Cp;
                confirma.DESCRIPCION = odt.Descripcion;
                confirma.DIASATENCION = odt.DiasAtencion;
                confirma.EJECUTIVOKA = odt.EjecutivoKA;
                confirma.EJECUTIVOSUCURSAL = odt.EjecutivoSucursal;
                confirma.EMAILEJECUTIVOKA = odt.EmailEjecutivoKA;
                confirma.EMAILSERV = odt.EmailServ;
                confirma.ESTADO = odt.Estado;
                confirma.FOLIOTELECARGA = odt.FolioTelecarga;
                confirma.HORARIOATENCION = odt.HorarioAtencion;
                confirma.IDCAJA = odt.IdCaja;
                confirma.MCC = odt.Mcc;
                confirma.MODELOTPV = odt.ModeloTPV;
                confirma.POBLACION = odt.Poblacion;
                confirma.PREODT = odt.PreOdt;
                confirma.PRODUCTO = odt.Producto;
                confirma.PROVEEDOR = odt.Proveedor;
                confirma.PROYECTO = odt.Proyecto;
                confirma.REFERENCIAUBICACION = odt.ReferenciaUbicacion;
                confirma.SUCURSAL = odt.Sucursal;
                confirma.SINTOMA = odt.Sintoma;
                confirma.TELEFONO = odt.Telefono;
                confirma.TELEJECUTIVO = odt.TelEjecutivo;
                confirma.TELSUCURSAL = odt.TelSucursal;
                contex_.BD_ONBASE_INBOX_CONFIRMACION.InsertOnSubmit(confirma);
                contex_.SubmitChanges();

        }
        public void onbaseinbox(addODTRequest odt)
        {
            BD_ONBASE_INBOX inbox = new BD_ONBASE_INBOX();
            inbox.AFILAMEX = odt.AfilAmex;
            inbox.AFILIACION = odt.Afiliacion;
            inbox.ARODT = odt.ArOdt;
            inbox.CANAL = odt.Canal;
            inbox.CARGA = odt.Carga;
            inbox.CODIGOPRODUCTO = odt.CodigoProducto;
            inbox.COLONIA = odt.Colonia;
            inbox.COMERCIO = odt.Comercio;
            inbox.CONECTIVIDAD = odt.Conectividad;
            inbox.CONTACTO1 = odt.Contacto1;
            inbox.CONTACTO2 = odt.Contacto2;
            inbox.CONTACTOCOMERCIO = odt.ContactoComercio;
            inbox.CP = odt.Cp;
            inbox.DESCRIPCION = odt.Descripcion;
            inbox.DIASATENCION = odt.DiasAtencion;
            inbox.DOMICILIO = odt.Domicilio;
            inbox.EJECUTIVOKA = odt.EjecutivoKA;
            inbox.EJECUTIVOSUCURSAL = odt.EjecutivoSucursal;
            inbox.EMAILEJECUTIVO = odt.EmailEjecutivo;
            inbox.EMAILEJECUTIVOKA = odt.EmailEjecutivoKA;
            inbox.EMAILRESPUESTA = odt.EmailRespuesta;
            inbox.EMAILSERV = odt.EmailServ;
            inbox.ESTADO = odt.Estado;
            inbox.FECHAENVIO = odt.FechaEnvio;
            inbox.FOLIOTELECARGA = odt.FolioTelecarga;
            inbox.HORARIOATENCION = odt.HorarioAtencion;
            inbox.IDAMEX = odt.IdAmex;
            inbox.IDCAJA = odt.IdCaja;
            inbox.MCC = odt.Mcc;
            inbox.MODELOTPV = odt.ModeloTPV;
            inbox.NUMROLLOS = odt.NumRollos;
            inbox.OBSERVACION = odt.Observacion;
            inbox.POBLACION = odt.Poblacion;
            inbox.PREODT = odt.PreOdt;
            inbox.PRODUCTO = odt.Producto;
            inbox.PROVEEDOR = odt.Proveedor;
            inbox.PROYECTO = odt.Proyecto;
            inbox.RAZONSOCIAL = odt.RazonSocial;
            inbox.REFERENCIAUBICACION = odt.ReferenciaUbicacion;
            inbox.RFC = odt.Rfc;
            inbox.SUBTIPOSERVICIO = odt.SubtipoServicio;
            inbox.SUCURSAL = odt.Sucursal;
            inbox.TELEFONO = odt.Telefono;
            inbox.TELEJECUTIVO = odt.TelEjecutivo;
            inbox.TELSUCURSAL = odt.TelSucursal;
            inbox.TIPOSERVICIO = odt.TipoServicio;
            contex_.BD_ONBASE_INBOX.InsertOnSubmit(inbox);
            contex_.SubmitChanges();
        }

        public void bitacoraAr(int idar, int idstatusini, int idstatusfin, string comentario)
        {
            BD_BITACORA_AR bitacora = new BD_BITACORA_AR();
            bitacora.ID_AR = idar;
            bitacora.ID_STATUS_AR_INI = idstatusini;
            bitacora.ID_STATUS_AR_FIN = idstatusfin;
            bitacora.COMENTARIO = comentario;
            bitacora.ID_USUARIO_ALTA = 67;
            bitacora.FEC_ALTA = DateTime.Now;
            contex_.BD_BITACORA_AR.InsertOnSubmit(bitacora);
            contex_.SubmitChanges();
        }

        public void logws(string noar, string status, string error)
        {
            BD_AR_LOG_WS ws = new BD_AR_LOG_WS();
            ws.NO_AR = noar;
            ws.ESTATUS = status;
            ws.ERROR = error;
            ws.FEC_ALTA = DateTime.Now;
            contex_.BD_AR_LOG_WS.InsertOnSubmit(ws);
            contex_.SubmitChanges();
        }
    }
}