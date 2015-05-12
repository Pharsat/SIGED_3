using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class FichaTecnica_ProcesosDetalladosLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_ProcesosDetallados> Seleccionar_All()
        {
            FichaTecnica_ProcesosDetalladosOAD objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosOAD();
            return objFichaTecnica_ProcesosDetallados.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_ProcesosDetallados Seleccionar_Id(long Id)
        {
            FichaTecnica_ProcesosDetalladosOAD objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosOAD();
            return objFichaTecnica_ProcesosDetallados.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae una lista de fichatecnica ProcesosDetallados por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de ProcesosDetalladoses</returns>
        public List<FichaTecnica_ProcesosDetallados> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            FichaTecnica_ProcesosDetalladosOAD objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosOAD();
            return objFichaTecnica_ProcesosDetallados.Seleccionar_By_FichaTecnica(Id_FichaTecnica);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Imagenes objImagen;
                    if (objFichaTecnica_ProcesosDetallados.ImagenProceso != null && objFichaTecnica_ProcesosDetallados.Id_Miembro_Salva.HasValue)
                    {
                        if (!objFichaTecnica_ProcesosDetallados.Id_Imagen.HasValue)
                        {
                            objImagen = new Imagenes();
                        }
                        else
                        {
                            objImagen = new ImagenesOAD().Seleccionar_Id(objFichaTecnica_ProcesosDetallados.Id_Imagen.Value)[0];
                        }
                        objImagen.Fecha_Salvado = DateTime.Now;
                        objImagen.Id_Miembro_Salvado = objFichaTecnica_ProcesosDetallados.Id_Miembro_Salva.Value;
                        objImagen.Image = objFichaTecnica_ProcesosDetallados.ImagenProceso;
                        objImagen.NombreOriginal = objFichaTecnica_ProcesosDetallados.NombreImagen;
                        objImagen.Tipo = objFichaTecnica_ProcesosDetallados.Extencion;
                        if (!objFichaTecnica_ProcesosDetallados.Id_Imagen.HasValue)
                        {
                            objFichaTecnica_ProcesosDetallados.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                        }
                        else
                        {
                            new ImagenesOAD().Actualizar(objImagen);
                        }
                    }
                    FichaTecnica_ProcesosDetalladosOAD _objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosOAD();
                    _objFichaTecnica_ProcesosDetallados.Guardar(objFichaTecnica_ProcesosDetallados);
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
        public void Eliminar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            FichaTecnica_ProcesosDetalladosOAD _objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosOAD();
            _objFichaTecnica_ProcesosDetallados.Eliminar(objFichaTecnica_ProcesosDetallados);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Imagenes objImagen;
                    if (objFichaTecnica_ProcesosDetallados.ImagenProceso != null && objFichaTecnica_ProcesosDetallados.Id_Miembro_Salva.HasValue)
                    {
                        if (objFichaTecnica_ProcesosDetallados.Id_Imagen.HasValue)
                        {
                            objImagen = new ImagenesOAD().Seleccionar_Id(objFichaTecnica_ProcesosDetallados.Id_Imagen.Value)[0];
                        }
                        else
                        {
                            objImagen = new Imagenes();
                        }
                        objImagen.Fecha_Salvado = DateTime.Now;
                        objImagen.Id_Miembro_Salvado = objFichaTecnica_ProcesosDetallados.Id_Miembro_Salva.Value;
                        objImagen.Image = objFichaTecnica_ProcesosDetallados.ImagenProceso;
                        objImagen.NombreOriginal = objFichaTecnica_ProcesosDetallados.NombreImagen;
                        objImagen.Tipo = objFichaTecnica_ProcesosDetallados.Extencion;
                        if (!objFichaTecnica_ProcesosDetallados.Id_Imagen.HasValue)
                        {
                            objFichaTecnica_ProcesosDetallados.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                        }
                        else
                        {
                            new ImagenesOAD().Actualizar(objImagen);
                        }
                    }
                    FichaTecnica_ProcesosDetalladosOAD _objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosOAD();
                    _objFichaTecnica_ProcesosDetallados.Actualizar(objFichaTecnica_ProcesosDetallados);
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