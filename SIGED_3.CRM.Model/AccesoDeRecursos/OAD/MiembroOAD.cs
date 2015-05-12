using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class MiembroOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Miembro> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Miembro.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Miembro Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Miembro.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Miembro objMiembro)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Miembro.InsertOnSubmit(objMiembro);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto Miembro y obtiene su Id
        /// </summary>
        /// <param name="objMiembro">Licnete a guardar</param>
        public long Guardar_2(Miembro objMiembro)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Miembro.InsertOnSubmit(objMiembro);
                dc.SubmitChanges();
                return dc.Miembro.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Miembro objMiembro)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Miembro _objMiembro = dc.Miembro.Single(p => p.Id == objMiembro.Id);
                dc.Miembro.DeleteOnSubmit(_objMiembro);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Miembro objMiembro)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Miembro _objMiembro = dc.Miembro.Single(p => p.Id == objMiembro.Id);
                _objMiembro.Id = objMiembro.Id;
                _objMiembro.Id_TipoDeDocumento = objMiembro.Id_TipoDeDocumento;
                _objMiembro.Id_GrupoDeMiembros = objMiembro.Id_GrupoDeMiembros;
                _objMiembro.Id_Pais = objMiembro.Id_Pais;
                _objMiembro.Id_Imagen = objMiembro.Id_Imagen;
                _objMiembro.Id_Provincia = objMiembro.Id_Provincia;
                _objMiembro.Id_Ciudad = objMiembro.Id_Ciudad;
                _objMiembro.Nombres = objMiembro.Nombres;
                _objMiembro.Apellidos = objMiembro.Apellidos;
                _objMiembro.Identificacion = objMiembro.Identificacion;
                _objMiembro.FechaDeNacimiento = objMiembro.FechaDeNacimiento;
                _objMiembro.Email = objMiembro.Email;
                dc.SubmitChanges();
            }
        }

        public List<LP_MiembrosResult> MiembrosDelGrupo(long? id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Miembros(id_GrupoDeMiembros).ToList();
            }
        }
    }
}