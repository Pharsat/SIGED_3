using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class TipoPrecioEscogidoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla TipoPrecioEscogido
        /// </summary>
        /// <returns>Lista de registros tipo TipoPrecioEscogido</returns>
        public List<TipoPrecioEscogido> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.TipoPrecioEscogido.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla TipoPrecioEscogido
        /// </summary>
        /// <param name=Id>Identificador de la TipoPrecioEscogido</param>
        /// <returns>Objeto singular del tipo TipoPrecioEscogido</returns>
        public TipoPrecioEscogido Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.TipoPrecioEscogido.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo TipoPrecioEscogido en la base de datos.
        /// </summary>
        /// <param name=objTipoPrecioEscogido>Objeto TipoPrecioEscogido a guardar</param>
        public void Guardar(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.TipoPrecioEscogido.InsertOnSubmit(objTipoPrecioEscogido);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto TipoPrecioEscogido y obtiene su Id
        /// </summary>
        /// <param name="objTipoPrecioEscogido">Licnete a guardar</param>
        public long Guardar_2(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.TipoPrecioEscogido.InsertOnSubmit(objTipoPrecioEscogido);
                dc.SubmitChanges();
                return dc.TipoPrecioEscogido.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo TipoPrecioEscogido, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) TipoPrecioEscogido</param>
        public void Eliminar(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                TipoPrecioEscogido _objTipoPrecioEscogido = dc.TipoPrecioEscogido.Single(p => p.Id == objTipoPrecioEscogido.Id);
                dc.TipoPrecioEscogido.DeleteOnSubmit(_objTipoPrecioEscogido);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una TipoPrecioEscogido, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objTipoPrecioEscogido>Objeto del tipo TipoPrecioEscogido</param>
        public void Actualizar(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                TipoPrecioEscogido _objTipoPrecioEscogido = dc.TipoPrecioEscogido.Single(p => p.Id == objTipoPrecioEscogido.Id);
                _objTipoPrecioEscogido.Id = objTipoPrecioEscogido.Id;
                _objTipoPrecioEscogido.TipoPrecioEscogido1 = objTipoPrecioEscogido.TipoPrecioEscogido1;
                _objTipoPrecioEscogido.Abreviacion = objTipoPrecioEscogido.Abreviacion;
                dc.SubmitChanges();
            }
        }
    }
}