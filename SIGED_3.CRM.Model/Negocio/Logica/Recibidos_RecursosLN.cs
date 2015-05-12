using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Recibidos_RecursosLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Recibidos_Recursos> Seleccionar_All()
        {
            Recibidos_RecursosOAD objRecibidos_Recursos = new Recibidos_RecursosOAD();
            return objRecibidos_Recursos.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Recibidos_Recursos Seleccionar_Id(long Id)
        {
            Recibidos_RecursosOAD objRecibidos_Recursos = new Recibidos_RecursosOAD();
            return objRecibidos_Recursos.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Recibidos_Recursos objRecibidos_Recursos)
        {
            Recibidos_RecursosOAD _objRecibidos_Recursos = new Recibidos_RecursosOAD();
            _objRecibidos_Recursos.Guardar(objRecibidos_Recursos);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Recibidos_Recursos objRecibidos_Recursos)
        {
            Recibidos_RecursosOAD _objRecibidos_Recursos = new Recibidos_RecursosOAD();
            _objRecibidos_Recursos.Eliminar(objRecibidos_Recursos);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Recibidos_Recursos objRecibidos_Recursos)
        {
            Recibidos_RecursosOAD _objRecibidos_Recursos = new Recibidos_RecursosOAD();
            _objRecibidos_Recursos.Actualizar(objRecibidos_Recursos);
        }
        public List<LS_Recibidos_RecursoResult> Seleccionar_By_Recibido_LP(long Id_Recibido)
        {
            Recibidos_RecursosOAD _objRecibidos_Recursos = new Recibidos_RecursosOAD();
            return _objRecibidos_Recursos.Seleccionar_By_Recibido_LP(Id_Recibido);
        }
    }
}