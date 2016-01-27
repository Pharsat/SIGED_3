namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Negocio.Entidades;

    internal class CiudadOad
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Ciudad> Seleccionar_All()
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Ciudad.ToList();
            }
        }
        /// <summary>
        /// Captura toda la lista de ciudades pertenecientesa a una provincia.
        /// </summary>
        /// <param name="idProvincia">Identificativo de la provincia</param>
        /// <returns>Lista de ciudades.</returns>
        public List<Ciudad> Seleccionar_PorProvincia(int idProvincia)
        {
            using (var dc = new ModeloDataContext())
            {
                var query = from p in dc.Ciudad
                            where p.Id_Provincia == idProvincia
                            select p;
                return query.ToList();
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name="id">Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Ciudad Seleccionar_Id(long id)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Ciudad.Single(p => p.Id == id);
            }
        }

        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name="objCiudad"></param>
        public void Guardar(Ciudad objCiudad)
        {
            using (var dc = new ModeloDataContext())
            {
                dc.Ciudad.InsertOnSubmit(objCiudad);
                dc.SubmitChanges();
            }
        }

        public void Eliminar(Ciudad ciudad)
        {
            using (var dc = new ModeloDataContext())
            {
                var objCiudad = dc.Ciudad.Single(p => p.Id == ciudad.Id);
                if (objCiudad == null) throw new ArgumentNullException("ciudad");
                dc.Ciudad.DeleteOnSubmit(objCiudad);
                dc.SubmitChanges();
            }
        }

        public void Actualizar(Ciudad ciudad)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var objCiudad = dc.Ciudad.Single(p => p.Id == ciudad.Id);
                objCiudad.Id = ciudad.Id;
                objCiudad.Id_Provincia = ciudad.Id_Provincia;
                objCiudad.Nombre = ciudad.Nombre;
                objCiudad.Estado = ciudad.Estado;
                dc.SubmitChanges();
            }
        }
    }
}