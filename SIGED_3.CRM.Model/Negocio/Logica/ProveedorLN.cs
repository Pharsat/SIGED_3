using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class ProveedorLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Proveedor> Seleccionar_All()
        {
            ProveedorOAD objProveedor = new ProveedorOAD();
            return objProveedor.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Proveedor Seleccionar_Id(long Id)
        {
            ProveedorOAD objProveedor = new ProveedorOAD();
            return objProveedor.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Proveedors que esten habilitados
        /// </summary>
        /// <returns>Lista de registros tipo cliente</returns>
        public List<Proveedor> Seleccionar_All_Activos(long? Id_GrupoDeMiembros, long? Id_Proveedor)
        {
            ProveedorOAD objProveedor = new ProveedorOAD();
            return objProveedor.Seleccionar_All_Activos(Id_GrupoDeMiembros, Id_Proveedor);
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
            ProveedorOAD objProveedor = new ProveedorOAD();
            return objProveedor.Seleccionar_LP(estado, identificacion, id_GrupoDeMiembros, nombre);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Proveedor objProveedor)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    ProveedorOAD _objProveedor = new ProveedorOAD();
                    _objProveedor.ActualizarProveedorPrincipal(objProveedor);
                    _objProveedor.Guardar(objProveedor);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Guarda el objeto Proveedor y obtiene su Id
        /// </summary>
        /// <param name="objProveedor">Licnete a guardar</param>
        public long Guardar_2(Proveedor objProveedor)
        {
            try
            {
                long Id = 0;
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    ProveedorOAD _objProveedor = new ProveedorOAD();
                    _objProveedor.ActualizarProveedorPrincipal(objProveedor);
                    Id = _objProveedor.Guardar_2(objProveedor);
                    objTransaccion.Complete();
                }
                return Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Proveedor objProveedor)
        {
            ProveedorOAD _objProveedor = new ProveedorOAD();
            _objProveedor.Eliminar(objProveedor);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Proveedor objProveedor)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    ProveedorOAD _objProveedor = new ProveedorOAD();
                    _objProveedor.ActualizarProveedorPrincipal(objProveedor);
                    _objProveedor.Actualizar(objProveedor);
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