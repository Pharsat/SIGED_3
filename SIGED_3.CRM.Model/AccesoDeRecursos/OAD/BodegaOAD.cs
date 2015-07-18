using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class BodegaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Bodega> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Bodega.ToList();
            }
        }
        public List<Bodega> Seleccionar_All_Activos(long? Id_GrupoDeMiembros, long? Id_Bodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (Id_Bodega.HasValue)
                {
                    return dc.Bodega.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros || p.Id == Id_Bodega.Value).ToList();
                }
                else
                {
                    return dc.Bodega.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).ToList();
                }
            }
        }
        public List<BodegaPorRecursosFaltantes> Seleccionar_ALasQueLeFaltanRecursos(long? Id_GrupoDeMiembros)
        {
            List<BodegaPorRecursosFaltantes> bodegasFaltantes = new List<BodegaPorRecursosFaltantes>();
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                int countRecursos = dc.Recurso.Where(p => p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).Count();
                List<Bodega> lstBodegas = dc.Bodega.Where(p => p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).ToList();
                foreach (var bodega in lstBodegas)
                {
                    if (countRecursos != dc.Inventario.Where(p => p.Id_Bodega == bodega.Id).Select(p => p.Id_Recurso).Distinct().Count())
                    {
                        bodegasFaltantes.Add(new BodegaPorRecursosFaltantes()
                        {
                            Bodega = bodega,
                            Faltantes = dc.Recurso.Where(p =>
                                !(dc.Inventario.Where(q =>
                                    q.Id_GrupoDeMiemros == Id_GrupoDeMiembros &&
                                    q.Id_Bodega == bodega.Id).Select(q =>
                                        q.Id_Recurso).Distinct().Contains(p.Id)) &&
                                        p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).ToList()
                        });
                    }
                }
            }
            return bodegasFaltantes;
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Bodega Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Bodega.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Metodo que consulta la lista principal de bodegas.
        /// </summary>
        /// <param name="Estado">Estado de habilidad de la bodega</param>
        /// <param name="Id_GrupoDeMiembros">Grupo de pertenencia</param>
        /// <param name="Nombre">Nombre de la bodega</param>
        /// <returns>Lista de datos de la bodega</returns>
        public List<LP_BodegasResult> Seleccionar_LP(bool? Estado, long? Id_GrupoDeMiembros, string Nombre)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Bodegas(Estado, Id_GrupoDeMiembros, Nombre).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Bodega objBodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Bodega.InsertOnSubmit(objBodega);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto Bodega y obtiene su Id
        /// </summary>
        /// <param name="objBodega">Licnete a guardar</param>
        public long Guardar_2(Bodega objBodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Bodega.InsertOnSubmit(objBodega);
                dc.SubmitChanges();
                return dc.Bodega.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Bodega objBodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Bodega _objBodega = dc.Bodega.Single(p => p.Id == objBodega.Id);
                dc.Bodega.DeleteOnSubmit(_objBodega);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Bodega objBodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Bodega _objBodega = dc.Bodega.Single(p => p.Id == objBodega.Id);
                _objBodega.Id = objBodega.Id;
                _objBodega.Id_GrupoDeMiembros = objBodega.Id_GrupoDeMiembros;
                _objBodega.Id_Pais = objBodega.Id_Pais;
                _objBodega.Id_Provincia = objBodega.Id_Provincia;
                _objBodega.Id_Ciudad = objBodega.Id_Ciudad;
                _objBodega.Nombre = objBodega.Nombre;
                _objBodega.Direccion = objBodega.Direccion;
                _objBodega.Telefono_1 = objBodega.Telefono_1;
                _objBodega.Telefono_2 = objBodega.Telefono_2;
                _objBodega.Estado = objBodega.Estado;
                dc.SubmitChanges();
            }
        }
    }
}