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
    internal class Costo_ProcesoDeFabricacionLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_ProcesoDeFabricacion> Seleccionar_All()
        {
            Costo_ProcesoDeFabricacionOAD objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionOAD();
            return objCosto_ProcesoDeFabricacion.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_ProcesoDeFabricacion Seleccionar_Id(long Id)
        {
            Costo_ProcesoDeFabricacionOAD objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionOAD();
            return objCosto_ProcesoDeFabricacion.Seleccionar_Id(Id);
        }
        /// <summary>
        /// seleccionar todos los procesos agregados a este costo
        /// </summary>
        /// <param name="id_Costo">costo al cual se le consultaran los procesos</param>
        /// <returns>Lista de procesos</returns>
        public List<LS_Costo_ProcesosResult> Seleccionar_By_Id(long? id_Costo)
        {
            Costo_ProcesoDeFabricacionOAD objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionOAD();
            return objCosto_ProcesoDeFabricacion.Seleccionar_By_Id(id_Costo);
        }

        public List<Costo_ProcesoDeFabricacion> Seleccionar_By_Id_Complete(long? id_Costo)
        {
            Costo_ProcesoDeFabricacionOAD objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionOAD();
            return objCosto_ProcesoDeFabricacion.Seleccionar_By_Id_Complete(id_Costo);
        }

        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Costo_ProcesoDeFabricacionOAD _objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionOAD();
                    UnidadDeMedida objUnidadDeMedidaAConvertir = new UnidadDeMedidaLN().Seleccionar_Id(objCosto_ProcesoDeFabricacion.Id_UnidadDeMedida.Value);
                    UnidadDeMedida objUnidadDeMedidaOrigen = new UnidadDeMedidaLN().Seleccionar_Id(new ProcesoDeFabricacionLN().Seleccionar_Id(objCosto_ProcesoDeFabricacion.Id_Proceso.Value).Id_UnidadDeMedida.Value);
                    objCosto_ProcesoDeFabricacion.Cantidad = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objCosto_ProcesoDeFabricacion.Cantidad.Value, objUnidadDeMedidaOrigen);
                    objCosto_ProcesoDeFabricacion.Valor = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objCosto_ProcesoDeFabricacion.Valor.Value, objUnidadDeMedidaOrigen);
                    _objCosto_ProcesoDeFabricacion.Guardar(objCosto_ProcesoDeFabricacion);
                    new CostoLN().Renovar_Valores(objCosto_ProcesoDeFabricacion.Id_Costo.Value);
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
        public void Eliminar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    objCosto_ProcesoDeFabricacion = this.Seleccionar_Id(objCosto_ProcesoDeFabricacion.Id);
                    Costo_ProcesoDeFabricacionOAD _objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionOAD();
                    _objCosto_ProcesoDeFabricacion.Eliminar(objCosto_ProcesoDeFabricacion);
                    new CostoLN().Renovar_Valores(objCosto_ProcesoDeFabricacion.Id_Costo.Value);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Costo_ProcesoDeFabricacionOAD _objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionOAD();
                    _objCosto_ProcesoDeFabricacion.Actualizar(objCosto_ProcesoDeFabricacion);
                    new CostoLN().Renovar_Valores(objCosto_ProcesoDeFabricacion.Id_Costo.Value);
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