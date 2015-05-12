using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class CiudadLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Ciudad> Seleccionar_All()
        {
            CiudadOAD objCiudad = new CiudadOAD();
            return objCiudad.Seleccionar_All();
        }
        /// <summary>
        /// Captura toda la lista de ciudades pertenecientesa a una provincia.
        /// </summary>
        /// <param name="Id_Provincia">Identificativo de la provincia</param>
        /// <returns>Lista de ciudades.</returns>
        public List<Ciudad> Seleccionar_PorProvincia(int Id_Provincia)
        {
            CiudadOAD objCiudad = new CiudadOAD();
            return objCiudad.Seleccionar_PorProvincia(Id_Provincia);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Ciudad Seleccionar_Id(long Id)
        {
            CiudadOAD objCiudad = new CiudadOAD();
            return objCiudad.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Ciudad objCiudad)
        {
            CiudadOAD _objCiudad = new CiudadOAD();
            _objCiudad.Guardar(objCiudad);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Ciudad objCiudad)
        {
            CiudadOAD _objCiudad = new CiudadOAD();
            _objCiudad.Eliminar(objCiudad);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Ciudad objCiudad)
        {
            CiudadOAD _objCiudad = new CiudadOAD();
            _objCiudad.Actualizar(objCiudad);
        }
    }
}