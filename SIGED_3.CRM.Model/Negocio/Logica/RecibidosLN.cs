using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class RecibidosLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Recibidos> Seleccionar_All()
        {
            RecibidosOAD objRecibidos = new RecibidosOAD();
            return objRecibidos.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Recibidos Seleccionar_Id(long Id)
        {
            RecibidosOAD objRecibidos = new RecibidosOAD();
            return objRecibidos.Seleccionar_Id(Id);
        }
        public List<LP_RecibidosResult> Seleccionar_LP(long? estado, long? id_Cliente, long? consecutivo, DateTime? desde, DateTime? hasta)
        {
            RecibidosOAD objRecibidos = new RecibidosOAD();
            if (id_Cliente.HasValue)
            {
                if (id_Cliente.Value.ToString() == (0).ToString())
                {
                    id_Cliente = null;
                }
            }
            return objRecibidos.Seleccionar_LP(estado, id_Cliente, consecutivo, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Recibidos objRecibidos)
        {
            RecibidosOAD _objRecibidos = new RecibidosOAD();
            _objRecibidos.Guardar(objRecibidos);
        }
        public long Guardar_2(Recibidos objRecibido)
        {
            try
            {
                long Id;
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    RecibidosOAD _objRecibidos = new RecibidosOAD();
                    objRecibido.Consecutivo = new ConsecutivosLN().TomarConsecutivo((long)Modulo_Enum.Recibidos, objRecibido.Id_GrupoDeMiembros.Value);
                    objRecibido.Id_Estado = (long)EstadosDelProceso_Enum.REGIS;
                    objRecibido.Id_Receptor = SessionManager.Id_Miembro.Value;
                    Id = _objRecibidos.Guardar_2(objRecibido);
                    objTransacion.Complete();
                }
                return Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Recibidos objRecibidos)
        {
            RecibidosOAD _objRecibidos = new RecibidosOAD();
            _objRecibidos.Eliminar(objRecibidos);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Recibidos objRecibidos)
        {
            RecibidosOAD _objRecibidos = new RecibidosOAD();
            _objRecibidos.Actualizar(objRecibidos);
        }
        public void IncluirARecibidosOrdenesDetalles(long Id_OrdenDeTrabajo, long Id_Recibido)
        {
            try
            {
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    List<OrdenesDeTrabajo_Recursos> lstOrdenDeTrabajoRecurso = new OrdenesDeTrabajo_RecursosOAD().Seleccionar_By_OrdenDeTrabajo(Id_OrdenDeTrabajo).ToList();
                    foreach (OrdenesDeTrabajo_Recursos objOrdenDeTrabajoRecurso in lstOrdenDeTrabajoRecurso)
                    {
                        new Recibidos_RecursosOAD().IncluirARecibidoOrdenesDetalles(objOrdenDeTrabajoRecurso, Id_Recibido);
                    }
                    objTransacion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}