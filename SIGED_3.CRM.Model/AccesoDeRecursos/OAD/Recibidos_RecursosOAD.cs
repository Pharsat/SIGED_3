using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Recibidos_RecursosOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Recibidos_Recursos> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recibidos_Recursos.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Recibidos_Recursos Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Recibidos_Recursos.Any(p => p.Id == Id))
                {
                    return dc.Recibidos_Recursos.Single(p => p.Id == Id);
                }
                else
                {
                    return new Recibidos_Recursos();
                }
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Recibidos_Recursos objRecibidos_Recursos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Recibidos_Recursos.InsertOnSubmit(objRecibidos_Recursos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Recibidos_Recursos objRecibidos_Recursos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Recibidos_Recursos _objRecibidos_Recursos = dc.Recibidos_Recursos.Single(p => p.Id == objRecibidos_Recursos.Id);
                dc.Recibidos_Recursos.DeleteOnSubmit(_objRecibidos_Recursos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Recibidos_Recursos objRecibidos_Recursos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Recibidos_Recursos _objRecibidos_Recursos = dc.Recibidos_Recursos.Single(p => p.Id == objRecibidos_Recursos.Id);
                _objRecibidos_Recursos.Id = objRecibidos_Recursos.Id;
                _objRecibidos_Recursos.Id_Recibido = objRecibidos_Recursos.Id_Recibido;
                _objRecibidos_Recursos.Id_Recurso = objRecibidos_Recursos.Id_Recurso;
                _objRecibidos_Recursos.Id_UnidadDeMedida = objRecibidos_Recursos.Id_UnidadDeMedida;
                _objRecibidos_Recursos.Id_OrdenesDeTrabajo_Recurso = objRecibidos_Recursos.Id_OrdenesDeTrabajo_Recurso;
                _objRecibidos_Recursos.Cantidad = objRecibidos_Recursos.Cantidad;
                dc.SubmitChanges();
            }
        }
        public List<LS_Recibidos_RecursoResult> Seleccionar_By_Recibido_LP(long Id_Recibido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_Recibidos_Recurso(Id_Recibido).ToList();
            }
        }
        public void IncluirARecibidoOrdenesDetalles(OrdenesDeTrabajo_Recursos objOrdenRecibidoDetalle, long Id_Recibido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Recibidos_Recursos _Recibidos_Recurso = new Recibidos_Recursos();
                _Recibidos_Recurso.Id_Recibido = Id_Recibido;
                _Recibidos_Recurso.Id_OrdenesDeTrabajo_Recurso = objOrdenRecibidoDetalle.Id;
                _Recibidos_Recurso.Id_Recurso = objOrdenRecibidoDetalle.Id_Recurso;
                _Recibidos_Recurso.Id_UnidadDeMedida = objOrdenRecibidoDetalle.Id_UnidadDeMedida;
                _Recibidos_Recurso.Cantidad = objOrdenRecibidoDetalle.Cantidad - (dc.Recibidos_Recursos.Any(odtr => odtr.Id_OrdenesDeTrabajo_Recurso == objOrdenRecibidoDetalle.Id) ? dc.Recibidos_Recursos.Where(odtr => odtr.Id_OrdenesDeTrabajo_Recurso == objOrdenRecibidoDetalle.Id).Sum(odtr => odtr.Cantidad) : 0);
                if (_Recibidos_Recurso.Cantidad.Value > 0)
                {
                    dc.Recibidos_Recursos.InsertOnSubmit(_Recibidos_Recurso);
                    dc.SubmitChanges();
                }
            }
        }
    }
}