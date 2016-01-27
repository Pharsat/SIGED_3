namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    using System.Collections.Generic;
    using System.Linq;
    using Negocio.Entidades;

    internal class CostoProcesoDeFabricacionOad
    {
        public List<Costo_ProcesoDeFabricacion> Seleccionar_All()
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo_ProcesoDeFabricacion.ToList();
            }
        }

        public Costo_ProcesoDeFabricacion Seleccionar_Id(long id)
        {
            using (var dc = new ModeloDataContext())
            {
                if (dc.Costo_ProcesoDeFabricacion.Any(p => p.Id == id))
                {
                    return dc.Costo_ProcesoDeFabricacion.Single(p => p.Id == id);
                }
                else
                {
                    return new Costo_ProcesoDeFabricacion();
                }
            }
        }
        /// <summary>
        /// seleccionar todos los procesos agregados a este costo
        /// </summary>
        /// <param name="idCosto">costo al cual se le consultaran los procesos</param>
        /// <returns>Lista de procesos</returns>
        public List<LS_Costo_ProcesosResult> Seleccionar_By_Id(long? idCosto)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.LS_Costo_Procesos(idCosto).ToList();
            }
        }

        public List<Costo_ProcesoDeFabricacion> Seleccionar_By_Id_Complete(long? idCosto)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo_ProcesoDeFabricacion.Where(p => p.Id_Costo == idCosto).ToList();
            }
        }

        public void Guardar(Costo_ProcesoDeFabricacion objCostoProcesoDeFabricacion)
        {
            using (var dc = new ModeloDataContext())
            {
                dc.Costo_ProcesoDeFabricacion.InsertOnSubmit(objCostoProcesoDeFabricacion);
                dc.SubmitChanges();
            }
        }

        public void Eliminar(Costo_ProcesoDeFabricacion objCostoProcesoDeFabricacionAEliminar)
        {
            using (var dc = new ModeloDataContext())
            {
                Costo_ProcesoDeFabricacion objCostoProcesoDeFabricacion = dc.Costo_ProcesoDeFabricacion.Single(p => p.Id == objCostoProcesoDeFabricacionAEliminar.Id);
                dc.Costo_ProcesoDeFabricacion.DeleteOnSubmit(objCostoProcesoDeFabricacion);
                dc.SubmitChanges();
            }
        }

        public void Actualizar(Costo_ProcesoDeFabricacion objCostoProcesoDeFabricacionAActualizar)
        {
            using (var dc = new ModeloDataContext())
            {
                Costo_ProcesoDeFabricacion objCostoProcesoDeFabricacion = dc.Costo_ProcesoDeFabricacion.Single(p => p.Id == objCostoProcesoDeFabricacionAActualizar.Id);
                objCostoProcesoDeFabricacion.Id = objCostoProcesoDeFabricacionAActualizar.Id;
                objCostoProcesoDeFabricacion.Id_Costo = objCostoProcesoDeFabricacionAActualizar.Id_Costo;
                objCostoProcesoDeFabricacion.Id_Proceso = objCostoProcesoDeFabricacionAActualizar.Id_Proceso;
                objCostoProcesoDeFabricacion.Id_UnidadDeMedida = objCostoProcesoDeFabricacionAActualizar.Id_UnidadDeMedida;
                objCostoProcesoDeFabricacion.Cantidad = objCostoProcesoDeFabricacionAActualizar.Cantidad;
                objCostoProcesoDeFabricacion.Valor = objCostoProcesoDeFabricacionAActualizar.Valor;
                dc.SubmitChanges();
            }
        }
    }
}