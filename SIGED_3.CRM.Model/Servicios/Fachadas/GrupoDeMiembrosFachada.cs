using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
using System.Data;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class GrupoDeMiembrosFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<GrupoDeMiembros> Seleccionar_All()
        {
            GrupoDeMiembrosLN objGrupoDeMiembros = new GrupoDeMiembrosLN();
            return objGrupoDeMiembros.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public GrupoDeMiembros Seleccionar_Id(long Id)
        {
            GrupoDeMiembrosLN objGrupoDeMiembros = new GrupoDeMiembrosLN();
            return objGrupoDeMiembros.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(GrupoDeMiembros objGrupoDeMiembros)
        {
            GrupoDeMiembrosLN _objGrupoDeMiembros = new GrupoDeMiembrosLN();
            _objGrupoDeMiembros.Guardar(objGrupoDeMiembros);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(GrupoDeMiembros objGrupoDeMiembros)
        {
            GrupoDeMiembrosLN _objGrupoDeMiembros = new GrupoDeMiembrosLN();
            _objGrupoDeMiembros.Eliminar(objGrupoDeMiembros);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(GrupoDeMiembros objGrupoDeMiembros)
        {
            GrupoDeMiembrosLN _objGrupoDeMiembros = new GrupoDeMiembrosLN();
            _objGrupoDeMiembros.Actualizar(objGrupoDeMiembros);
        }
        public List<R_ImagenDelGrupoResult> RelatorioGrupo(long? Id_Grupo)
        {
            GrupoDeMiembrosLN _objGrupoDeMiembros = new GrupoDeMiembrosLN();
            return _objGrupoDeMiembros.RelatorioGrupo(Id_Grupo);
        }
        public DataTable RelatorioGrupo_Tabla(long? Id_Grupo)
        {
            GrupoDeMiembrosLN _objGrupoDeMiembros = new GrupoDeMiembrosLN();
            return _objGrupoDeMiembros.RelatorioGrupo_Tabla(Id_Grupo);
        }
    }
}