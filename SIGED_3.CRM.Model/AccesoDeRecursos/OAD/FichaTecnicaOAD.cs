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
    internal class FichaTecnicaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Lista principal de fichas tecnicas.
        /// </summary>
        /// <param name="estado">estado de la ficha tecnica</param>
        /// <param name="id_GrupoDeMiembros">identificador del grupo de miembros</param>
        /// <param name="codigo">codigo de la prenda</param>
        /// <param name="tipoPrenda">tipo de prenda</param>
        /// <returns>Lista resultado de ficha tecnica</returns>
        public List<LP_FichasTecnicasResult> Seleccionar_LP(int? id_GrupoDeMiembros, string codigo, string tipoPrenda)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_FichasTecnicas(id_GrupoDeMiembros, codigo, tipoPrenda).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica objFichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica.InsertOnSubmit(objFichaTecnica);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda la fucha tecnica y obtiene su id
        /// </summary>
        /// <param name="objFichaTecnica">objeto ficha tecnica</param>
        /// <returns>identificador de la ficha</returns>
        public long Guardar_2(FichaTecnica objFichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica.InsertOnSubmit(objFichaTecnica);
                dc.SubmitChanges();
                return dc.FichaTecnica.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica objFichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica _objFichaTecnica = dc.FichaTecnica.Single(p => p.Id == objFichaTecnica.Id);
                dc.FichaTecnica.DeleteOnSubmit(_objFichaTecnica);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica objFichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica _objFichaTecnica = dc.FichaTecnica.Single(p => p.Id == objFichaTecnica.Id);
                _objFichaTecnica.Id = objFichaTecnica.Id;
                _objFichaTecnica.Id_GrupoDeMiembros = objFichaTecnica.Id_GrupoDeMiembros;
                _objFichaTecnica.Id_Imagen = objFichaTecnica.Id_Imagen;
                _objFichaTecnica.Codigo = objFichaTecnica.Codigo;
                _objFichaTecnica.FechaActualizacion = objFichaTecnica.FechaActualizacion;
                _objFichaTecnica.Tela = objFichaTecnica.Tela;
                _objFichaTecnica.TelaComplemento = objFichaTecnica.TelaComplemento;
                _objFichaTecnica.TipoPrenda = objFichaTecnica.TipoPrenda;
                _objFichaTecnica.Descripccion = objFichaTecnica.Descripccion;
                _objFichaTecnica.ICCoserCerrado = objFichaTecnica.ICCoserCerrado;
                _objFichaTecnica.ICCoserPesPunteado = objFichaTecnica.ICCoserPesPunteado;
                _objFichaTecnica.ICTipoRecubridora = objFichaTecnica.ICTipoRecubridora;
                _objFichaTecnica.ICAgujaNro = objFichaTecnica.ICAgujaNro;
                _objFichaTecnica.ICPiezasFusionadas = objFichaTecnica.ICPiezasFusionadas;
                _objFichaTecnica.ICCuales = objFichaTecnica.ICCuales;
                _objFichaTecnica.ICPuntadasPorPulgadaCerrado = objFichaTecnica.ICPuntadasPorPulgadaCerrado;
                _objFichaTecnica.ICPuntadasPorPulgadaPespunteado = objFichaTecnica.ICPuntadasPorPulgadaPespunteado;
                _objFichaTecnica.MATexto = objFichaTecnica.MATexto;
                _objFichaTecnica.MAUbicacione = objFichaTecnica.MAUbicacione;
                _objFichaTecnica.MAAltura = objFichaTecnica.MAAltura;
                _objFichaTecnica.PLPlancha = objFichaTecnica.PLPlancha;
                _objFichaTecnica.PLVaporizacion = objFichaTecnica.PLVaporizacion;
                _objFichaTecnica.EMRecubridora = objFichaTecnica.EMRecubridora;
                _objFichaTecnica.EMPLana = objFichaTecnica.EMPLana;
                _objFichaTecnica.EMFileteSencillo = objFichaTecnica.EMFileteSencillo;
                _objFichaTecnica.EMEspeciales = objFichaTecnica.EMEspeciales;
                _objFichaTecnica.EMTipoAjuste = objFichaTecnica.EMTipoAjuste;
                _objFichaTecnica.EMAncho = objFichaTecnica.EMAncho;
                _objFichaTecnica.EMFileteConseguridad = objFichaTecnica.EMFileteConseguridad;
                _objFichaTecnica.ATPies = objFichaTecnica.ATPies;
                _objFichaTecnica.ATFolders = objFichaTecnica.ATFolders;
                _objFichaTecnica.ATPlantillas = objFichaTecnica.ATPlantillas;
                _objFichaTecnica.ICOCosturasAbiertas = objFichaTecnica.ICOCosturasAbiertas;
                _objFichaTecnica.ICOCosturasCerradas = objFichaTecnica.ICOCosturasCerradas;
                _objFichaTecnica.ICOCosturasConPespunte = objFichaTecnica.ICOCosturasConPespunte;
                dc.SubmitChanges();
            }
        }

        public DataTable Impresion_FichaTecnica(long? Id_Ficha)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Ficha) }, ProcedimientosAlmacenados.I_FichaTecnica);
        }
        public DataTable Impresion_FichaTecnica_Colores(long? Id_Ficha)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Ficha) }, ProcedimientosAlmacenados.I_FichaTecnica_Colores);
        }
        public DataTable Impresion_FichaTecnica_Hilos(long? Id_Ficha)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Ficha) }, ProcedimientosAlmacenados.I_FichaTecnica_Hilos);
        }
        public DataTable Impresion_FichaTecnica_Marquillas(long? Id_Ficha)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Ficha) }, ProcedimientosAlmacenados.I_FichaTecnica_Marquillas);
        }
        public DataTable Impresion_PasosDeConfeccion(long? Id_Ficha)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Ficha) }, ProcedimientosAlmacenados.I_FichaTecnica_PasosDeConfeccion);
        }
        public DataTable Impresion_ProcesosDetallados(long? Id_Ficha)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Ficha) }, ProcedimientosAlmacenados.I_FichaTecnica_ProcesosDetallados);
        }
        public DataTable Impresion_FichaTecnica_Tallas(long? Id_Ficha)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Ficha) }, ProcedimientosAlmacenados.I_FichaTecnica_Tallas);
        }
    }
}