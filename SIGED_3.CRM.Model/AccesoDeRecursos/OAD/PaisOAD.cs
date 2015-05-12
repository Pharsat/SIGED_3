using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class PaisOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Pais> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Pais.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Pais Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Pais.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Pais objPais)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Pais.InsertOnSubmit(objPais);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Pais objPais)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Pais _objPais = dc.Pais.Single(p => p.Id == objPais.Id);
                dc.Pais.DeleteOnSubmit(_objPais);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Pais objPais)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Pais _objPais = dc.Pais.Single(p => p.Id == objPais.Id);
                _objPais.Id = objPais.Id;
                _objPais.Nombre = objPais.Nombre;
                _objPais.Estado = objPais.Estado;
                dc.SubmitChanges();
            }
        }
    }
}