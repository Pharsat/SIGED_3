using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;

namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class RolesLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Roles> Seleccionar_All()
        {
            RolesOAD objRoles = new RolesOAD();
            return objRoles.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Roles Seleccionar_Id(long Id)
        {
            RolesOAD objRoles = new RolesOAD();
            return objRoles.Seleccionar_Id(Id);
        }

        /// <summary>
        /// Lista principal de la tabla cliente.
        /// </summary>
        /// <param name="estado">Estado del cliente en la base de datos</param>
        /// <param name="identificacion">identificacion del cliente</param>
        /// <param name="id_GrupoDeMiembros"> identificador del grupo de miembro</param>
        /// <param name="nombre">nombre del cliente o parte de el</param>
        /// <returns>Lista de cliente</returns>
        public List<LP_RolesResult> Seleccionar_LP(int? id_GrupoDeMiembros)
        {
            RolesOAD objRoles = new RolesOAD();
            return objRoles.Seleccionar_LP(id_GrupoDeMiembros);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Roles objRoles)
        {
            RolesOAD _objRoles = new RolesOAD();
            _objRoles.Guardar(objRoles);
        }
        /// <summary>
        /// Guarda el objeto cliente y obtiene su Id
        /// </summary>
        /// <param name="objRoles">Licnete a guardar</param>
        public long Guardar_2(Roles objRoles)
        {
            RolesOAD _objRoles = new RolesOAD();
            return _objRoles.Guardar_2(objRoles);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Roles objRoles)
        {
            RolesOAD _objRoles = new RolesOAD();
            _objRoles.Eliminar(objRoles);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Roles objRoles)
        {
            RolesOAD _objRoles = new RolesOAD();
            _objRoles.Actualizar(objRoles);
        }

        public List<Roles> Lista_RolesPermitidos()
        {
            RolesOAD _objRoles = new RolesOAD();
            return _objRoles.Lista_RolesPermitidos(SessionManager.Id_GrupoDeMiembros, new List<int?> { (int)Roles_Enum.ClientePremium});
        }
    }
}
