using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Proveedor_ContactoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Proveedor_Contacto> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Proveedor_Contacto.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Proveedor_Contacto Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Proveedor_Contacto.Any(p => p.Id == Id))
                {
                    return dc.Proveedor_Contacto.Single(p => p.Id == Id);
                }
                else
                {
                    return new Proveedor_Contacto();
                }
            }
        }
        /// <summary>
        /// Obtiene todos los contactos de un Proveedor
        /// </summary>
        /// <param name="Id_Proveedor">Identificativo del Proveedor</param>
        /// <returns>Lista de los contactos del Proveedor</returns>
        public List<Proveedor_Contacto> Seleccionar_By_Proveedor(long Id_Proveedor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var Query = from p in dc.Proveedor_Contacto
                            where p.Id_Proveedor == Id_Proveedor
                            select p;
                return Query.ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Proveedor_Contacto objProveedor_Contacto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Proveedor_Contacto.InsertOnSubmit(objProveedor_Contacto);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Proveedor_Contacto objProveedor_Contacto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Proveedor_Contacto _objProveedor_Contacto = dc.Proveedor_Contacto.Single(p => p.Id == objProveedor_Contacto.Id);
                dc.Proveedor_Contacto.DeleteOnSubmit(_objProveedor_Contacto);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Proveedor_Contacto objProveedor_Contacto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Proveedor_Contacto _objProveedor_Contacto = dc.Proveedor_Contacto.Single(p => p.Id == objProveedor_Contacto.Id);
                _objProveedor_Contacto.Id = objProveedor_Contacto.Id;
                _objProveedor_Contacto.Id_Proveedor = objProveedor_Contacto.Id_Proveedor;
                _objProveedor_Contacto.Nombres = objProveedor_Contacto.Nombres;
                _objProveedor_Contacto.Apellidos = objProveedor_Contacto.Apellidos;
                _objProveedor_Contacto.Telefono = objProveedor_Contacto.Telefono;
                _objProveedor_Contacto.Fax = objProveedor_Contacto.Fax;
                _objProveedor_Contacto.Movil = objProveedor_Contacto.Movil;
                _objProveedor_Contacto.Estado = objProveedor_Contacto.Estado;
                _objProveedor_Contacto.Direccion = objProveedor_Contacto.Direccion;
                _objProveedor_Contacto.Sede = objProveedor_Contacto.Sede;
                dc.SubmitChanges();
            }
        }
    }
}