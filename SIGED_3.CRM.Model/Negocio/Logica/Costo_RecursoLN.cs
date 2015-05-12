using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Costo_RecursoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_Recurso> Seleccionar_All()
        {
            Costo_RecursoOAD objCosto_Recurso = new Costo_RecursoOAD();
            return objCosto_Recurso.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_Recurso Seleccionar_Id(long Id)
        {
            Costo_RecursoOAD objCosto_Recurso = new Costo_RecursoOAD();
            return objCosto_Recurso.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae la lista de recursos en la lista de costos
        /// </summary>
        /// <param name="id_Costo">id del costo a traer</param>
        /// <returns>lista de costos</returns>
        public List<LS_Costo_RecursosResult> Seleccionar_By_Id(long? id_Costo)
        {
            Costo_RecursoOAD objCosto_Recurso = new Costo_RecursoOAD();
            return objCosto_Recurso.Seleccionar_By_Id(id_Costo);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_Recurso objCosto_Recurso)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Costo_RecursoOAD _objCosto_Recurso = new Costo_RecursoOAD();
                    UnidadDeMedida objUnidadDeMedidaAConvertir = new UnidadDeMedidaLN().Seleccionar_Id(objCosto_Recurso.Id_UnidadDeMedida.Value);
                    UnidadDeMedida objUnidadDeMedidaOrigen = new UnidadDeMedidaLN().Seleccionar_Id(new RecursoLN().Seleccionar_Id(objCosto_Recurso.Id_Recurso.Value).Id_UnidadDeMedida.Value);
                    objCosto_Recurso.Consumo = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objCosto_Recurso.Consumo.Value, objUnidadDeMedidaOrigen);
                    objCosto_Recurso.ValoUnitario = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objCosto_Recurso.ValoUnitario.Value, objUnidadDeMedidaOrigen);
                    _objCosto_Recurso.Guardar(objCosto_Recurso);
                    new CostoLN().Renovar_Valores(objCosto_Recurso.Id_Costo.Value);
                    objTransaccion.Complete();
                }
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
        public void Eliminar(Costo_Recurso objCosto_Recurso)
        {
            Costo_RecursoOAD _objCosto_Recurso = new Costo_RecursoOAD();
            _objCosto_Recurso.Eliminar(objCosto_Recurso);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo_Recurso objCosto_Recurso)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Costo_RecursoOAD _objCosto_Recurso = new Costo_RecursoOAD();
                    _objCosto_Recurso.Actualizar(objCosto_Recurso);
                    new CostoLN().Renovar_Valores(objCosto_Recurso.Id_Costo.Value);
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