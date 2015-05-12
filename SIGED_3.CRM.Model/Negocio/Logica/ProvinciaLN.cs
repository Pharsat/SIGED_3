using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class ProvinciaLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Provincia> Seleccionar_All()
        {
            ProvinciaOAD objProvincia = new ProvinciaOAD();
            return objProvincia.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Provincia por pais seleccionado
        /// </summary>
        /// <returns>Lista de registros tipo Provincia</returns>
        public List<Provincia> Seleccionar_PorPais(int Id_Pais)
        {
            ProvinciaOAD objProvincia = new ProvinciaOAD();
            return objProvincia.Seleccionar_PorPais(Id_Pais);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Provincia Seleccionar_Id(long Id)
        {
            ProvinciaOAD objProvincia = new ProvinciaOAD();
            return objProvincia.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Provincia objProvincia)
        {
            ProvinciaOAD _objProvincia = new ProvinciaOAD();
            _objProvincia.Guardar(objProvincia);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Provincia objProvincia)
        {
            ProvinciaOAD _objProvincia = new ProvinciaOAD();
            _objProvincia.Eliminar(objProvincia);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Provincia objProvincia)
        {
            ProvinciaOAD _objProvincia = new ProvinciaOAD();
            _objProvincia.Actualizar(objProvincia);
        }
    }
}