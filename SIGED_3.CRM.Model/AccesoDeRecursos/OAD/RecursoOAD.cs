using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Enum;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class RecursoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Recurso> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recurso.ToList();
            }
        }
        public List<Recurso> Seleccionar_All_ByGrupo(long? Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recurso.Where(p => p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Recurso Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recurso.Single(p => p.Id == Id);
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Recursos(id_GrupoDeMiembros, estado, nombre, id_TipoDeRecurso).ToList();
            }
        }
        /// <summary>
        /// retorna todos los recursos que no son productos terminados
        /// </summary>
        /// <param name="id_GrupoDeMiembros">grupo de miembros del recurso</param>
        /// <param name="id_ProductoNoTerminado">identificador de los recursos tipo producto terminado.</param>
        /// <returns></returns>
        public List<LC_Recursos_NoProductoTerminadoResult> Seleccionar_LC_1(long? id_GrupoDeMiembros, long? id_ProductoNoTerminado)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LC_Recursos_NoProductoTerminado(id_GrupoDeMiembros, id_ProductoNoTerminado).ToList();
            }
        }
        /// <summary>
        /// metdo para obtener toda la lista de recursos mexclada.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">grupo de miembros de los recursos</param>
        /// <param name="id_ProductoNoTerminado">identificador de producto terminado</param>
        /// <returns>lista de recursos</returns>
        public List<LC_Recursos_MezcladosResult> Seleccionar_LC_2(long? id_GrupoDeMiembros, long? id_ProductoNoTerminado)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LC_Recursos_Mezclados(id_GrupoDeMiembros, id_ProductoNoTerminado).ToList();
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recurso.Any(p => p.Id_Color == id_Color && p.Talla == Talla && p.Id_FichaTecnica == Id_FichaTecnica);
            }
        }

        public Recurso Tomar_Existencia_Recurso(long? id_Color, string Talla, long? Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recurso.Single(p => p.Id_Color == id_Color && p.Talla == Talla && p.Id_FichaTecnica == Id_FichaTecnica);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Recurso objRecurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Recurso.InsertOnSubmit(objRecurso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda un recurso y devuelve el identificador con el que ha quedado.
        /// </summary>
        /// <param name="objRecurso">recurso a guardar</param>
        /// <returns>identificaor del recurso guardado</returns>
        public long Guardar_2(Recurso objRecurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Recurso.InsertOnSubmit(objRecurso);
                dc.SubmitChanges();
                return dc.Recurso.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Recurso objRecurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Recurso _objRecurso = dc.Recurso.Single(p => p.Id == objRecurso.Id);
                dc.Recurso.DeleteOnSubmit(_objRecurso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Recurso objRecurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Recurso _objRecurso = dc.Recurso.Single(p => p.Id == objRecurso.Id);
                _objRecurso.Id = objRecurso.Id;
                _objRecurso.Id_GrupoDeMiembros = objRecurso.Id_GrupoDeMiembros;
                _objRecurso.Id_UnidadDeMedida = objRecurso.Id_UnidadDeMedida;
                _objRecurso.Id_Color = objRecurso.Id_Color;
                _objRecurso.Id_TipoDeRecurso = objRecurso.Id_TipoDeRecurso;
                _objRecurso.Id_FichaTecnica = objRecurso.Id_FichaTecnica;
                _objRecurso.Talla = objRecurso.Talla;
                _objRecurso.Nombre = objRecurso.Nombre;
                _objRecurso.Estado = objRecurso.Estado;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Lista los recursos del tipo que aplican para pasos de coneccion en la ficha tecnica
        /// </summary>
        /// <returns>Lista de recursos</returns>
        public List<Recurso> Seleccionar_RecursosParaPasosDeConfeccion(long? Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recurso.Where(p => p.Id_TipoDeRecurso != (long?)TipoDeRecurso_Enum.ProductoTerminado).ToList();
            }
        }
        public List<Recurso> Seleccionar_RecursosQueNoEstanEnInventario(long? Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                List<long?> lstRecursosEnInventario = dc.Inventario.Where(p => p.Id_GrupoDeMiemros == Id_GrupoDeMiembros).Select(p => p.Id_Recurso).Distinct().ToList();
                return dc.Recurso.Where(p => p.Id_GrupoDeMiembros == Id_GrupoDeMiembros && !lstRecursosEnInventario.Contains(p.Id)).ToList();
            }
        }
        public List<LC_Recursos_ConCostoResult> Seleccionar_RecursosQueEstanEnCostos(long? Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                List<LC_Recursos_ConCostoResult> lstRecursosEnCostos = dc.LC_Recursos_ConCosto(Id_GrupoDeMiembros).ToList();
                return lstRecursosEnCostos;
            }
        }

        public List<Recurso> Seleccionar_RecursosQueNoEstanEnCostos(long? idGrupoDeMiembros, long? idFichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                List<long> idsDeRecursosYCostos = dc.Costo.Where(c => c.Id_GrupoDeMiembros == idGrupoDeMiembros && c.Id_Recurso.HasValue).Select(r => r.Id_Recurso.Value).ToList();
                List<Recurso> lstRecursosNoEnCostos = dc.Recurso.Where(r => !idsDeRecursosYCostos.Contains(r.Id) && r.Id_GrupoDeMiembros == idGrupoDeMiembros && r.Id_FichaTecnica == idFichaTecnica).ToList();
                return lstRecursosNoEnCostos;
            }
        }
        public List<LC_Recursos_MaquinariaResult> Seleccionar_Maquinaria(long? Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                List<LC_Recursos_MaquinariaResult> lstRecursosMaquinaria = dc.LC_Recursos_Maquinaria(Id_GrupoDeMiembros).ToList();
                return lstRecursosMaquinaria;
            }
        }
    }
}