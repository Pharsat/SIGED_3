using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class FichaTecnica_MarquillaLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Marquilla> Seleccionar_All()
        {
            FichaTecnica_MarquillaOAD objFichaTecnica_Marquilla = new FichaTecnica_MarquillaOAD();
            return objFichaTecnica_Marquilla.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Marquilla Seleccionar_Id(long Id)
        {
            FichaTecnica_MarquillaOAD objFichaTecnica_Marquilla = new FichaTecnica_MarquillaOAD();
            return objFichaTecnica_Marquilla.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae una lista de fichatecnica Marquilla por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de Marquillaes</returns>
        public List<FichaTecnica_Marquilla> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            FichaTecnica_MarquillaOAD objFichaTecnica_Marquilla = new FichaTecnica_MarquillaOAD();
            return objFichaTecnica_Marquilla.Seleccionar_By_FichaTecnica(Id_FichaTecnica);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Marquilla objFichaTecnica_Marquilla)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Imagenes objImagen;
                    if (objFichaTecnica_Marquilla.ImagenMarquilla != null && objFichaTecnica_Marquilla.Id_Miembro_Salva.HasValue)
                    {
                        if (!objFichaTecnica_Marquilla.Id_Imagen.HasValue)
                        {
                            objImagen = new Imagenes();
                        }
                        else
                        {
                            objImagen = new ImagenesOAD().Seleccionar_Id(objFichaTecnica_Marquilla.Id_Imagen.Value)[0];
                        }
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();
                        objImagen.Id_Miembro_Salvado = objFichaTecnica_Marquilla.Id_Miembro_Salva.Value;
                        objImagen.Image = objFichaTecnica_Marquilla.ImagenMarquilla;
                        objImagen.NombreOriginal = objFichaTecnica_Marquilla.NombreImagen;
                        objImagen.Tipo = objFichaTecnica_Marquilla.Extencion;
                        if (!objFichaTecnica_Marquilla.Id_Imagen.HasValue)
                        {
                            objFichaTecnica_Marquilla.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                        }
                        else
                        {
                            new ImagenesOAD().Actualizar(objImagen);
                        }
                    }
                    FichaTecnica_MarquillaOAD _objFichaTecnica_Marquilla = new FichaTecnica_MarquillaOAD();
                    _objFichaTecnica_Marquilla.Guardar(objFichaTecnica_Marquilla);
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
        public void Eliminar(FichaTecnica_Marquilla objFichaTecnica_Marquilla)
        {
            FichaTecnica_MarquillaOAD _objFichaTecnica_Marquilla = new FichaTecnica_MarquillaOAD();
            _objFichaTecnica_Marquilla.Eliminar(objFichaTecnica_Marquilla);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Marquilla objFichaTecnica_Marquilla)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Imagenes objImagen;
                    if (objFichaTecnica_Marquilla.ImagenMarquilla != null && objFichaTecnica_Marquilla.Id_Miembro_Salva.HasValue)
                    {
                        if (objFichaTecnica_Marquilla.Id_Imagen.HasValue)
                        {
                            objImagen = new ImagenesOAD().Seleccionar_Id(objFichaTecnica_Marquilla.Id_Imagen.Value)[0];
                        }
                        else
                        {
                            objImagen = new Imagenes();
                        }
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();
                        objImagen.Id_Miembro_Salvado = objFichaTecnica_Marquilla.Id_Miembro_Salva.Value;
                        objImagen.Image = objFichaTecnica_Marquilla.ImagenMarquilla;
                        objImagen.NombreOriginal = objFichaTecnica_Marquilla.NombreImagen;
                        objImagen.Tipo = objFichaTecnica_Marquilla.Extencion;
                        if (!objFichaTecnica_Marquilla.Id_Imagen.HasValue)
                        {
                            objFichaTecnica_Marquilla.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                        }
                        else
                        {
                            new ImagenesOAD().Actualizar(objImagen);
                        }
                    }
                    FichaTecnica_MarquillaOAD _objFichaTecnica_Marquilla = new FichaTecnica_MarquillaOAD();
                    _objFichaTecnica_Marquilla.Actualizar(objFichaTecnica_Marquilla);
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