using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Compra_DetalleOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Compra_Detalle> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Compra_Detalle.ToList();
            }
        }

        public List<Compra_Detalle> Seleccionar_All(long? Id_Compra)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Compra_Detalle.Where(p => p.Id_Compra == Id_Compra).ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Compra_Detalle Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Compra_Detalle.Any(p => p.Id == Id))
                {
                    return dc.Compra_Detalle.Single(p => p.Id == Id);
                }
                else
                {
                    return new Compra_Detalle();
                }
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Compra_Detalle objCompra_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Compra_Detalle.InsertOnSubmit(objCompra_Detalle);
                dc.SubmitChanges();
            }
        }
        public List<LS_Compra_DetalleResult> Seleccionar_By_Compra_LP(long Id_Compra)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_Compra_Detalle(Id_Compra).ToList();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Compra_Detalle objCompra_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Compra_Detalle _objCompra_Detalle = dc.Compra_Detalle.Single(p => p.Id == objCompra_Detalle.Id);
                dc.Compra_Detalle.DeleteOnSubmit(_objCompra_Detalle);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Compra_Detalle objCompra_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Compra_Detalle _objCompra_Detalle = dc.Compra_Detalle.Single(p => p.Id == objCompra_Detalle.Id);
                _objCompra_Detalle.Id = objCompra_Detalle.Id;
                _objCompra_Detalle.Id_Compra = objCompra_Detalle.Id_Compra;
                _objCompra_Detalle.Id_Recurso = objCompra_Detalle.Id_Recurso;
                _objCompra_Detalle.Descripcion = objCompra_Detalle.Descripcion;
                _objCompra_Detalle.Cantidad = objCompra_Detalle.Cantidad;
                _objCompra_Detalle.ValorUnitario = objCompra_Detalle.ValorUnitario;
                _objCompra_Detalle.Total = objCompra_Detalle.Total;
                _objCompra_Detalle.Id_Bodega = objCompra_Detalle.Id_Bodega;
                dc.SubmitChanges();
            }
        }
    }
}