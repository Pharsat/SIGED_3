using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;

namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class RolesOAD
    {
        public List<Roles> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Roles.ToList();
            }
        }

        public Roles Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Roles.Single(p => p.Id == Id);
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Roles(id_GrupoDeMiembros).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Roles objRoles)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Roles.InsertOnSubmit(objRoles);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto cliente y obtiene su Id
        /// </summary>
        /// <param name="objRoles">Licnete a guardar</param>
        public long Guardar_2(Roles objRoles)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Roles.InsertOnSubmit(objRoles);
                dc.SubmitChanges();
                return dc.Roles.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Roles objRoles)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Roles _objRoles = dc.Roles.Single(p => p.Id == objRoles.Id);
                dc.Roles.DeleteOnSubmit(_objRoles);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Roles objRoles)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Roles _objRoles = dc.Roles.Single(p => p.Id == objRoles.Id);
                _objRoles.Id = objRoles.Id;
                _objRoles.Id_GrupoDeMiembros = objRoles.Id_GrupoDeMiembros;
                _objRoles.Rol = objRoles.Rol;
                dc.SubmitChanges();
            }
        }

        public List<Roles> Lista_RolesPermitidos(long? Id_GrupoDeMiembros, List<int?> RolesPermitidos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Roles.Where(p => p.Id_GrupoDeMiembros == Id_GrupoDeMiembros || RolesPermitidos.Contains(p.Id)).ToList();
            }
        }
    }
}
