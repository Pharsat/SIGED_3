using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Session;

namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class PermisosLN
    {
        public void PrepararRoles()
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    PermisosOAD objPermisos = new PermisosOAD();
                    objPermisos.PrepararRoles();
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public S_ConfiguracionPermisosResult PermisosDeUsuario(long Id_Modulo)
        {
            return SessionManager.ConfiguracionPermisos.Single(p => p.Id_Modulo == Id_Modulo);
        }

        public bool VerMenu(long Id_Modulo)
        {
            return SessionManager.ConfiguracionPermisos.Any(p => p.Id_Modulo == Id_Modulo);
        }

        public List<S_ConfiguracionPermisosResult> ConfiguracionPermisos(long? Id_Cuenta)
        {
            PermisosOAD objPermisos = new PermisosOAD();
            return objPermisos.ConfiguracionPermisos(Id_Cuenta);
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Permisos> Seleccionar_All()
        {
            PermisosOAD objPermisos = new PermisosOAD();
            return objPermisos.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Permisos Seleccionar_Id(long Id)
        {
            PermisosOAD objPermisos = new PermisosOAD();
            return objPermisos.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Obtiene todos los contactos de un cliente
        /// </summary>
        /// <param name="Id_Cliente">Identificativo del cliente</param>
        /// <returns>Lista de los contactos del cliente</returns>
        public List<Permisos> Seleccionar_By_Rol(int Id_Rol)
        {
            PermisosOAD objPermisos = new PermisosOAD();
            return objPermisos.Seleccionar_By_Rol(Id_Rol);
        }

        public List<LS_PermisosResult> Seleccionar_By_Rol_LS(int Id_Rol)
        {
            PermisosOAD objPermisos = new PermisosOAD();
            return objPermisos.Seleccionar_By_Rol_LS(Id_Rol);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Permisos objPermisos)
        {
            PermisosOAD _objPermisos = new PermisosOAD();
            _objPermisos.Guardar(objPermisos);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Permisos objPermisos)
        {
            PermisosOAD _objPermisos = new PermisosOAD();
            _objPermisos.Eliminar(objPermisos);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Permisos objPermisos)
        {
            PermisosOAD _objPermisos = new PermisosOAD();
            _objPermisos.Actualizar(objPermisos);
        }
    }
}
