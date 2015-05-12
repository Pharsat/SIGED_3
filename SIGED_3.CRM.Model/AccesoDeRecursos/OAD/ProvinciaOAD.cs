using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ProvinciaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Provincia> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Provincia.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Provincia por pais seleccionado
        /// </summary>
        /// <returns>Lista de registros tipo Provincia</returns>
        public List<Provincia> Seleccionar_PorPais(int Id_Pais)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var query = from p in dc.Provincia
                            where p.Id_Pais == Id_Pais
                            select p;
                return query.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Provincia Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Provincia.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Provincia objProvincia)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Provincia.InsertOnSubmit(objProvincia);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Provincia objProvincia)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Provincia _objProvincia = dc.Provincia.Single(p => p.Id == objProvincia.Id);
                dc.Provincia.DeleteOnSubmit(_objProvincia);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Provincia objProvincia)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Provincia _objProvincia = dc.Provincia.Single(p => p.Id == objProvincia.Id);
                _objProvincia.Id = objProvincia.Id;
                _objProvincia.Id_Pais = objProvincia.Id_Pais;
                _objProvincia.Nombre = objProvincia.Nombre;
                _objProvincia.Estado = objProvincia.Estado;
                dc.SubmitChanges();
            }
        }
    }
}