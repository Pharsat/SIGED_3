using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class RecursoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Recurso> Seleccionar_All()
        {
            RecursoOAD objRecurso = new RecursoOAD();
            return objRecurso.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Recurso Seleccionar_Id(long Id)
        {
            RecursoOAD objRecurso = new RecursoOAD();
            return objRecurso.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Consulta los recursos del sistema
        /// </summary>
        /// <param name="id_GrupoDeMiembros">grupo de miembros del recurso</param>
        /// <param name="estado">estado del recurso a buscar</param>
        /// <param name="nombre">nombre del recurso a buscar</param>
        /// <param name="id_TipoDeRecurso">tipo de recurso a buscar</param>
        /// <returns>lista para obtener los recursos</returns>
        public List<LP_RecursosResult> Seleccionar_LP(long? id_GrupoDeMiembros, bool? estado, string nombre, long? id_TipoDeRecurso)
        {
            RecursoOAD objRecurso = new RecursoOAD();
            return objRecurso.Seleccionar_LP(id_GrupoDeMiembros, estado, nombre, id_TipoDeRecurso);
        }
        /// <summary>
        /// retorna todos los recursos que no son productos terminados
        /// </summary>
        /// <param name="id_GrupoDeMiembros">grupo de miembros del recurso</param>
        /// <param name="id_ProductoNoTerminado">identificador de los recursos tipo producto terminado.</param>
        /// <returns></returns>
        public List<LC_Recursos_NoProductoTerminadoResult> Seleccionar_LC_1(long? id_GrupoDeMiembros)
        {
            RecursoOAD objRecurso = new RecursoOAD();
            return objRecurso.Seleccionar_LC_1(id_GrupoDeMiembros, (long)TipoDeRecurso_Enum.ProductoTerminado);
        }
        /// <summary>
        /// metdo para obtener toda la lista de recursos mexclada.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">grupo de miembros de los recursos</param>
        /// <param name="id_ProductoNoTerminado">identificador de producto terminado</param>
        /// <returns>lista de recursos</returns>
        public List<LC_Recursos_MezcladosResult> Seleccionar_LC_2(long? id_GrupoDeMiembros)
        {
            RecursoOAD objRecurso = new RecursoOAD();
            return objRecurso.Seleccionar_LC_2(id_GrupoDeMiembros, (long)TipoDeRecurso_Enum.ProductoTerminado);
        }
        /// <summary>
        /// Verifica si existe un recurso ya configurado para una de las combinaciones de la ficha tecnica.
        /// </summary>
        /// <param name="id_Color">color a verificar</param>
        /// <param name="Talla">talla a verificar</param>
        /// <param name="Id_FichaTecnica">ficha tecnica a verificar</param>
        /// <returns>si existe o no existe</returns>
        public bool Verificar_Existencia_Recurso(long? id_Color, string Talla, long? Id_FichaTecnica)
        {
            RecursoOAD objRecurso = new RecursoOAD();
            return objRecurso.Verificar_Existencia_Recurso(id_Color, Talla, Id_FichaTecnica);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Recurso objRecurso)
        {
            RecursoOAD _objRecurso = new RecursoOAD();
            _objRecurso.Guardar(objRecurso);
        }
        /// <summary>
        /// Guarda un recurso y devuelve el identificador con el que ha quedado.
        /// </summary>
        /// <param name="objRecurso">recurso a guardar</param>
        /// <returns>identificaor del recurso guardado</returns>
        public long Guardar_2(Recurso objRecurso)
        {
            RecursoOAD _objRecurso = new RecursoOAD();
            return _objRecurso.Guardar_2(objRecurso);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Recurso objRecurso)
        {
            RecursoOAD _objRecurso = new RecursoOAD();
            _objRecurso.Eliminar(objRecurso);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Recurso objRecurso)
        {
            RecursoOAD _objRecurso = new RecursoOAD();
            _objRecurso.Actualizar(objRecurso);
        }
        /// <summary>
        /// Lista los recursos del tipo que aplican para pasos de coneccion en la ficha tecnica
        /// </summary>
        /// <returns>Lista de recursos</returns>
        public List<Recurso> Seleccionar_RecursosParaPasosDeConfeccion(long? Id_GrupoDeMiembros)
        {
            RecursoOAD _objRecurso = new RecursoOAD();
            return _objRecurso.Seleccionar_RecursosParaPasosDeConfeccion(Id_GrupoDeMiembros);
        }
        public List<LC_Recursos_ConCostoResult> Seleccionar_RecursosQueEstanEnCostos(long? Id_GrupoDeMiembros)
        {
            RecursoOAD _objRecurso = new RecursoOAD();
            return _objRecurso.Seleccionar_RecursosQueEstanEnCostos(Id_GrupoDeMiembros);
        }
        public List<LC_Recursos_MaquinariaResult> Seleccionar_Maquinaria()
        {
            RecursoOAD _objRecurso = new RecursoOAD();
            return _objRecurso.Seleccionar_Maquinaria(SessionManager.Id_GrupoDeMiembros);
        }
    }
}