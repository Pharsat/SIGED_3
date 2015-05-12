using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class CiudadOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Ciudad> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Ciudad.ToList();
            }
        }
        /// <summary>
        /// Captura toda la lista de ciudades pertenecientesa a una provincia.
        /// </summary>
        /// <param name="Id_Provincia">Identificativo de la provincia</param>
        /// <returns>Lista de ciudades.</returns>
        public List<Ciudad> Seleccionar_PorProvincia(int Id_Provincia)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var query = from p in dc.Ciudad
                            where p.Id_Provincia == Id_Provincia
                            select p;
                return query.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Ciudad Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Ciudad.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Ciudad objCiudad)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Ciudad.InsertOnSubmit(objCiudad);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Ciudad objCiudad)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Ciudad _objCiudad = dc.Ciudad.Single(p => p.Id == objCiudad.Id);
                dc.Ciudad.DeleteOnSubmit(_objCiudad);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Ciudad objCiudad)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Ciudad _objCiudad = dc.Ciudad.Single(p => p.Id == objCiudad.Id);
                _objCiudad.Id = objCiudad.Id;
                _objCiudad.Id_Provincia = objCiudad.Id_Provincia;
                _objCiudad.Nombre = objCiudad.Nombre;
                _objCiudad.Estado = objCiudad.Estado;
                dc.SubmitChanges();
            }
        }
    }
}