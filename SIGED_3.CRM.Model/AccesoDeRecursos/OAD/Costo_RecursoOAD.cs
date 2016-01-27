namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    using System.Collections.Generic;
    using System.Linq;
    using Negocio.Entidades;

    internal class CostoRecursoOad
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_Recurso> Seleccionar_All()
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo_Recurso.ToList();
            }
        }

        public Costo_Recurso Seleccionar_Id(long id)
        {
            using (var dc = new ModeloDataContext())
            {
                if (dc.Costo_Recurso.Any(p => p.Id == id))
                {
                    return dc.Costo_Recurso.Single(p => p.Id == id);
                }
                else
                {
                    return new Costo_Recurso();
                }
            }
        }
        /// <summary>
        /// Trae la lista de recursos en la lista de costos
        /// </summary>
        /// <param name="idCosto">id del costo a traer</param>
        /// <returns>lista de costos</returns>
        public List<LS_Costo_RecursosResult> Seleccionar_By_Id(long? idCosto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_Costo_Recursos(idCosto).ToList();
            }
        }

        public List<Costo_Recurso> Seleccionar_By_Id_Complete(long? idCosto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_Recurso.Where(p => p.Id_Costo == idCosto).ToList();
            }
        }


        public void Guardar(Costo_Recurso objCostoRecursoAaGuardar)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Costo_Recurso.InsertOnSubmit(objCostoRecursoAaGuardar);
                dc.SubmitChanges();
            }
        }


        public void Eliminar(Costo_Recurso objCostoRecursoAEliminar)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_Recurso objCostoRecurso = dc.Costo_Recurso.Single(p => p.Id == objCostoRecursoAEliminar.Id);
                dc.Costo_Recurso.DeleteOnSubmit(objCostoRecurso);
                dc.SubmitChanges();
            }
        }

        public void Actualizar(Costo_Recurso objCostoRecursoAActualizar)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_Recurso objCostoRecurso = dc.Costo_Recurso.Single(p => p.Id == objCostoRecursoAActualizar.Id);
                objCostoRecurso.Id = objCostoRecursoAActualizar.Id;
                objCostoRecurso.Id_Costo = objCostoRecursoAActualizar.Id_Costo;
                objCostoRecurso.Id_Recurso = objCostoRecursoAActualizar.Id_Recurso;
                objCostoRecurso.Id_UnidadDeMedida = objCostoRecursoAActualizar.Id_UnidadDeMedida;
                objCostoRecurso.Consumo = objCostoRecursoAActualizar.Consumo;
                objCostoRecurso.ValoUnitario = objCostoRecursoAActualizar.ValoUnitario;
                dc.SubmitChanges();
            }
        }
    }
}