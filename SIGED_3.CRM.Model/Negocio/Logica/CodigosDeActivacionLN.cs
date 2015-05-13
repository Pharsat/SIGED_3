using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Util.Session;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Comunicacion;
using SIGED_3.CRM.Model.Servicios.Fachadas;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class CodigosDeActivacionLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla CodigosDeActivacion
        /// </summary>
        /// <returns>Lista de registros tipo CodigosDeActivacion</returns>
        public List<CodigosDeActivacion> Seleccionar_All()
        {
            CodigosDeActivacionOAD objCodigosDeActivacion = new CodigosDeActivacionOAD();
            return objCodigosDeActivacion.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla CodigosDeActivacion
        /// </summary>
        /// <param name=Id>Identificador de la CodigosDeActivacion</param>
        /// <returns>Objeto singular del tipo CodigosDeActivacion</returns>
        public List<CodigosDeActivacion> Seleccionar_Id(long Id)
        {
            CodigosDeActivacionOAD objCodigosDeActivacion = new CodigosDeActivacionOAD();
            return objCodigosDeActivacion.Seleccionar_Id(Id);
        }

        public CodigosDeActivacion Seleccionar_Id_Unico(long Id)
        {
            CodigosDeActivacionOAD objCodigosDeActivacion = new CodigosDeActivacionOAD();
            return objCodigosDeActivacion.Seleccionar_Id_Unico(Id);
        }

        /// <summary>
        /// Guarda un objeto de tipo CodigosDeActivacion en la base de datos.
        /// </summary>
        /// <param name=objCodigosDeActivacion>Objeto CodigosDeActivacion a guardar</param>
        public void Guardar(CodigosDeActivacion objCodigosDeActivacion)
        {
            CodigosDeActivacionOAD _objCodigosDeActivacion = new CodigosDeActivacionOAD();
            _objCodigosDeActivacion.Guardar(objCodigosDeActivacion);
        }
        /// <summary>
        /// Elimina un objeto del tipo CodigosDeActivacion, se recibe su Id unicamente
        /// </summary>
        /// <param name=objCodigosDeActivacion>Identificativo del(a) CodigosDeActivacion</param>
        public void Eliminar(CodigosDeActivacion objCodigosDeActivacion)
        {
            CodigosDeActivacionOAD _objCodigosDeActivacion = new CodigosDeActivacionOAD();
            _objCodigosDeActivacion.Eliminar(objCodigosDeActivacion);
        }
        /// <summary>
        /// Actualiza una CodigosDeActivacion, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objCodigosDeActivacion>Objeto del tipo CodigosDeActivacion</param>
        public void Actualizar(CodigosDeActivacion objCodigosDeActivacion)
        {
            CodigosDeActivacionOAD _objCodigosDeActivacion = new CodigosDeActivacionOAD();
            _objCodigosDeActivacion.Actualizar(objCodigosDeActivacion);
        }
        /// <summary>
        /// verifica un codigo de activacion en el sistema y consume un uso en caso solicitado
        /// </summary>
        /// <param name="Codigo">codigo a validar</param>
        /// <param name="ConsumirCodigo">indica si se consume un uso de este codigo o no</param>
        /// <returns>verificacion</returns>
        public bool Verificar(string Codigo, bool ConsumirCodigo)
        {
            CodigosDeActivacionOAD _objCodigosDeActivacion = new CodigosDeActivacionOAD();
            return _objCodigosDeActivacion.Verificar(Codigo, ConsumirCodigo);
        }
        /// <summary>
        /// Genera el codigo con el cual se hacen las llaves para la aplicación.
        /// </summary>
        /// <param name="NumUsos">Cantidad de usos maximo permitido para esta llave</param>
        /// <returns>llave</returns>
        public string GenerarCodigo(short NumUsos, long? Id_Cuenta)
        {
            CodigosDeActivacionOAD _objCodigosDeActivacion = new CodigosDeActivacionOAD();
            return _objCodigosDeActivacion.GenerarCodigo(NumUsos, Id_Cuenta);
        }

        public string GenerarCodigoCuenta(long? Id_Miembro)
        {
            try
            {
                string Codigo = String.Empty;
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Miembro objMiembro = new MiembroLN().Seleccionar_Id(Id_Miembro.Value);
                    GrupoDeMiembros objGrupo = new GrupoDeMiembrosLN().Seleccionar_Id(objMiembro.Id_GrupoDeMiembros.Value);

                    CorreoElectronico objCorreoElectronico = new CorreoElectronico(global::SIGED_3.CRM.Model.Properties.Settings.Default.EmisorDeLosCorreos, global::SIGED_3.CRM.Model.Properties.Settings.Default.NombreCompania);
                    objCorreoElectronico.p_strAsunto = "Estado de la solicitud de su cuenta en SIGED.";
                    objCorreoElectronico.Agregar_Receptor(objMiembro.Email, objMiembro.NombreCompleto);
                    string Mensaje = "Bienvenido a SIGED.\r\n\r\nSe le notifica que se ha enviado una solicitud por parte de un administrador de " + objGrupo.Nombre + " a nuestro sistema SIGED para habilitarle una cuenta.\r\n\r\nTan pronto se apruebe la solicitud le enviaremos un correo electrónico con los pasos a seguir para ingresar al sistema SIGED.\r\n";
                    objCorreoElectronico.ContruccionDelCuerpoClasico(DateTime.Now.ToUniversalTime(), Mensaje);
                    objCorreoElectronico.EnviarMail();
                    objCorreoElectronico = null;

                    Codigo = new CodigosDeActivacionOAD().GenerarCodigoCuenta(Id_Miembro, SessionManager.Id_Cuenta);

                    objTransaccion.Complete();

                    return Codigo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LP_CodigosDeActivacionNuevosUsuariosResult> ListaDeCodigosParaAprobar()
        {
            CodigosDeActivacionOAD _objCodigosDeActivacion = new CodigosDeActivacionOAD();
            return _objCodigosDeActivacion.ListaDeCodigosParaAprobar();
        }

        public void AprobarCodigo(long Id, long Id_Cuenta)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    CodigosDeActivacion objCodigo = this.Seleccionar_Id_Unico(Id);
                    Cuentas objCuenta = new CuentasLN().Seleccionar_Id_Unico(Id_Cuenta);

                    objCodigo.Id_CuentaActivadora = Id_Cuenta;
                    objCodigo.Aprobado = true;
                    objCodigo.FechaActivacion_Cuenta = DateTime.Now.ToUniversalTime();

                    Miembro objMiembro = new MiembroLN().Seleccionar_Id(objCodigo.Id_Miembro_Destino.Value);

                    CorreoElectronico objCorreoElectronico = new CorreoElectronico(global::SIGED_3.CRM.Model.Properties.Settings.Default.EmisorDeLosCorreos, global::SIGED_3.CRM.Model.Properties.Settings.Default.NombreCompania);
                    objCorreoElectronico.p_strAsunto = "Se ha admitido su cuenta en SIGED.";
                    objCorreoElectronico.Agregar_Receptor(objMiembro.Email, objMiembro.NombreCompleto);
                    string Mensaje = "Buenos días, se le informa que se le ha habilitado el acceso a el sistema SIGED, por favor clicar en el siguiente vinculo para completar su registro: <a href=\"" + global::SIGED_3.CRM.Model.Properties.Settings.Default.URLCompania + "Modulos/NuevoUsuario/Registro.aspx?Num1=" + objCodigo.Id_Miembro_Destino.Value.ToString() + "\" target=\"_blank\">Activar cuenta.</a>\r\n";
                    objCorreoElectronico.ContruccionDelCuerpoClasico(DateTime.Now.ToUniversalTime(), Mensaje);
                    objCorreoElectronico.EnviarMail();
                    objCorreoElectronico = null;

                    this.Actualizar(objCodigo);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}