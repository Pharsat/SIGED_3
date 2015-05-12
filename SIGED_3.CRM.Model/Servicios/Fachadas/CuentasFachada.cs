using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SIGED_3.CRM.Model.Negocio.Logica;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class CuentasFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Cuentas
        /// </summary>
        /// <returns>Lista de registros tipo Cuentas</returns>
        public List<Cuentas> Seleccionar_All()
        {
            CuentasLN objCuentas = new CuentasLN();
            return objCuentas.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Cuentas
        /// </summary>
        /// <param name=Id>Identificador de la Cuentas</param>
        /// <returns>Objeto singular del tipo Cuentas</returns>
        public List<Cuentas> Seleccionar_Id(long Id)
        {
            CuentasLN objCuentas = new CuentasLN();
            return objCuentas.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Cuentas en la base de datos.
        /// </summary>
        /// <param name=objCuentas>Objeto Cuentas a guardar</param>
        public void Guardar(Cuentas objCuentas)
        {
            CuentasLN _objCuentas = new CuentasLN();
            _objCuentas.Guardar(objCuentas);
        }
        /// <summary>
        /// Guarda el objeto cuenta y obtiene su Id
        /// </summary>
        /// <param name="objCuentas">cuenta a guardar</param>
        public long Guardar_2(Cuentas objCuentas)
        {
            CuentasLN _objCuentas = new CuentasLN();
            return _objCuentas.Guardar_2(objCuentas);
        }
        /// <summary>
        /// Elimina un objeto del tipo Cuentas, se recibe su Id unicamente
        /// </summary>
        /// <param name=objCuentas>Identificativo del(a) Cuentas</param>
        public void Eliminar(Cuentas objCuentas)
        {
            CuentasLN _objCuentas = new CuentasLN();
            _objCuentas.Eliminar(objCuentas);
        }
        /// <summary>
        /// Actualiza una Cuentas, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objCuentas>Objeto del tipo Cuentas</param>
        public void Actualizar(Cuentas objCuentas)
        {
            CuentasLN _objCuentas = new CuentasLN();
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
            CuentasLN _objCuentas = new CuentasLN();
            return _objCuentas.Validar_Usuario(Usuario, Contrasena);
        }
        /// <summary>
        /// Metodo para comprocar si ya existe un nombre de usuario.
        /// </summary>
        /// <param name="Usuario">usuaruio a promprobar</param>
        /// <returns>si el uxuario existe o no</returns>
        public bool ComprobarUsuario(string Usuario)
        {
            CuentasLN _objCuentas = new CuentasLN();
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
            CuentasLN _objCuentas = new CuentasLN();
            return _objCuentas.RegistrarAcceso(NombreGrupo, Id_Pais, Id_Provincia, Id_Ciudad, DescripcionGrupo, TipoDeDocumento, NroDocumento, Nombres, Apellidos, FechaNacimiento, Mail, Usuario, Contrasena, _CodigosDeActivacion);
        }
        /// <summary>
        /// Valida el estado de la cuenta y si es correcto la activa.
        /// </summary>
        /// <param name="Usuario">usuaruio a promprobar</param>
        /// <returns>si el uxuario existe o no</returns>
        public bool ComprobarActivacionCuenta(long Cuenta, int CodigoDeActivacion)
        {
            CuentasLN _objCuentas = new CuentasLN();
            return _objCuentas.ComprobarActivacionCuenta(Cuenta, CodigoDeActivacion);
        }
        /// <summary>
        /// Metodo para recordar la contraseña plvidada
        /// </summary>
        /// <param name="Usuario">usuario al cual recoerdarle la contraseña</param>
        public void RecordarContrasena(string Usuario)
        {
            CuentasLN _objCuentas = new CuentasLN();
            _objCuentas.RecordarContrasena(Usuario);
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
            CuentasLN _objCuentas = new CuentasLN();
            return _objCuentas.CambioContrasena(Id_Cuenta, Antiguo, Nuevo);
        }

        public List<LP_Usuarios_X_Cuentas_RolResult> CuentasXRolesXMiembro(string nombreDeUsuario)
        {
            CuentasLN _objCuentas = new CuentasLN();
            return _objCuentas.CuentasXRolesXMiembro(nombreDeUsuario);
        }

        public bool RegistrarAccesoDos(long Id_Grupo, long Id_Miembro, string Usuario, string Contrasena, string _CodigosDeActivacion)
        {
            CuentasLN _objCuentas = new CuentasLN();
            return _objCuentas.RegistrarAccesoDos(Id_Grupo, Id_Miembro, Usuario, Contrasena, _CodigosDeActivacion);
        }
    }
}
