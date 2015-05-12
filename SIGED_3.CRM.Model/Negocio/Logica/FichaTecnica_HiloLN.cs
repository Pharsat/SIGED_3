using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class FichaTecnica_HiloLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Hilo> Seleccionar_All()
        {
            FichaTecnica_HiloOAD objFichaTecnica_Hilo = new FichaTecnica_HiloOAD();
            return objFichaTecnica_Hilo.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Hilo Seleccionar_Id(long Id)
        {
            FichaTecnica_HiloOAD objFichaTecnica_Hilo = new FichaTecnica_HiloOAD();
            return objFichaTecnica_Hilo.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae una lista de fichatecnica color por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de colores</returns>
        public List<FichaTecnica_Hilo> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            FichaTecnica_HiloOAD objFichaTecnica_Hilo = new FichaTecnica_HiloOAD();
            return objFichaTecnica_Hilo.Seleccionar_By_FichaTecnica(Id_FichaTecnica);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Hilo objFichaTecnica_Hilo)
        {
            FichaTecnica_HiloOAD _objFichaTecnica_Hilo = new FichaTecnica_HiloOAD();
            _objFichaTecnica_Hilo.Guardar(objFichaTecnica_Hilo);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_Hilo objFichaTecnica_Hilo)
        {
            FichaTecnica_HiloOAD _objFichaTecnica_Hilo = new FichaTecnica_HiloOAD();
            _objFichaTecnica_Hilo.Eliminar(objFichaTecnica_Hilo);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Hilo objFichaTecnica_Hilo)
        {
            FichaTecnica_HiloOAD _objFichaTecnica_Hilo = new FichaTecnica_HiloOAD();
            _objFichaTecnica_Hilo.Actualizar(objFichaTecnica_Hilo);
        }
    }
}