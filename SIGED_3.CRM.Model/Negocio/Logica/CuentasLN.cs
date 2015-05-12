using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using System.Configuration;
using SIGED_3.CRM.Model.Util.Comunicacion;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class CuentasLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Cuentas
        /// </summary>
        /// <returns>Lista de registros tipo Cuentas</returns>
        public List<Cuentas> Seleccionar_All()
        {
            CuentasOAD objCuentas = new CuentasOAD();
            return objCuentas.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Cuentas
        /// </summary>
        /// <param name=Id>Identificador de la Cuentas</param>
        /// <returns>Objeto singular del tipo Cuentas</returns>
        public List<Cuentas> Seleccionar_Id(long Id)
        {
            CuentasOAD objCuentas = new CuentasOAD();
            return objCuentas.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Cuentas en la base de datos.
        /// </summary>
        /// <param name=objCuentas>Objeto Cuentas a guardar</param>
        public void Guardar(Cuentas objCuentas)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            _objCuentas.Guardar(objCuentas);
        }
        /// <summary>
        /// Guarda el objeto cuenta y obtiene su Id
        /// </summary>
        /// <param name="objCuentas">cuenta a guardar</param>
        public long Guardar_2(Cuentas objCuentas)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            return _objCuentas.Guardar_2(objCuentas);
        }
        /// <summary>
        /// Elimina un objeto del tipo Cuentas, se recibe su Id unicamente
        /// </summary>
        /// <param name=objCuentas>Identificativo del(a) Cuentas</param>
        public void Eliminar(Cuentas objCuentas)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            _objCuentas.Eliminar(objCuentas);
        }
        /// <summary>
        /// Actualiza una Cuentas, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objCuentas>Objeto del tipo Cuentas</param>
        public void Actualizar(Cuentas objCuentas)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            _objCuentas.Actualizar(objCuentas);
        }
        /// <summary>
        /// Loguea el usuario ante el sistema
        /// </summary>
        /// <param name="Usuario">Usuario del miembro</param>
        /// <param name="Contrasena">Constraseña del miembro</param>
        /// <returns>Retorna el miembro si lo hay si no retorna nulo y el logueo es invalido</returns>
        public Cuentas Validar_Usuario(string Usuario, string Contrasena)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            return _objCuentas.Validar_Usuario(Usuario, Contrasena);
        }
        /// <summary>
        /// Metodo para comprocar si ya existe un nombre de usuario.
        /// </summary>
        /// <param name="Usuario">usuaruio a promprobar</param>
        /// <returns>si el uxuario existe o no</returns>
        public bool ComprobarUsuario(string Usuario)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            return _objCuentas.ComprobarUsuario(Usuario);
        }
        /// <summary>
        /// Regiustra un nuevo usuario a la plicación.
        /// </summary>
        /// <param name="NombreGrupo"></param>
        /// <param name="Id_Pais"></param>
        /// <param name="Id_Provincia"></param>
        /// <param name="Id_Ciudad"></param>
        /// <param name="DescripcionGrupo"></param>
        /// <param name="TipoDeDocumento"></param>
        /// <param name="NroDocumento"></param>
        /// <param name="Nombres"></param>
        /// <param name="Apellidos"></param>
        /// <param name="FechaNacimiento"></param>
        /// <param name="Mail"></param>
        /// <param name="Usuario"></param>
        /// <param name="Contrasena"></param>
        /// <returns>verdadero si la transaccion tubo exito falso sis la transacion tubo fallo</returns>
        public bool RegistrarAcceso(string NombreGrupo, long Id_Pais, long Id_Provincia, long Id_Ciudad, string DescripcionGrupo, long TipoDeDocumento, long NroDocumento, string Nombres, string Apellidos, DateTime FechaNacimiento, string Mail, string Usuario, string Contrasena, string _CodigosDeActivacion)
        {
            try
            {
                bool Resultado;
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    GrupoDeMiembros objGrupo = new GrupoDeMiembros();
                    objGrupo.Id_Ciudad = Id_Ciudad;
                    objGrupo.Id_Pais = Id_Pais;
                    objGrupo.Id_Provincia = Id_Provincia;
                    objGrupo.Nombre = NombreGrupo;
                    objGrupo.Descripcion = DescripcionGrupo;
                    objGrupo.Id = new GrupoDeMiembrosLN().Guardar_2(objGrupo);
                    Miembro objMiembro = new Miembro();
                    objMiembro.Id_Ciudad = Id_Ciudad;
                    objMiembro.Id_Pais = Id_Pais;
                    objMiembro.Id_Provincia = Id_Provincia;
                    objMiembro.Id_GrupoDeMiembros = objGrupo.Id;
                    objMiembro.Apellidos = Apellidos;
                    objMiembro.Nombres = Nombres;
                    objMiembro.Email = Mail;
                    objMiembro.FechaDeNacimiento = FechaNacimiento;
                    objMiembro.Id_TipoDeDocumento = TipoDeDocumento;
                    objMiembro.Identificacion = NroDocumento;
                    objMiembro.Id = new MiembroLN().Guardar_2(objMiembro);
                    Cuentas objCuenta = new Cuentas();
                    objCuenta.Contrasena = Contrasena;
                    objCuenta.dtFechaApertura = DateTime.Now;
                    objCuenta.dtFechaCierre = DateTime.Now.AddDays(7);
                    objCuenta.Id_GrupoDeMiembros = objGrupo.Id;
                    objCuenta.Id_Miembro = objMiembro.Id;
                    objCuenta.Usuario = Usuario;
                    objCuenta.EstadoDeActivacion = false;
                    objCuenta.CodigoDeActivacion = new Random().Next(10000, 99999);
                    objCuenta.Id_Rol = (int)Roles_Enum.ClientePremium;
                    objCuenta.Id = new CuentasLN().Guardar_2(objCuenta);
                    List<Modulo> lstModulos = new ModuloLN().Seleccionar_All();

                    CorreoElectronico objCorreoElectronico = new CorreoElectronico(global::SIGED_3.CRM.Model.Properties.Settings.Default.EmisorDeLosCorreos, global::SIGED_3.CRM.Model.Properties.Settings.Default.NombreCompania);
                    objCorreoElectronico.p_strAsunto = "Activación de cuenta en SIGED.";
                    objCorreoElectronico.Agregar_Receptor(objMiembro.Email, objMiembro.NombreCompleto);
                    string Mensaje = "Bienvenido a SIGED.\r\n\r\nPara activar su Cuenta debe hacer clic en el siguiente enlace: <a href=\"" + global::SIGED_3.CRM.Model.Properties.Settings.Default.URLCompania + "Modulos/Login.aspx" + "?Num1=" + objCuenta.Id.ToString() + "&Num2=" + objCuenta.CodigoDeActivacion + "\"target=\"_blank\">Activar cuenta</a>.\r\n";
                    objCorreoElectronico.ContruccionDelCuerpoClasico(DateTime.Now, Mensaje);
                    objCorreoElectronico.EnviarMail();
                    objCorreoElectronico = null;
                    if (new CodigosDeActivacionLN().Verificar(_CodigosDeActivacion, true))
                    {
                        objTransaccion.Complete();
                        Resultado = true;
                    }
                    else
                    {
                        Resultado = false;
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RegistrarAccesoDos(long Id_Grupo, long Id_Miembro, string Usuario, string Contrasena, string _CodigosDeActivacion)
        {
            try
            {
                bool Resultado;
                using (TransactionScope objTransaccion = new TransactionScope())
                {

                    GrupoDeMiembros objGrupo = new GrupoDeMiembrosLN().Seleccionar_Id(Id_Grupo);
                    Miembro objMiembro = new MiembroLN().Seleccionar_Id(Id_Miembro);

                    Cuentas objCuenta = new Cuentas();
                    objCuenta.Contrasena = Contrasena;
                    objCuenta.dtFechaApertura = DateTime.Now;
                    objCuenta.dtFechaCierre = DateTime.Now.AddDays(7);
                    objCuenta.Id_GrupoDeMiembros = objGrupo.Id;
                    objCuenta.Id_Miembro = objMiembro.Id;
                    objCuenta.Usuario = Usuario;
                    objCuenta.EstadoDeActivacion = false;
                    objCuenta.CodigoDeActivacion = new Random().Next(10000, 99999);
                    objCuenta.Id_Rol = (int)Roles_Enum.ClientePremium;
                    objCuenta.Id = new CuentasLN().Guardar_2(objCuenta);
                    List<Modulo> lstModulos = new ModuloLN().Seleccionar_All();

                    CorreoElectronico objCorreoElectronico = new CorreoElectronico(global::SIGED_3.CRM.Model.Properties.Settings.Default.EmisorDeLosCorreos, global::SIGED_3.CRM.Model.Properties.Settings.Default.NombreCompania);
                    objCorreoElectronico.p_strAsunto = "Activación de cuenta en SIGED.";
                    objCorreoElectronico.Agregar_Receptor(objMiembro.Email, objMiembro.NombreCompleto);
                    string Mensaje = "Bienvenido a SIGED.\r\n\r\nPara activar su Cuenta debe hacer clic en el siguiente enlace: <a href=\"" + global::SIGED_3.CRM.Model.Properties.Settings.Default.URLCompania + "Modulos/Login.aspx" + "?Num1=" + objCuenta.Id.ToString() + "&Num2=" + objCuenta.CodigoDeActivacion + "\"target=\"_blank\">Activar cuenta</a>.\r\n";
                    objCorreoElectronico.ContruccionDelCuerpoClasico(DateTime.Now, Mensaje);
                    objCorreoElectronico.EnviarMail();
                    objCorreoElectronico = null;
                    if (new CodigosDeActivacionLN().Verificar(_CodigosDeActivacion, true))
                    {
                        objTransaccion.Complete();
                        Resultado = true;
                    }
                    else
                    {
                        Resultado = false;
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Valida el estado de la cuenta y si es correcto la activa.
        /// </summary>
        /// <param name="Usuario">usuaruio a promprobar</param>
        /// <returns>si el uxuario existe o no</returns>
        public bool ComprobarActivacionCuenta(long Cuenta, int CodigoDeActivacion)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            return _objCuentas.ComprobarActivacionCuenta(Cuenta, CodigoDeActivacion);
        }
        /// <summary>
        /// Metodo para recordar la contraseña plvidada
        /// </summary>
        /// <param name="Usuario">usuario al cual recoerdarle la contraseña</param>
        public void RecordarContrasena(string Usuario)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Miembro objMiembro = new CuentasOAD().TomarCorreoElectronico(Usuario);
                    if (objMiembro != null)
                    {
                        string ContrasenProvicional = new CuentasOAD().CreacionDeContrasenaProvicional(Usuario);
                        if (ContrasenProvicional != String.Empty)
                        {
                            CorreoElectronico objCorreoElectronico = new CorreoElectronico(global::SIGED_3.CRM.Model.Properties.Settings.Default.EmisorDeLosCorreos, global::SIGED_3.CRM.Model.Properties.Settings.Default.NombreCompania);
                            objCorreoElectronico.p_strAsunto = "Reposición de contraseña en SIGED.";
                            objCorreoElectronico.Agregar_Receptor(objMiembro.Email, objMiembro.NombreCompleto);
                            string Mensaje = "Reposición de contraseña en SIGED.\r\n\r\nNos ha pedido reestablecer su contraseña, para el proximo ingreso puede usar: <b>" + ContrasenProvicional + "</b> como nueva contraseña.\r\n\r\nSi usted desconoce el motivo de este mensaje por favor ignore el mismo.\r\n";
                            objCorreoElectronico.ContruccionDelCuerpoClasico(DateTime.Now, Mensaje);
                            objCorreoElectronico.EnviarMail();
                            objCorreoElectronico = null;
                            objTransaccion.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Metodo que cambia la contraseña de un usuario.
        /// </summary>
        /// <param name="Id_Cuenta">identificado de la cuenta que aplica el cambio de contrasena</param>
        /// <param name="Antiguo">antigua contrasena</param>
        /// <param name="Nuevo">nueva contrasena</param>
        /// <returns>verdadero si se cambio bien y falso si no</returns>
        public bool CambioContrasena(long Id_Cuenta, string Antiguo, string Nuevo)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            return _objCuentas.CambioContrasena(Id_Cuenta, Antiguo, Nuevo);
        }


        public Cuentas Seleccionar_Id_Unico(long Id)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            return _objCuentas.Seleccionar_Id_Unico(Id);
        }

        public List<LP_Usuarios_X_Cuentas_RolResult> CuentasXRolesXMiembro(string nombreDeUsuario)
        {
            CuentasOAD _objCuentas = new CuentasOAD();
            return _objCuentas.CuentasXRolesXMiembro(SessionManager.Id_GrupoDeMiembros, nombreDeUsuario);
        }
    }
}