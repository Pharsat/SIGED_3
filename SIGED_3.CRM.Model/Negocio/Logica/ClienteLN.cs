﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class ClienteLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Cliente> Seleccionar_All()
        {
            ClienteOAD objCliente = new ClienteOAD();
            return objCliente.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Cliente Seleccionar_Id(long Id)
        {
            ClienteOAD objCliente = new ClienteOAD();
            return objCliente.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Clientes que esten habilitados
        /// </summary>
        /// <returns>Lista de registros tipo cliente</returns>
        public List<Cliente> Seleccionar_All_Activos(long? Id_GrupoDeMiembros, long? Id_Cliente)
        {
            ClienteOAD objCliente = new ClienteOAD();
            return objCliente.Seleccionar_All_Activos(Id_GrupoDeMiembros, Id_Cliente);
        }
        /// <summary>
        /// Lista principal de la tabla cliente.
        /// </summary>
        /// <param name="estado">Estado del cliente en la base de datos</param>
        /// <param name="identificacion">identificacion del cliente</param>
        /// <param name="id_GrupoDeMiembros"> identificador del grupo de miembro</param>
        /// <param name="nombre">nombre del cliente o parte de el</param>
        /// <returns>Lista de cliente</returns>
        public List<LP_ClientesResult> Seleccionar_LP(bool? estado, string identificacion, int? id_GrupoDeMiembros, string nombre)
        {
            ClienteOAD objCliente = new ClienteOAD();
            return objCliente.Seleccionar_LP(estado, identificacion, id_GrupoDeMiembros, nombre);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Cliente objCliente)
        {
            ClienteOAD _objCliente = new ClienteOAD();
            _objCliente.Guardar(objCliente);
        }
        /// <summary>
        /// Guarda el objeto cliente y obtiene su Id
        /// </summary>
        /// <param name="objCliente">Licnete a guardar</param>
        public long Guardar_2(Cliente objCliente)
        {
            ClienteOAD _objCliente = new ClienteOAD();
            return _objCliente.Guardar_2(objCliente);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Cliente objCliente)
        {
            ClienteOAD _objCliente = new ClienteOAD();
            _objCliente.Eliminar(objCliente);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Cliente objCliente)
        {
            ClienteOAD _objCliente = new ClienteOAD();
            _objCliente.Actualizar(objCliente);
        }
    }
}