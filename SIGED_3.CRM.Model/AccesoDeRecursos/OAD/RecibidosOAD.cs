using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class RecibidosOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Recibidos> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recibidos.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Recibidos Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Recibidos.Single(p => p.Id == Id);
            }
        }
        public List<LP_RecibidosResult> Seleccionar_LP(long? estado, long? id_Cliente, long? consecutivo, DateTime? desde, DateTime? hasta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                id_Cliente = id_Cliente == 0 ? null : id_Cliente;
                return dc.LP_Recibidos(estado, id_Cliente, consecutivo, desde, hasta).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Recibidos objRecibidos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Recibidos.InsertOnSubmit(objRecibidos);
                dc.SubmitChanges();
            }
        }
        public long Guardar_2(Recibidos objRecibido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Recibidos.InsertOnSubmit(objRecibido);
                dc.SubmitChanges();
                return dc.Recibidos.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Recibidos objRecibidos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Recibidos _objRecibidos = dc.Recibidos.Single(p => p.Id == objRecibidos.Id);
                dc.Recibidos.DeleteOnSubmit(_objRecibidos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Recibidos objRecibidos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Recibidos _objRecibidos = dc.Recibidos.Single(p => p.Id == objRecibidos.Id);
                _objRecibidos.Id = objRecibidos.Id;
                _objRecibidos.Id_Receptor = objRecibidos.Id_Receptor;
                _objRecibidos.Id_GrupoDeMiembros = objRecibidos.Id_GrupoDeMiembros;
                _objRecibidos.Id_Estado = objRecibidos.Id_Estado;
                _objRecibidos.Consecutivo = objRecibidos.Consecutivo;
                _objRecibidos.FechaRecibido = objRecibidos.FechaRecibido;
                dc.SubmitChanges();
            }
        }
    }
}