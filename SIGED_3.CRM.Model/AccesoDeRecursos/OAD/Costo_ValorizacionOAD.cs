namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    using System.Collections.Generic;
    using System.Linq;
    using Negocio.Entidades;

    internal class CostoValorizacionOad
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_Valorizacion> Seleccionar_All()
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo_Valorizacion.ToList();
            }
        }

        public Costo_Valorizacion Seleccionar_Id(long id)
        {
            using (var dc = new ModeloDataContext())
            {
                if (dc.Costo_Valorizacion.Any(p => p.Id == id))
                {
                    return dc.Costo_Valorizacion.Single(p => p.Id == id);
                }
                else
                {
                    return new Costo_Valorizacion();
                }
            }
        }

        public List<Costo_Valorizacion> Seleccionar_By_Id(long? idCosto)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo_Valorizacion.Where(p => p.Id_Costo == idCosto).OrderBy(p => p.Posicion).ToList();
            }
        }

        public List<Costo_Valorizacion> Seleccionar_By_Id_Complete(long? idCosto)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo_Valorizacion.Where(p => p.Id_Costo == idCosto).ToList();
            }
        }

        public void Guardar(Costo_Valorizacion objCostoValorizacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Costo_Valorizacion.InsertOnSubmit(objCostoValorizacion);
                dc.SubmitChanges();
            }
        }

        public void Eliminar(Costo_Valorizacion costoValorizacion)
        {
            using (var dc = new ModeloDataContext())
            {
                var objCostoValorizacion = dc.Costo_Valorizacion.Single(p => p.Id == costoValorizacion.Id);
                dc.Costo_Valorizacion.DeleteOnSubmit(objCostoValorizacion);
                dc.SubmitChanges();
            }
        }

        public void Actualizar(Costo_Valorizacion objCostoValorizacionAActualizar)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_Valorizacion objCostoValorizacion = dc.Costo_Valorizacion.Single(p => p.Id == objCostoValorizacionAActualizar.Id);
                objCostoValorizacion.Id = objCostoValorizacionAActualizar.Id;
                objCostoValorizacion.Id_Costo = objCostoValorizacionAActualizar.Id_Costo;
                objCostoValorizacion.Descripcion = objCostoValorizacionAActualizar.Descripcion;
                objCostoValorizacion.Porcentaje = objCostoValorizacionAActualizar.Porcentaje;
                objCostoValorizacion.Posicion = objCostoValorizacionAActualizar.Posicion;
                objCostoValorizacion.ValorHastaElMomento = objCostoValorizacionAActualizar.ValorHastaElMomento;
                dc.SubmitChanges();
            }
        }
    }
}