using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class CompraOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Compra> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Compra.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Compra Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Compra.Single(p => p.Id == Id);
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Compras(id_GrupoDeMiembros, desde, hasta).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Compra objCompra)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Compra.InsertOnSubmit(objCompra);
                dc.SubmitChanges();
            }
        }
        public long Guardar_2(Compra objCompra)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Compra.InsertOnSubmit(objCompra);
                dc.SubmitChanges();
                return dc.Compra.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Compra objCompra)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Compra _objCompra = dc.Compra.Single(p => p.Id == objCompra.Id);
                dc.Compra.DeleteOnSubmit(_objCompra);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Compra objCompra)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Compra _objCompra = dc.Compra.Single(p => p.Id == objCompra.Id);
                _objCompra.Id = objCompra.Id;
                _objCompra.Id_GrupoDeMiembros = objCompra.Id_GrupoDeMiembros;
                _objCompra.Id_Comprador = objCompra.Id_Comprador;
                _objCompra.Id_Proveedor = objCompra.Id_Proveedor;
                _objCompra.Consecutivo = objCompra.Consecutivo;
                _objCompra.FechaDeRealizacion = objCompra.FechaDeRealizacion;
                _objCompra.SubTotal = objCompra.SubTotal;
                _objCompra.Total = objCompra.Total;
                _objCompra.IVA = objCompra.IVA;
                _objCompra.Retencion = objCompra.Retencion;
                _objCompra.TotalEnLetras = objCompra.TotalEnLetras;
                _objCompra.Observaciones = objCompra.Observaciones;
                dc.SubmitChanges();
            }
        }
        public List<R_ComprasResult> Informe_Compras(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta, long? id_Proveedor, long? id_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Compras(id_GrupoDeMiembros, desde, hasta, id_Proveedor, id_Recurso).ToList();
            }
        }
    }
}