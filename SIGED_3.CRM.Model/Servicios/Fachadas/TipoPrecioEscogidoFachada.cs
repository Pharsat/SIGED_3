using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class TipoPrecioEscogidoFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla TipoPrecioEscogido
        /// </summary>
        /// <returns>Lista de registros tipo TipoPrecioEscogido</returns>
        public List<TipoPrecioEscogido> Seleccionar_All()
        {
            TipoPrecioEscogidoLN objTipoPrecioEscogido = new TipoPrecioEscogidoLN();
            return objTipoPrecioEscogido.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla TipoPrecioEscogido
        /// </summary>
        /// <param name=Id>Identificador de la TipoPrecioEscogido</param>
        /// <returns>Objeto singular del tipo TipoPrecioEscogido</returns>
        public TipoPrecioEscogido Seleccionar_Id(long Id)
        {
            TipoPrecioEscogidoLN objTipoPrecioEscogido = new TipoPrecioEscogidoLN();
            return objTipoPrecioEscogido.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo TipoPrecioEscogido en la base de datos.
        /// </summary>
        /// <param name=objTipoPrecioEscogido>Objeto TipoPrecioEscogido a guardar</param>
        public void Guardar(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            TipoPrecioEscogidoLN _objTipoPrecioEscogido = new TipoPrecioEscogidoLN();
            _objTipoPrecioEscogido.Guardar(objTipoPrecioEscogido);
        }
        /// <summary>
        /// Guarda el objeto TipoPrecioEscogido y obtiene su Id
        /// </summary>
        /// <param name="objTipoPrecioEscogido">Licnete a guardar</param>
        public long Guardar_2(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            TipoPrecioEscogidoLN _objTipoPrecioEscogido = new TipoPrecioEscogidoLN();
            return _objTipoPrecioEscogido.Guardar_2(objTipoPrecioEscogido);
        }
        /// <summary>
        /// Elimina un objeto del tipo TipoPrecioEscogido, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) TipoPrecioEscogido</param>
        public void Eliminar(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            TipoPrecioEscogidoLN _objTipoPrecioEscogido = new TipoPrecioEscogidoLN();
            _objTipoPrecioEscogido.Eliminar(objTipoPrecioEscogido);
        }
        /// <summary>
        /// Actualiza una TipoPrecioEscogido, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objTipoPrecioEscogido>Objeto del tipo TipoPrecioEscogido</param>
        public void Actualizar(TipoPrecioEscogido objTipoPrecioEscogido)
        {
            TipoPrecioEscogidoLN _objTipoPrecioEscogido = new TipoPrecioEscogidoLN();
            _objTipoPrecioEscogido.Actualizar(objTipoPrecioEscogido);
        }
    }
}