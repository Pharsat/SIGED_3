using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class FichaTecnica_PasosDeConfeccionLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_PasosDeConfeccion> Seleccionar_All()
        {
            FichaTecnica_PasosDeConfeccionOAD objFichaTecnica_PasosDeConfeccion = new FichaTecnica_PasosDeConfeccionOAD();
            return objFichaTecnica_PasosDeConfeccion.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_PasosDeConfeccion Seleccionar_Id(long Id)
        {
            FichaTecnica_PasosDeConfeccionOAD objFichaTecnica_PasosDeConfeccion = new FichaTecnica_PasosDeConfeccionOAD();
            return objFichaTecnica_PasosDeConfeccion.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae una lista de fichatecnica PasosDeConfeccion por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de PasosDeConfecciones</returns>
        public List<FichaTecnica_PasosDeConfeccion> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            FichaTecnica_PasosDeConfeccionOAD objFichaTecnica_PasosDeConfeccion = new FichaTecnica_PasosDeConfeccionOAD();
            return objFichaTecnica_PasosDeConfeccion.Seleccionar_By_FichaTecnica(Id_FichaTecnica);
        }
        /// <summary>
        /// Returna la cantidad de fichas tecnicas actualess en el sistema y 
        /// </summary>
        /// <param name="Id_FichaTecnica">ficha tecnica a la cual le pertenecen los procesos</param>
        /// <returns>la numeracion sigueinte para los pasos</returns>
        public int Seleccionar_ProximoNumeracion(long Id_FichaTecnica)
        {
            FichaTecnica_PasosDeConfeccionOAD objFichaTecnica_PasosDeConfeccion = new FichaTecnica_PasosDeConfeccionOAD();
            return objFichaTecnica_PasosDeConfeccion.Seleccionar_ProximoNumeracion(Id_FichaTecnica);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_PasosDeConfeccion objFichaTecnica_PasosDeConfeccion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    FichaTecnica_PasosDeConfeccionOAD _objFichaTecnica_PasosDeConfeccion = new FichaTecnica_PasosDeConfeccionOAD();
                    if (_objFichaTecnica_PasosDeConfeccion.VerificarNumeracion(objFichaTecnica_PasosDeConfeccion.Id_FichaTecnica, objFichaTecnica_PasosDeConfeccion.Numeracion.Value))
                    {
                        _objFichaTecnica_PasosDeConfeccion.ActualizarValoresMayoresANumero(objFichaTecnica_PasosDeConfeccion.Id_FichaTecnica, objFichaTecnica_PasosDeConfeccion.Numeracion.Value);
                    }
                    _objFichaTecnica_PasosDeConfeccion.Guardar(objFichaTecnica_PasosDeConfeccion);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_PasosDeConfeccion objFichaTecnica_PasosDeConfeccion)
        {
            FichaTecnica_PasosDeConfeccionOAD _objFichaTecnica_PasosDeConfeccion = new FichaTecnica_PasosDeConfeccionOAD();
            _objFichaTecnica_PasosDeConfeccion.Eliminar(objFichaTecnica_PasosDeConfeccion);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_PasosDeConfeccion objFichaTecnica_PasosDeConfeccion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    FichaTecnica_PasosDeConfeccionOAD _objFichaTecnica_PasosDeConfeccion = new FichaTecnica_PasosDeConfeccionOAD();
                    if (_objFichaTecnica_PasosDeConfeccion.VerificarNumeracion(objFichaTecnica_PasosDeConfeccion.Id_FichaTecnica, objFichaTecnica_PasosDeConfeccion.Numeracion.Value))
                    {
                        _objFichaTecnica_PasosDeConfeccion.ActualizarValoresMayoresANumero(objFichaTecnica_PasosDeConfeccion.Id_FichaTecnica, objFichaTecnica_PasosDeConfeccion.Numeracion.Value);
                    }
                    _objFichaTecnica_PasosDeConfeccion.Actualizar(objFichaTecnica_PasosDeConfeccion);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}