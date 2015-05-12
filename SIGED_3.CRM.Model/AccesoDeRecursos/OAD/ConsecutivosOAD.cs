using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ConsecutivosOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Consecutivo
        /// </summary>
        /// <returns>Lista de registros tipo Consecutivo</returns>
        public List<Consecutivos> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Consecutivos.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Consecutivo
        /// </summary>
        /// <param name=Id>Identificador de la Consecutivo</param>
        /// <returns>Objeto singular del tipo Consecutivo</returns>
        public Consecutivos Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Consecutivos.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Carga de la lista principal de consecutivos.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">identificador del grupo de miembros</param>
        /// <returns>Lista de consecutivos secun procedimiento.</returns>
        public List<LP_ConsecutivosResult> Seleccionar_LP(int? id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Consecutivos(id_GrupoDeMiembros).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Consecutivo en la base de datos.
        /// </summary>
        /// <param name=objConsecutivo>Objeto Consecutivo a guardar</param>
        public void Guardar(Consecutivos objConsecutivos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Consecutivos.InsertOnSubmit(objConsecutivos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto Consecutivo y obtiene su Id
        /// </summary>
        /// <param name="objConsecutivo">Licnete a guardar</param>
        public long Guardar_2(Consecutivos objConsecutivo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Consecutivos.InsertOnSubmit(objConsecutivo);
                dc.SubmitChanges();
                return dc.Consecutivos.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Consecutivo, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Consecutivo</param>
        public void Eliminar(Consecutivos objConsecutivos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Consecutivos _objConsecutivos = dc.Consecutivos.Single(p => p.Id == objConsecutivos.Id);
                dc.Consecutivos.DeleteOnSubmit(_objConsecutivos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Consecutivo, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objConsecutivo>Objeto del tipo Consecutivo</param>
        public void Actualizar(Consecutivos objConsecutivos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Consecutivos _objConsecutivos = dc.Consecutivos.Single(p => p.Id == objConsecutivos.Id);
                _objConsecutivos.Id = objConsecutivos.Id;
                _objConsecutivos.Id_GrupoDeMiembros = objConsecutivos.Id_GrupoDeMiembros;
                _objConsecutivos.Id_Modulo = objConsecutivos.Id_Modulo;
                _objConsecutivos.Serie = objConsecutivos.Serie;
                _objConsecutivos.Posicion = objConsecutivos.Posicion;
                _objConsecutivos.Desde = objConsecutivos.Desde;
                _objConsecutivos.Hasta = objConsecutivos.Hasta;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Metodo que retorna la configuracion para un modulo seleccionado en el modulo de consecutivos
        /// </summary>
        /// <param name="Id_Modulo">Id del modulo que se debe cargar la configuracion</param>
        /// <param name="Id_GrupoDeMiembros">Grupo de miembros del modulos</param>
        /// <returns>configuracion</returns>
        public long?[] Determinar_Configuracion(long Id_Modulo, long Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                long?[] Resultado = new long?[8];
                if (dc.Consecutivos.Any(p => p.Id_Modulo == Id_Modulo && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros))
                {
                    Consecutivos objConsecutivo = dc.Consecutivos.Where(p => p.Id_Modulo == Id_Modulo && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).OrderBy(p => p.Id).ToList().Last();
                    //Determinar minimo posible Serie
                    Resultado[0] = objConsecutivo.Serie + 1;
                    //Determinar minimo posible Desde
                    Resultado[1] = objConsecutivo.Hasta + 1;
                    //Determinar minimo posicion
                    Resultado[2] = Resultado[1];
                    //Determinar minimo Hasta
                    Resultado[3] = Resultado[1];
                }
                else
                {
                    //Determinar minimo posible Serie
                    Resultado[0] = 1;
                    //Determinar minimo posible Desde
                    Resultado[1] = 1;
                    //Determinar minimo posicion
                    Resultado[2] = 1;
                    //Determinar minimo posicion
                    Resultado[3] = 1;
                }
                return Resultado;
            }
        }
        /// <summary>
        /// Retorna el siguiente consecutivo de un modulo.
        /// </summary>
        /// <param name="Id_Modulo">id del modulo a consultar</param>
        /// <param name="Id_GrupoDeMiembros">id del grupo de miembros</param>
        /// <returns>un numero o nullo en caso de que el consecutivo no exista.</returns>
        public long? TomarConsecutivo(long Id_Modulo, long Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Consecutivos.Any(p => p.Id_Modulo == Id_Modulo && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros))
                {
                    Consecutivos objConsecutivo = dc.Consecutivos.Where(p => p.Id_Modulo == Id_Modulo && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).OrderBy(p => p.Id).ToList().Last();
                    if (objConsecutivo.Posicion.Value <= objConsecutivo.Hasta.Value)
                    {
                        long Consecutivo = objConsecutivo.Posicion.Value;
                        objConsecutivo.Posicion++;
                        dc.SubmitChanges();
                        return Consecutivo;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Valida si existe un consecutivo para un modulo cualquiera sin usarlo
        /// </summary>
        /// <param name="Id_Modulo">Modulo del consecutivo a tomar</param>
        /// <param name="Id_GrupoDeMiembros">grupo de miembro del usuario actual</param>
        /// <returns>si hay consecutivo o no</returns>
        public bool HayConsecutivo(long Id_Modulo, long Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Consecutivos.Any(p => p.Id_Modulo == Id_Modulo && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros))
                {
                    Consecutivos objConsecutivo = dc.Consecutivos.Where(p => p.Id_Modulo == Id_Modulo && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).OrderBy(p => p.Id).ToList().Last();
                    if (objConsecutivo.Posicion.Value <= objConsecutivo.Hasta.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}