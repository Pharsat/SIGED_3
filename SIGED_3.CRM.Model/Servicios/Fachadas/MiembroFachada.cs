using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class MiembroFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Miembro> Seleccionar_All()
        {
            MiembroLN objMiembro = new MiembroLN();
            return objMiembro.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Miembro Seleccionar_Id(long Id)
        {
            MiembroLN objMiembro = new MiembroLN();
            return objMiembro.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Miembro objMiembro)
        {
            MiembroLN _objMiembro = new MiembroLN();
            _objMiembro.Guardar(objMiembro);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Miembro objMiembro)
        {
            MiembroLN _objMiembro = new MiembroLN();
            _objMiembro.Eliminar(objMiembro);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Miembro objMiembro)
        {
            MiembroLN _objMiembro = new MiembroLN();
            _objMiembro.Actualizar(objMiembro);
        }
        /// <summary>
        /// Almacena la imagen de un usuario.
        /// </summary>
        /// <param name="Id_Miembro">Identificador del miembro</param>
        /// <param name="Imagen">Bites de la imagen</param>
        /// <param name="NombreImagen">nombre de la imafen</param>
        /// <param name="Extencion">Extencion de la imagen.</param>
        public void GuardarImagen_Miembro(long Id_Miembro_Salva, long Id_Grupo_Asignado, byte[] Imagen, string NombreImagen, string Extencion)
        {
            MiembroLN _objMiembro = new MiembroLN();
            _objMiembro.GuardarImagen_Miembro(Id_Miembro_Salva, Id_Grupo_Asignado, Imagen, NombreImagen, Extencion);
        }

        public List<LP_MiembrosResult> MiembrosDelGrupo()
        {
            MiembroLN _objMiembro = new MiembroLN();
            return _objMiembro.MiembrosDelGrupo();
        }

        public long Guardar_2(Miembro objMiembro)
        {
            MiembroLN _objMiembro = new MiembroLN();
            return _objMiembro.Guardar_2(objMiembro);
        }
    }
}