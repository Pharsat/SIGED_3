using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Proveedor_ContactoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Proveedor_Contacto> Seleccionar_All()
        {
            Proveedor_ContactoOAD objProveedor_Contacto = new Proveedor_ContactoOAD();
            return objProveedor_Contacto.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Proveedor_Contacto Seleccionar_Id(long Id)
        {
            Proveedor_ContactoOAD objProveedor_Contacto = new Proveedor_ContactoOAD();
            return objProveedor_Contacto.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Obtiene todos los contactos de un Proveedor
        /// </summary>
        /// <param name="Id_Proveedor">Identificativo del Proveedor</param>
        /// <returns>Lista de los contactos del Proveedor</returns>
        public List<Proveedor_Contacto> Seleccionar_By_Proveedor(long Id_Proveedor)
        {
            Proveedor_ContactoOAD objProveedor_Contacto = new Proveedor_ContactoOAD();
            return objProveedor_Contacto.Seleccionar_By_Proveedor(Id_Proveedor);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Proveedor_Contacto objProveedor_Contacto)
        {
            Proveedor_ContactoOAD _objProveedor_Contacto = new Proveedor_ContactoOAD();
            _objProveedor_Contacto.Guardar(objProveedor_Contacto);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Proveedor_Contacto objProveedor_Contacto)
        {
            Proveedor_ContactoOAD _objProveedor_Contacto = new Proveedor_ContactoOAD();
            _objProveedor_Contacto.Eliminar(objProveedor_Contacto);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Proveedor_Contacto objProveedor_Contacto)
        {
            Proveedor_ContactoOAD _objProveedor_Contacto = new Proveedor_ContactoOAD();
            _objProveedor_Contacto.Actualizar(objProveedor_Contacto);
        }
    }
}