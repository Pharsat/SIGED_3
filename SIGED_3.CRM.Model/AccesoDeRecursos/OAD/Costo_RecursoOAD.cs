using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Costo_RecursoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_Recurso> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_Recurso.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_Recurso Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Costo_Recurso.Any(p => p.Id == Id))
                {
                    return dc.Costo_Recurso.Single(p => p.Id == Id);
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
        /// <param name="id_Costo">id del costo a traer</param>
        /// <returns>lista de costos</returns>
        public List<LS_Costo_RecursosResult> Seleccionar_By_Id(long? id_Costo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_Costo_Recursos(id_Costo).ToList();
            }
        }

        public List<Costo_Recurso> Seleccionar_By_Id_Complete(long? id_Costo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_Recurso.Where(p => p.Id_Costo == id_Costo).ToList();
            }
        }

        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_Recurso objCosto_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Costo_Recurso.InsertOnSubmit(objCosto_Recurso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo_Recurso objCosto_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_Recurso _objCosto_Recurso = dc.Costo_Recurso.Single(p => p.Id == objCosto_Recurso.Id);
                dc.Costo_Recurso.DeleteOnSubmit(_objCosto_Recurso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo_Recurso objCosto_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_Recurso _objCosto_Recurso = dc.Costo_Recurso.Single(p => p.Id == objCosto_Recurso.Id);
                _objCosto_Recurso.Id = objCosto_Recurso.Id;
                _objCosto_Recurso.Id_Costo = objCosto_Recurso.Id_Costo;
                _objCosto_Recurso.Id_Recurso = objCosto_Recurso.Id_Recurso;
                _objCosto_Recurso.Id_UnidadDeMedida = objCosto_Recurso.Id_UnidadDeMedida;
                _objCosto_Recurso.Consumo = objCosto_Recurso.Consumo;
                _objCosto_Recurso.ValoUnitario = objCosto_Recurso.ValoUnitario;
                dc.SubmitChanges();
            }
        }
    }
}