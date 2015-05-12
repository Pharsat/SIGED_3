using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Pedido_DetalleOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Pedido_Detalle> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Pedido_Detalle.ToList();
            }
        }
        /// <summary>
        /// Selecciona un registor de la tabla detalle.
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Pedido_Detalle Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Pedido_Detalle.Any(p => p.Id == Id))
                {
                    return dc.Pedido_Detalle.Single(p => p.Id == Id);
                }
                else
                {
                    return new Pedido_Detalle();
                }
            }
        }
        /// <summary>
        /// Obtiene todos los contactos de un Pedido
        /// </summary>
        /// <param name="Id_Pedido">Identificativo del Pedido</param>
        /// <returns>Lista de los contactos del Pedido</returns>
        public List<Pedido_Detalle> Seleccionar_By_Pedido(long Id_Pedido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var Query = from p in dc.Pedido_Detalle
                            where p.Id_Pedido == Id_Pedido
                            select p;
                return Query.ToList();
            }
        }
        /// <summary>
        /// Trae todos los pedido detalle ya con su lista.
        /// </summary>
        /// <param name="Id_Pedido">id del pedido padre</param>
        /// <returns>lista de detalles de pedido</returns>
        public List<LS_Pedido_DetalleResult> Seleccionar_By_Pedido_LP(long Id_Pedido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
               return  dc.LS_Pedido_Detalle(Id_Pedido).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Pedido_Detalle objPedido_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Pedido_Detalle.InsertOnSubmit(objPedido_Detalle);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Pedido_Detalle objPedido_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Pedido_Detalle _objPedido_Detalle = dc.Pedido_Detalle.Single(p => p.Id == objPedido_Detalle.Id);
                dc.Pedido_Detalle.DeleteOnSubmit(_objPedido_Detalle);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Pedido_Detalle objPedido_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Pedido_Detalle _objPedido_Detalle = dc.Pedido_Detalle.Single(p => p.Id == objPedido_Detalle.Id);
                _objPedido_Detalle.Id = objPedido_Detalle.Id;
                _objPedido_Detalle.Id_Pedido = objPedido_Detalle.Id_Pedido;
                _objPedido_Detalle.Id_Recurso = objPedido_Detalle.Id_Recurso;
                _objPedido_Detalle.Cantidad = objPedido_Detalle.Cantidad;
                _objPedido_Detalle.ValorUnitario = objPedido_Detalle.ValorUnitario;
                _objPedido_Detalle.Id_UnidadDeMedida = objPedido_Detalle.Id_UnidadDeMedida;
                _objPedido_Detalle.Observaciones = objPedido_Detalle.Observaciones;
                dc.SubmitChanges();
            }
        }
    }
}