using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Enum;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class CompraLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Compra> Seleccionar_All()
        {
            CompraOAD objCompra = new CompraOAD();
            return objCompra.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Compra Seleccionar_Id(long Id)
        {
            CompraOAD objCompra = new CompraOAD();
            return objCompra.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Carca la lista principal de compras.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">El identificador del grupo de miembros</param>
        /// <param name="desde">la fecha inicial del periodo a buscar.</param>
        /// <param name="hasta">la fecha final del periodo final.</param>
        /// <returns>Lista del resultado de la vita ppal de compras</returns>
        public List<LP_ComprasResult> Seleccionar_LP(int? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            CompraOAD objCompra = new CompraOAD();
            return objCompra.Seleccionar_LP(id_GrupoDeMiembros, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Compra objCompra)
        {
            CompraOAD _objCompra = new CompraOAD();
            _objCompra.Guardar(objCompra);
        }
        public long Guardar_2(Compra objCompra)
        {
            try
            {
                long Id;
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    CompraOAD _objCompra = new CompraOAD();
                    objCompra.Consecutivo = new ConsecutivosLN().TomarConsecutivo((long)Modulo_Enum.Compras, objCompra.Id_GrupoDeMiembros.Value);
                    objCompra.IVA = 0;
                    objCompra.Retencion = 0;
                    objCompra.SubTotal = 0;
                    objCompra.Total = 0;
                    objCompra.TotalEnLetras = new Genericos().ValorATexto(objCompra.Total.Value);
                    Id = _objCompra.Guardar_2(objCompra);
                    objTransacion.Complete();
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
        public void Eliminar(Compra objCompra)
        {
            CompraOAD _objCompra = new CompraOAD();
            _objCompra.Eliminar(objCompra);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Compra objCompra)
        {
            try
            {
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    CompraOAD _objCompra = new CompraOAD();

                    List<Compra_Detalle> objDetalles = new Compra_DetalleOAD().Seleccionar_All(objCompra.Id).ToList();
                    objCompra.SubTotal = objDetalles.Sum(p => p.Total);
                    objCompra.Total = (objCompra.SubTotal + ((objCompra.SubTotal * objCompra.IVA) / 100) - ((objCompra.SubTotal * objCompra.Retencion) / 100));
                    objCompra.TotalEnLetras = new Genericos().ValorATexto(objCompra.Total.Value);

                    _objCompra.Actualizar(objCompra);
                    objTransacion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<R_ComprasResult> Informe_Compras(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta, long? id_Proveedor, long? id_Recurso)
        {
            CompraOAD _objCompra = new CompraOAD();
            return _objCompra.Informe_Compras(id_GrupoDeMiembros, desde, hasta, id_Proveedor, id_Recurso);
        }
    }
}