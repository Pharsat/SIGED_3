using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class CodigosDeActivacionOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla CodigosDeActivacion
        /// </summary>
        /// <returns>Lista de registros tipo CodigosDeActivacion</returns>
        public List<CodigosDeActivacion> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.CodigosDeActivacion.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla CodigosDeActivacion
        /// </summary>
        /// <param name=Id>Identificador de la CodigosDeActivacion</param>
        /// <returns>Objeto singular del tipo CodigosDeActivacion</returns>
        public List<CodigosDeActivacion> Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var query = from p in dc.CodigosDeActivacion
                            where p.Id == Id
                            select p;
                return query.ToList();
            }
        }

        public CodigosDeActivacion Seleccionar_Id_Unico(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.CodigosDeActivacion.Single(p => p.Id == Id);
            }
        }

        /// <summary>
        /// Guarda un objeto de tipo CodigosDeActivacion en la base de datos.
        /// </summary>
        /// <param name=objCodigosDeActivacion>Objeto CodigosDeActivacion a guardar</param>
        public void Guardar(CodigosDeActivacion objCodigosDeActivacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.CodigosDeActivacion.InsertOnSubmit(objCodigosDeActivacion);
                dc.SubmitChanges();
            }
        }

        public void Guardar(CodigosDeActivacion objCodigosDeActivacion, ModeloDataContext dc)
        {
            dc.CodigosDeActivacion.InsertOnSubmit(objCodigosDeActivacion);
            dc.SubmitChanges();
        }
        /// <summary>
        /// Elimina un objeto del tipo CodigosDeActivacion, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) CodigosDeActivacion</param>
        public void Eliminar(CodigosDeActivacion objCodigosDeActivacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                CodigosDeActivacion _objCodigosDeActivacion = dc.CodigosDeActivacion.Single(p => p.Id == objCodigosDeActivacion.Id);
                dc.CodigosDeActivacion.DeleteOnSubmit(_objCodigosDeActivacion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una CodigosDeActivacion, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objCodigosDeActivacion>Objeto del tipo CodigosDeActivacion</param>
        public void Actualizar(CodigosDeActivacion objCodigosDeActivacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                CodigosDeActivacion _objCodigosDeActivacion = dc.CodigosDeActivacion.Single(p => p.Id == objCodigosDeActivacion.Id);
                _objCodigosDeActivacion.Aprobado = objCodigosDeActivacion.Aprobado;
                _objCodigosDeActivacion.CodigoDeActivacion = objCodigosDeActivacion.CodigoDeActivacion;
                _objCodigosDeActivacion.FechaCreacion = objCodigosDeActivacion.FechaCreacion;
                _objCodigosDeActivacion.Id = objCodigosDeActivacion.Id;
                _objCodigosDeActivacion.Id_CuentaActivadora = objCodigosDeActivacion.Id_CuentaActivadora;
                _objCodigosDeActivacion.Id_Miembro_Destino = objCodigosDeActivacion.Id_Miembro_Destino;
                _objCodigosDeActivacion.Id_Solicitante_Usuario = objCodigosDeActivacion.Id_Solicitante_Usuario;
                _objCodigosDeActivacion.NroUsosActuales = objCodigosDeActivacion.NroUsosActuales;
                _objCodigosDeActivacion.NroUsosMax = objCodigosDeActivacion.NroUsosMax;
                _objCodigosDeActivacion.FechaActivacion_Cuenta = objCodigosDeActivacion.FechaActivacion_Cuenta;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// verifica un codigo de activacion en el sistema y consume un uso en caso solicitado
        /// </summary>
        /// <param name="Codigo">codigo a validar</param>
        /// <param name="ConsumirCodigo">indica si se consume un uso de este codigo o no</param>
        /// <returns>verificacion</returns>
        public bool Verificar(string Codigo, bool ConsumirCodigo)
        {
            if (Codigo != String.Empty)
            {
                using (ModeloDataContext dc = new ModeloDataContext())
                {
                    if (dc.CodigosDeActivacion.Any(p => p.CodigoDeActivacion == Codigo && p.NroUsosMax - p.NroUsosActuales > 0))
                    {
                        if (ConsumirCodigo)
                        {
                            CodigosDeActivacion _objCodigosDeActivacion = dc.CodigosDeActivacion.Single(p => p.CodigoDeActivacion == Codigo);
                            _objCodigosDeActivacion.NroUsosActuales += 1;
                            dc.SubmitChanges();
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Genera el codigo con el cual se hacen las llaves para la aplicación.
        /// </summary>
        /// <param name="NumUsos">Cantidad de usos maximo permitido para esta llave</param>
        /// <returns>llave</returns>
        public string GenerarCodigo(short NumUsos, long? Id_Cuenta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                string Codigo = DateTime.Now.ToUniversalTime().ToString("ddMMyyyy");
                string Max;
                if (dc.CodigosDeActivacion.Count() > 0)
                {
                    Max = (dc.CodigosDeActivacion.Max(p => p.Id) + 1).ToString();
                }
                else
                {
                    Max = "1";
                }
                if (Max.Length == 1)
                {
                    Max = "0" + Max;
                }
                CodigosDeActivacion objCodigo = new CodigosDeActivacion();
                objCodigo.CodigoDeActivacion = Codigo + Max;
                objCodigo.FechaCreacion = DateTime.Now.ToUniversalTime();
                objCodigo.NroUsosActuales = 0;
                objCodigo.NroUsosMax = NumUsos;
                objCodigo.Id_CuentaActivadora = Id_Cuenta;
                if (!dc.CodigosDeActivacion.Any(p => p.CodigoDeActivacion == objCodigo.CodigoDeActivacion))
                {
                    this.Guardar(objCodigo);
                    return objCodigo.CodigoDeActivacion;
                }
                else
                {
                    return "X";
                }
            }
        }

        public string GenerarCodigoCuenta(long? Id_Miembro, long? Id_CuentaSolicitante)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                string Codigo = DateTime.Now.ToUniversalTime().ToString("ddMMyyyy");
                string Max;
                if (dc.CodigosDeActivacion.Count() > 0)
                {
                    Max = (dc.CodigosDeActivacion.Max(p => p.Id) + 1).ToString();
                }
                else
                {
                    Max = "1";
                }
                if (Max.Length == 1)
                {
                    Max = "0" + Max;
                }
                CodigosDeActivacion objCodigo = new CodigosDeActivacion();
                objCodigo.CodigoDeActivacion = Codigo + Max;
                objCodigo.FechaCreacion = DateTime.Now.ToUniversalTime();
                objCodigo.NroUsosActuales = 0;
                objCodigo.NroUsosMax = 1;
                objCodigo.Id_CuentaActivadora = null;
                objCodigo.Id_Solicitante_Usuario = Id_CuentaSolicitante;
                objCodigo.Aprobado = false;
                objCodigo.Id_Miembro_Destino = Id_Miembro;
                if (!dc.CodigosDeActivacion.Any(p => p.CodigoDeActivacion == objCodigo.CodigoDeActivacion))
                {
                    this.Guardar(objCodigo, dc);
                    return objCodigo.CodigoDeActivacion;
                }
                else
                {
                    return "X";
                }
            }
        }

        public List<LP_CodigosDeActivacionNuevosUsuariosResult> ListaDeCodigosParaAprobar()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_CodigosDeActivacionNuevosUsuarios().ToList();
            }
        }


    }
}