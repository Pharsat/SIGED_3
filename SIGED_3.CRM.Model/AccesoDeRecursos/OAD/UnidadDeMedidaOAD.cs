using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class UnidadDeMedidaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<UnidadDeMedida> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.UnidadDeMedida.ToList();
            }
        }
        /// <summary>
        /// Seleccona las unidades de medida por tipo de recurso.
        /// </summary>
        /// <param name="Tipo">tipo de la unidad de medida a selecinar</param>
        /// <returns>lista de unidades de medida</returns>
        public List<UnidadDeMedida> Seleccionar_Tipo(long? Id_Cosa, string TipoCosa)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                string Tipo = String.Empty;
                switch (TipoCosa)
                {
                    case "p":
                        Tipo = new UnidadDeMedidaFachada().Seleccionar_Id(new ProcesoDeFabricacionFachada().Seleccionar_Id(Id_Cosa.Value).Id_UnidadDeMedida.Value).Tipo;
                        break;
                    case "r":
                        Tipo = new UnidadDeMedidaFachada().Seleccionar_Id(new RecursoFachada().Seleccionar_Id(Id_Cosa.Value).Id_UnidadDeMedida.Value).Tipo;
                        break;
                }
                return dc.UnidadDeMedida.Where(p => p.Tipo == Tipo).ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public UnidadDeMedida Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.UnidadDeMedida.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(UnidadDeMedida objUnidadDeMedida)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.UnidadDeMedida.InsertOnSubmit(objUnidadDeMedida);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(UnidadDeMedida objUnidadDeMedida)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                UnidadDeMedida _objUnidadDeMedida = dc.UnidadDeMedida.Single(p => p.Id == objUnidadDeMedida.Id);
                dc.UnidadDeMedida.DeleteOnSubmit(_objUnidadDeMedida);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(UnidadDeMedida objUnidadDeMedida)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                UnidadDeMedida _objUnidadDeMedida = dc.UnidadDeMedida.Single(p => p.Id == objUnidadDeMedida.Id);
                _objUnidadDeMedida.Id = objUnidadDeMedida.Id;
                _objUnidadDeMedida.Nombre = objUnidadDeMedida.Nombre;
                _objUnidadDeMedida.Estado = objUnidadDeMedida.Estado;
                _objUnidadDeMedida.Tipo = objUnidadDeMedida.Tipo;
                _objUnidadDeMedida.Base = objUnidadDeMedida.Base;
                _objUnidadDeMedida.Posicionamiento = objUnidadDeMedida.Posicionamiento;
                dc.SubmitChanges();
            }
        }
    }
}