using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ClienteOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Cliente> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Cliente.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Clientes que esten habilitados
        /// </summary>
        /// <returns>Lista de registros tipo cliente</returns>
        public List<Cliente> Seleccionar_All_Activos(long? Id_GrupoDeMiembros, long? Id_Cliente)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (Id_Cliente.HasValue)
                {
                    return dc.Cliente.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros || p.Id == Id_Cliente.Value).OrderBy(p => p.Nombre).ToList();
                }
                else
                {
                    return dc.Cliente.Where(p => p.Estado == true && p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).OrderBy(p => p.Nombre).ToList();
                }
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Cliente Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Cliente.Single(p => p.Id == Id);
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Clientes(estado, identificacion, id_GrupoDeMiembros, nombre).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Cliente objCliente)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Cliente.InsertOnSubmit(objCliente);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto cliente y obtiene su Id
        /// </summary>
        /// <param name="objCliente">Licnete a guardar</param>
        public long Guardar_2(Cliente objCliente)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Cliente.InsertOnSubmit(objCliente);
                dc.SubmitChanges();
                return dc.Cliente.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Cliente objCliente)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Cliente _objCliente = dc.Cliente.Single(p => p.Id == objCliente.Id);
                dc.Cliente.DeleteOnSubmit(_objCliente);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Cliente objCliente)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Cliente _objCliente = dc.Cliente.Single(p => p.Id == objCliente.Id);
                _objCliente.Id = objCliente.Id;
                _objCliente.Id_GrupoDeMiembros = objCliente.Id_GrupoDeMiembros;
                _objCliente.Id_TipoDeDocumento = objCliente.Id_TipoDeDocumento;
                _objCliente.Id_Pais = objCliente.Id_Pais;
                _objCliente.Id_Provincia = objCliente.Id_Provincia;
                _objCliente.Id_Ciudad = objCliente.Id_Ciudad;
                _objCliente.Identificacion = objCliente.Identificacion;
                _objCliente.Nombre = objCliente.Nombre;
                _objCliente.Telefono_1 = objCliente.Telefono_1;
                _objCliente.Telefono_2 = objCliente.Telefono_2;
                _objCliente.Direccion = objCliente.Direccion;
                _objCliente.Email = objCliente.Email;
                _objCliente.PrecioQueSeVende = objCliente.PrecioQueSeVende;
                _objCliente.RazonSocial = objCliente.RazonSocial;
                _objCliente.Estado = objCliente.Estado;
                dc.SubmitChanges();
            }
        }
    }
}