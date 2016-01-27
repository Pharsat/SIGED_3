using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Costo_ValorizacionLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_Valorizacion> Seleccionar_All()
        {
            CostoValorizacionOad objCosto_Valorizacion = new CostoValorizacionOad();
            return objCosto_Valorizacion.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_Valorizacion Seleccionar_Id(long Id)
        {
            CostoValorizacionOad objCosto_Valorizacion = new CostoValorizacionOad();
            return objCosto_Valorizacion.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Retorna la lista de valorización
        /// </summary>
        /// <param name="id_Costo">costo al cual pertenecen los parametros de valorización</param>
        /// <returns></returns>
        public List<Costo_Valorizacion> Seleccionar_By_Id(long? id_Costo)
        {
            CostoValorizacionOad objCosto_Valorizacion = new CostoValorizacionOad();
            return objCosto_Valorizacion.Seleccionar_By_Id(id_Costo);
        }

        public List<Costo_Valorizacion> Seleccionar_By_Id_Complete(long? id_Costo)
        {
            CostoValorizacionOad objCosto_Recurso = new CostoValorizacionOad();
            return objCosto_Recurso.Seleccionar_By_Id_Complete(id_Costo);
        }

        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_Valorizacion objCosto_Valorizacion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    CostoValorizacionOad _objCosto_Valorizacion = new CostoValorizacionOad();
                    _objCosto_Valorizacion.Guardar(objCosto_Valorizacion);
                    new CostoLn().Renovar_Valores(objCosto_Valorizacion.Id_Costo.Value);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Guarda el costo valorizacion pero ignora la actualizacion de valores
        /// </summary>
        /// <param name="objCosto_Valorizacion">costo a actualizar</param>
        public void Guardar_IgnorarActualizacion(Costo_Valorizacion objCosto_Valorizacion)
        {
            CostoValorizacionOad _objCosto_Valorizacion = new CostoValorizacionOad();
            _objCosto_Valorizacion.Guardar(objCosto_Valorizacion);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo_Valorizacion objCosto_Valorizacion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    objCosto_Valorizacion = this.Seleccionar_Id(objCosto_Valorizacion.Id);
                    CostoValorizacionOad _objCosto_Valorizacion = new CostoValorizacionOad();
                    _objCosto_Valorizacion.Eliminar(objCosto_Valorizacion);
                    new CostoLn().Renovar_Valores(objCosto_Valorizacion.Id_Costo.Value);
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
        public void Actualizar(Costo_Valorizacion objCosto_Valorizacion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    CostoValorizacionOad _objCosto_Valorizacion = new CostoValorizacionOad();
                    _objCosto_Valorizacion.Actualizar(objCosto_Valorizacion);
                    new CostoLn().Renovar_Valores(objCosto_Valorizacion.Id_Costo.Value);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarCopia(Costo_Valorizacion newCostoConPorcentaje)
        {
            try
            {
                CostoValorizacionOad objCostoValorizacion = new CostoValorizacionOad();
                objCostoValorizacion.Guardar(newCostoConPorcentaje);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}