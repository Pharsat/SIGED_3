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
            CostoRecursoOad objCosto_Recurso = new CostoRecursoOad();
            return objCosto_Recurso.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_Recurso Seleccionar_Id(long Id)
        {
            CostoRecursoOad objCosto_Recurso = new CostoRecursoOad();
            return objCosto_Recurso.Seleccionar_Id(Id);
        }

        public List<Costo_Recurso> Seleccionar_By_Id_Complete(long? id_Costo)
        {
            CostoRecursoOad objCosto_Recurso = new CostoRecursoOad();
            return objCosto_Recurso.Seleccionar_By_Id_Complete(id_Costo);
        }

        /// <summary>
        /// Trae la lista de recursos en la lista de costos
        /// </summary>
        /// <param name="id_Costo">id del costo a traer</param>
        /// <returns>lista de costos</returns>
        public List<LS_Costo_RecursosResult> Seleccionar_By_Id(long? id_Costo)
        {
            CostoRecursoOad objCosto_Recurso = new CostoRecursoOad();
            return objCosto_Recurso.Seleccionar_By_Id(id_Costo);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_Recurso objCostoRecurso)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    CostoRecursoOad _objCosto_Recurso = new CostoRecursoOad();
                    UnidadDeMedida objUnidadDeMedidaAConvertir = new UnidadDeMedidaLN().Seleccionar_Id(objCostoRecurso.Id_UnidadDeMedida.Value);
                    UnidadDeMedida objUnidadDeMedidaOrigen = new UnidadDeMedidaLN().Seleccionar_Id(new RecursoLN().Seleccionar_Id(objCostoRecurso.Id_Recurso.Value).Id_UnidadDeMedida.Value);
                    objCostoRecurso.Consumo = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objCostoRecurso.Consumo.Value, objUnidadDeMedidaOrigen);
                    objCostoRecurso.ValoUnitario = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objCostoRecurso.ValoUnitario.Value, objUnidadDeMedidaOrigen);
                    _objCosto_Recurso.Guardar(objCostoRecurso);
                    new CostoLn().Renovar_Valores(objCostoRecurso.Id_Costo.Value);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarCopia(Costo_Recurso objCostoRecursoAGuardar)
        {
            try
            {
                CostoRecursoOad objCostoRecurso = new CostoRecursoOad();
                objCostoRecurso.Guardar(objCostoRecursoAGuardar);
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
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    objCosto_Recurso = this.Seleccionar_Id(objCosto_Recurso.Id);
                    CostoRecursoOad _objCosto_Recurso = new CostoRecursoOad();
                    _objCosto_Recurso.Eliminar(objCosto_Recurso);
                    new CostoLn().Renovar_Valores(objCosto_Recurso.Id_Costo.Value);
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
        public void Actualizar(Costo_Recurso objCosto_Recurso)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    CostoRecursoOad _objCosto_Recurso = new CostoRecursoOad();
                    _objCosto_Recurso.Actualizar(objCosto_Recurso);
                    new CostoLn().Renovar_Valores(objCosto_Recurso.Id_Costo.Value);
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