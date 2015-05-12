using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Cliente_ContactoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Cliente_Contacto> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Cliente_Contacto.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Cliente_Contacto Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Cliente_Contacto.Any(p => p.Id == Id))
                {
                    return dc.Cliente_Contacto.Single(p => p.Id == Id);
                }
                else
                {
                    return new Cliente_Contacto();
                }
            }
        }
        /// <summary>
        /// Obtiene todos los contactos de un cliente
        /// </summary>
        /// <param name="Id_Cliente">Identificativo del cliente</param>
        /// <returns>Lista de los contactos del cliente</returns>
        public List<Cliente_Contacto> Seleccionar_By_Cliente(long Id_Cliente)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var Query = from p in dc.Cliente_Contacto
                            where p.Id_Cliente == Id_Cliente
                            select p;
                return Query.ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Cliente_Contacto objCliente_Contacto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Cliente_Contacto.InsertOnSubmit(objCliente_Contacto);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Cliente_Contacto objCliente_Contacto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Cliente_Contacto _objCliente_Contacto = dc.Cliente_Contacto.Single(p => p.Id == objCliente_Contacto.Id);
                dc.Cliente_Contacto.DeleteOnSubmit(_objCliente_Contacto);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Cliente_Contacto objCliente_Contacto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Cliente_Contacto _objCliente_Contacto = dc.Cliente_Contacto.Single(p => p.Id == objCliente_Contacto.Id);
                _objCliente_Contacto.Id = objCliente_Contacto.Id;
                _objCliente_Contacto.Id_Cliente = objCliente_Contacto.Id_Cliente;
                _objCliente_Contacto.Nombres = objCliente_Contacto.Nombres;
                _objCliente_Contacto.Apellidos = objCliente_Contacto.Apellidos;
                _objCliente_Contacto.Telefono = objCliente_Contacto.Telefono;
                _objCliente_Contacto.Fax = objCliente_Contacto.Fax;
                _objCliente_Contacto.Movil = objCliente_Contacto.Movil;
                _objCliente_Contacto.Estado = objCliente_Contacto.Estado;
                _objCliente_Contacto.Direccion = objCliente_Contacto.Direccion;
                _objCliente_Contacto.Sede = objCliente_Contacto.Sede;
                dc.SubmitChanges();
            }
        }
    }
}