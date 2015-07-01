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
    public class CompraFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Compra> Seleccionar_All()
        {
            CompraLN objCompra = new CompraLN();
            return objCompra.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Compra Seleccionar_Id(long Id)
        {
            CompraLN objCompra = new CompraLN();
            return objCompra.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Carca la lista principal de compras.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">El identificador del grupo de miembros</param>
        /// <param name="desde">la fecha inicial del periodo a buscar.</param>
        /// <param name="hasta">la fecha final del periodo final.</param>
        /// <returns>Lista del resultado de la vita ppal de compras</returns>
        public List<LP_ComprasResult> Seleccionar_LP(int? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            CompraLN objCompra = new CompraLN();
            return objCompra.Seleccionar_LP(id_GrupoDeMiembros, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Compra objCompra)
        {
            CompraLN _objCompra = new CompraLN();
            _objCompra.Guardar(objCompra);
        }
        public long Guardar_2(Compra objCompra)
        {
            CompraLN _objCompra = new CompraLN();
            return _objCompra.Guardar_2(objCompra);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Compra objCompra)
        {
            CompraLN _objCompra = new CompraLN();
            _objCompra.Eliminar(objCompra);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Compra objCompra)
        {
            CompraLN _objCompra = new CompraLN();
            _objCompra.Actualizar(objCompra);
        }
        public List<R_ComprasResult> Informe_Compras(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta, long? id_Proveedor, long? id_Recurso)
        {
            CompraLN _objCompra = new CompraLN();
            return _objCompra.Informe_Compras(id_GrupoDeMiembros, desde, hasta, id_Proveedor, id_Recurso);
        }

        public DataTable Impresion_Compra(long? Id_Compra)
        {
            CompraLN _objCompra = new CompraLN();
            return _objCompra.Impresion_Compra(Id_Compra);
        }
        public DataTable Impresion_Compra_Detalle(long? Id_Compra)
        {
            CompraLN _objCompra = new CompraLN();
            return _objCompra.Impresion_Compra_Detalle(Id_Compra);
        }
    }
}