using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class ImagenesFachadas
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Imagenes
        /// </summary>
        /// <returns>Lista de registros tipo Imagenes</returns>
        public List<Imagenes> Seleccionar_All()
        {
            ImagenesLN objImagenes = new ImagenesLN();
            return objImagenes.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Imagenes
        /// </summary>
        /// <param name=Id>Identificador de la Imagenes</param>
        /// <returns>Objeto singular del tipo Imagenes</returns>
        public List<Imagenes> Seleccionar_Id(long Id)
        {
            ImagenesLN objImagenes = new ImagenesLN();
            return objImagenes.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Imagenes en la base de datos.
        /// </summary>
        /// <param name=objImagenes>Objeto Imagenes a guardar</param>
        public void Guardar(Imagenes objImagenes)
        {
            ImagenesLN _objImagenes = new ImagenesLN();
            _objImagenes.Guardar(objImagenes);
        }
        /// <summary>
        /// Elimina un objeto del tipo Imagenes, se recibe su Id unicamente
        /// </summary>
        /// <param name=objImagenes>Identificativo del(a) Imagenes</param>
        public void Eliminar(Imagenes objImagenes)
        {
            ImagenesLN _objImagenes = new ImagenesLN();
            _objImagenes.Eliminar(objImagenes);
        }
        /// <summary>
        /// Actualiza una Imagenes, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objImagenes>Objeto del tipo Imagenes</param>
        public void Actualizar(Imagenes objImagenes)
        {
            ImagenesLN _objImagenes = new ImagenesLN();
            _objImagenes.Actualizar(objImagenes);
        }
    }
}
