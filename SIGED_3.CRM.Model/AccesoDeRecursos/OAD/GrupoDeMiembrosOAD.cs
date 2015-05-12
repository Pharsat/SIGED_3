using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.SQL;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Struct;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class GrupoDeMiembrosOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<GrupoDeMiembros> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.GrupoDeMiembros.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public GrupoDeMiembros Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.GrupoDeMiembros.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(GrupoDeMiembros objGrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.GrupoDeMiembros.InsertOnSubmit(objGrupoDeMiembros);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto GrupoDeMiembros y obtiene su Id
        /// </summary>
        /// <param name="objGrupoDeMiembros">Licnete a guardar</param>
        public long Guardar_2(GrupoDeMiembros objGrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.GrupoDeMiembros.InsertOnSubmit(objGrupoDeMiembros);
                dc.SubmitChanges();
                return dc.GrupoDeMiembros.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(GrupoDeMiembros objGrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                GrupoDeMiembros _objGrupoDeMiembros = dc.GrupoDeMiembros.Single(p => p.Id == objGrupoDeMiembros.Id);
                dc.GrupoDeMiembros.DeleteOnSubmit(_objGrupoDeMiembros);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(GrupoDeMiembros objGrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                GrupoDeMiembros _objGrupoDeMiembros = dc.GrupoDeMiembros.Single(p => p.Id == objGrupoDeMiembros.Id);
                _objGrupoDeMiembros.Id = objGrupoDeMiembros.Id;
                _objGrupoDeMiembros.Id_Pais = objGrupoDeMiembros.Id_Pais;
                _objGrupoDeMiembros.Id_Imagen = objGrupoDeMiembros.Id_Imagen;
                _objGrupoDeMiembros.Id_Provincia = objGrupoDeMiembros.Id_Provincia;
                _objGrupoDeMiembros.Id_Ciudad = objGrupoDeMiembros.Id_Ciudad;
                _objGrupoDeMiembros.Nombre = objGrupoDeMiembros.Nombre;
                _objGrupoDeMiembros.Descripcion = objGrupoDeMiembros.Descripcion;
                dc.SubmitChanges();
            }
        }
        public List<R_ImagenDelGrupoResult> RelatorioGrupo(long? Id_Grupo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_ImagenDelGrupo(Id_Grupo).ToList();
            }
        }
        public DataTable RelatorioGrupo_Tabla(long? Id_Grupo)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Grupo) }, ProcedimientosAlmacenados.R_ImagenDelGrupo);
        }
    }
}