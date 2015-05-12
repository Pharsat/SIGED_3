using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class MiembroLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Miembro> Seleccionar_All()
        {
            MiembroOAD objMiembro = new MiembroOAD();
            return objMiembro.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Miembro Seleccionar_Id(long Id)
        {
            MiembroOAD objMiembro = new MiembroOAD();
            return objMiembro.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Miembro objMiembro)
        {
            MiembroOAD _objMiembro = new MiembroOAD();
            _objMiembro.Guardar(objMiembro);
        }
        /// <summary>
        /// Guarda el objeto Miembro y obtiene su Id
        /// </summary>
        /// <param name="objMiembro">Licnete a guardar</param>
        public long Guardar_2(Miembro objMiembro)
        {
            MiembroOAD _objMiembro = new MiembroOAD();
            return _objMiembro.Guardar_2(objMiembro);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Miembro objMiembro)
        {
            MiembroOAD _objMiembro = new MiembroOAD();
            _objMiembro.Eliminar(objMiembro);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Miembro objMiembro)
        {
            MiembroOAD _objMiembro = new MiembroOAD();
            _objMiembro.Actualizar(objMiembro);
        }
        /// <summary>
        /// Almacena la imagen de un usuario.
        /// </summary>
        /// <param name="Id_Miembro">Identificador del miembro</param>
        /// <param name="Imagen">Bites de la imagen</param>
        /// <param name="NombreImagen">nombre de la imafen</param>
        /// <param name="Extencion">Extencion de la imagen.</param>
        public void GuardarImagen_Miembro(long Id_Miembro_Salva, long Id_Miembro_Asignado, byte[] Imagen, string NombreImagen, string Extencion)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Miembro objMiembro = new MiembroOAD().Seleccionar_Id(Id_Miembro_Asignado);
                    Imagenes objImagen;
                    if (!objMiembro.Id_Imagen.HasValue)
                    {
                        objImagen = new Imagenes();
                    }
                    else
                    {
                        objImagen = new ImagenesOAD().Seleccionar_Id(objMiembro.Id_Imagen.Value)[0];
                    }
                    objImagen.Fecha_Salvado = DateTime.Now;
                    objImagen.Id_Miembro_Salvado = Id_Miembro_Salva;
                    objImagen.Image = Imagen;
                    objImagen.NombreOriginal = NombreImagen;
                    objImagen.Tipo = Extencion;
                    if (!objMiembro.Id_Imagen.HasValue)
                    {
                        objMiembro.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                    }
                    else
                    {
                        new ImagenesOAD().Actualizar(objImagen);
                    }
                    new MiembroOAD().Actualizar(objMiembro);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LP_MiembrosResult> MiembrosDelGrupo()
        {
            MiembroOAD _objMiembro = new MiembroOAD();
           return  _objMiembro.MiembrosDelGrupo(SessionManager.Id_GrupoDeMiembros);
        }
    }
}