namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Negocio.Entidades;

    internal class BodegaOad
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
        public List<Bodega> Seleccionar_All_Activos(long? idGrupoDeMiembros, long? idBodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (idBodega.HasValue)
                {
                    return dc.Bodega.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == idGrupoDeMiembros || p.Id == idBodega.Value).ToList();
                }
                else
                {
                    return dc.Bodega.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == idGrupoDeMiembros).ToList();
                }
            }
        }
        public List<BodegaPorRecursosFaltantes> Seleccionar_ALasQueLeFaltanRecursos(long? idGrupoDeMiembros)
        {
            List<BodegaPorRecursosFaltantes> bodegasFaltantes = new List<BodegaPorRecursosFaltantes>();
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                int countRecursos = dc.Recurso.Count(p => p.Id_GrupoDeMiembros == idGrupoDeMiembros);
                var lstBodegas = dc.Bodega.Where(p => p.Id_GrupoDeMiembros == idGrupoDeMiembros).ToList();
                bodegasFaltantes.AddRange(from bodega in lstBodegas
                                          where countRecursos != dc.Inventario.Where(p => p.Id_Bodega == bodega.Id).Select(p => p.Id_Recurso).Distinct().Count()
                                          select new BodegaPorRecursosFaltantes()
                                          {
                                              Bodega = bodega,
                                              Faltantes = dc.Recurso.Where(p => !(dc.Inventario.Where(q => q.Id_GrupoDeMiemros == idGrupoDeMiembros && q.Id_Bodega == bodega.Id).Select(q => q.Id_Recurso).Distinct().Contains(p.Id)) && p.Id_GrupoDeMiembros == idGrupoDeMiembros).ToList()
                                          });
            }
            return bodegasFaltantes;
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Bodega Seleccionar_Id(long id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Bodega.Single(p => p.Id == id);
            }
        }
        /// <summary>
        /// Metodo que consulta la lista principal de bodegas.
        /// </summary>
        /// <param name="estado">Estado de habilidad de la bodega</param>
        /// <param name="idGrupoDeMiembros">Grupo de pertenencia</param>
        /// <param name="nombre">Nombre de la bodega</param>
        /// <returns>Lista de datos de la bodega</returns>
        public List<LP_BodegasResult> Seleccionar_LP(bool? estado, long? idGrupoDeMiembros, string nombre)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Bodegas(estado, idGrupoDeMiembros, nombre).ToList();
            }
        }

        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name="objBodega">Objeto Bodega a guardar</param>
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
            using (var dc = new ModeloDataContext())
            {
                dc.Bodega.InsertOnSubmit(objBodega);
                dc.SubmitChanges();
                return dc.Bodega.Max(p => p.Id);
            }
        }

        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name="bodega"></param>
        public void Eliminar(Bodega bodega)
        {
            using (var dc = new ModeloDataContext())
            {
                var objBodega = dc.Bodega.Single(p => p.Id == bodega.Id);
                if (objBodega == null) throw new ArgumentNullException("bodega");
                dc.Bodega.DeleteOnSubmit(objBodega);
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name="bodega">Objeto del tipo Bodega</param>
        public void Actualizar(Bodega bodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Bodega objBodega = dc.Bodega.Single(p => p.Id == bodega.Id);
                objBodega.Id = bodega.Id;
                objBodega.Id_GrupoDeMiembros = bodega.Id_GrupoDeMiembros;
                objBodega.Id_Pais = bodega.Id_Pais;
                objBodega.Id_Provincia = bodega.Id_Provincia;
                objBodega.Id_Ciudad = bodega.Id_Ciudad;
                objBodega.Nombre = bodega.Nombre;
                objBodega.Direccion = bodega.Direccion;
                objBodega.Telefono_1 = bodega.Telefono_1;
                objBodega.Telefono_2 = bodega.Telefono_2;
                objBodega.Estado = bodega.Estado;
                dc.SubmitChanges();
            }
        }
    }
}