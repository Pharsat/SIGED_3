using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ProveedorOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Proveedor> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Proveedor.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Proveedor Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Proveedor.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Proveedors que esten habilitados
        /// </summary>
        /// <returns>Lista de registros tipo cliente</returns>
        public List<Proveedor> Seleccionar_All_Activos(long? Id_GrupoDeMiembros, long? Id_Proveedor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (Id_Proveedor.HasValue)
                {
                    return dc.Proveedor.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros || p.Id == Id_Proveedor.Value).ToList();
                }
                else
                {
                    return dc.Proveedor.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).ToList();
                }
            }
        }
        /// <summary>
        /// Lista principal de la tabla proveedor.
        /// </summary>
        /// <param name="estado">Estado del proveedor en la base de datos</param>
        /// <param name="identificacion">identificacion del proveedor</param>
        /// <param name="id_GrupoDeMiembros"> identificador del grupo de miembro</param>
        /// <param name="nombre">nombre del proveedor o parte de el</param>
        /// <returns>Lista de proveedor</returns>
        public List<LP_ProveedoresResult> Seleccionar_LP(bool? estado, string identificacion, int? id_GrupoDeMiembros, string nombre)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Proveedores(estado, identificacion, id_GrupoDeMiembros, nombre).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Proveedor objProveedor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Proveedor.InsertOnSubmit(objProveedor);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto proveedor y obtiene su Id
        /// </summary>
        /// <param name="objProveedor">Licnete a guardar</param>
        public long Guardar_2(Proveedor objProveedor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Proveedor.InsertOnSubmit(objProveedor);
                dc.SubmitChanges();
                return dc.Proveedor.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Proveedor objProveedor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Proveedor _objProveedor = dc.Proveedor.Single(p => p.Id == objProveedor.Id);
                dc.Proveedor.DeleteOnSubmit(_objProveedor);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Proveedor objProveedor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Proveedor _objProveedor = dc.Proveedor.Single(p => p.Id == objProveedor.Id);
                _objProveedor.Id = objProveedor.Id;
                _objProveedor.Id_GrupoDeMiembros = objProveedor.Id_GrupoDeMiembros;
                _objProveedor.Id_TiposDeDocumento = objProveedor.Id_TiposDeDocumento;
                _objProveedor.Id_Pais = objProveedor.Id_Pais;
                _objProveedor.Id_Provincia = objProveedor.Id_Provincia;
                _objProveedor.Id_Ciudad = objProveedor.Id_Ciudad;
                _objProveedor.Identficacion = objProveedor.Identficacion;
                _objProveedor.Nombre = objProveedor.Nombre;
                _objProveedor.Telefono_1 = objProveedor.Telefono_1;
                _objProveedor.Telefono_2 = objProveedor.Telefono_2;
                _objProveedor.Direccion = objProveedor.Direccion;
                _objProveedor.Email = objProveedor.Email;
                _objProveedor.Estado = objProveedor.Estado;
                _objProveedor.ProveedorPrincipal = objProveedor.ProveedorPrincipal;
                _objProveedor.RazonSocial = objProveedor.RazonSocial;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza los estados de los proveedores ppales para dar davida al nuevo proveedor principal
        /// </summary>
        /// <param name="objProveedor">nuevo proveedor principal</param>
        public void ActualizarProveedorPrincipal(Proveedor objProveedor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (objProveedor.ProveedorPrincipal.Value)
                {
                    dc.Proveedor.Where(p => p.ProveedorPrincipal == true).ToList().ForEach(p => p.ProveedorPrincipal = false);
                }
                dc.SubmitChanges();
            }
        }
    }
}