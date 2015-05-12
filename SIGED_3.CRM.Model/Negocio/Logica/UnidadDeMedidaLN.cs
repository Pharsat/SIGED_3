using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class UnidadDeMedidaLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<UnidadDeMedida> Seleccionar_All()
        {
            UnidadDeMedidaOAD objUnidadDeMedida = new UnidadDeMedidaOAD();
            return objUnidadDeMedida.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public UnidadDeMedida Seleccionar_Id(long Id)
        {
            UnidadDeMedidaOAD objUnidadDeMedida = new UnidadDeMedidaOAD();
            return objUnidadDeMedida.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Seleccona las unidades de medida por tipo de recurso.
        /// </summary>
        /// <param name="Tipo">tipo de la unidad de medida a selecinar</param>
        /// <returns>lista de unidades de medida</returns>
        public List<UnidadDeMedida> Seleccionar_Tipo(long? Id_Cosa, string TipoCosa)
        {
            UnidadDeMedidaOAD objUnidadDeMedida = new UnidadDeMedidaOAD();
            return objUnidadDeMedida.Seleccionar_Tipo(Id_Cosa, TipoCosa);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(UnidadDeMedida objUnidadDeMedida)
        {
            UnidadDeMedidaOAD _objUnidadDeMedida = new UnidadDeMedidaOAD();
            _objUnidadDeMedida.Guardar(objUnidadDeMedida);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(UnidadDeMedida objUnidadDeMedida)
        {
            UnidadDeMedidaOAD _objUnidadDeMedida = new UnidadDeMedidaOAD();
            _objUnidadDeMedida.Eliminar(objUnidadDeMedida);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(UnidadDeMedida objUnidadDeMedida)
        {
            UnidadDeMedidaOAD _objUnidadDeMedida = new UnidadDeMedidaOAD();
            _objUnidadDeMedida.Actualizar(objUnidadDeMedida);
        }
    }
}