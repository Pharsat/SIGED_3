using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Cliente_ContactoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Cliente_Contacto> Seleccionar_All()
        {
            Cliente_ContactoOAD objCliente_Contacto = new Cliente_ContactoOAD();
            return objCliente_Contacto.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Cliente_Contacto Seleccionar_Id(long Id)
        {
            Cliente_ContactoOAD objCliente_Contacto = new Cliente_ContactoOAD();
            return objCliente_Contacto.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Obtiene todos los contactos de un cliente
        /// </summary>
        /// <param name="Id_Cliente">Identificativo del cliente</param>
        /// <returns>Lista de los contactos del cliente</returns>
        public List<Cliente_Contacto> Seleccionar_By_Cliente(int Id_Cliente)
        {
            Cliente_ContactoOAD objCliente_Contacto = new Cliente_ContactoOAD();
            return objCliente_Contacto.Seleccionar_By_Cliente(Id_Cliente);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Cliente_Contacto objCliente_Contacto)
        {
            Cliente_ContactoOAD _objCliente_Contacto = new Cliente_ContactoOAD();
            _objCliente_Contacto.Guardar(objCliente_Contacto);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Cliente_Contacto objCliente_Contacto)
        {
            Cliente_ContactoOAD _objCliente_Contacto = new Cliente_ContactoOAD();
            _objCliente_Contacto.Eliminar(objCliente_Contacto);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Cliente_Contacto objCliente_Contacto)
        {
            Cliente_ContactoOAD _objCliente_Contacto = new Cliente_ContactoOAD();
            _objCliente_Contacto.Actualizar(objCliente_Contacto);
        }
    }
}