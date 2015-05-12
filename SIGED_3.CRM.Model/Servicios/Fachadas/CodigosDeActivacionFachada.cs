using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class CodigosDeActivacionFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla CodigosDeActivacion
        /// </summary>
        /// <returns>Lista de registros tipo CodigosDeActivacion</returns>
        public List<CodigosDeActivacion> Seleccionar_All()
        {
            CodigosDeActivacionLN objCodigosDeActivacion = new CodigosDeActivacionLN();
            return objCodigosDeActivacion.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla CodigosDeActivacion
        /// </summary>
        /// <param name=Id>Identificador de la CodigosDeActivacion</param>
        /// <returns>Objeto singular del tipo CodigosDeActivacion</returns>
        public List<CodigosDeActivacion> Seleccionar_Id(long Id)
        {
            CodigosDeActivacionLN objCodigosDeActivacion = new CodigosDeActivacionLN();
            return objCodigosDeActivacion.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo CodigosDeActivacion en la base de datos.
        /// </summary>
        /// <param name=objCodigosDeActivacion>Objeto CodigosDeActivacion a guardar</param>
        public void Guardar(CodigosDeActivacion objCodigosDeActivacion)
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            _objCodigosDeActivacion.Guardar(objCodigosDeActivacion);
        }
        /// <summary>
        /// Elimina un objeto del tipo CodigosDeActivacion, se recibe su Id unicamente
        /// </summary>
        /// <param name=objCodigosDeActivacion>Identificativo del(a) CodigosDeActivacion</param>
        public void Eliminar(CodigosDeActivacion objCodigosDeActivacion)
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            _objCodigosDeActivacion.Eliminar(objCodigosDeActivacion);
        }
        /// <summary>
        /// Actualiza una CodigosDeActivacion, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objCodigosDeActivacion>Objeto del tipo CodigosDeActivacion</param>
        public void Actualizar(CodigosDeActivacion objCodigosDeActivacion)
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            _objCodigosDeActivacion.Actualizar(objCodigosDeActivacion);
        }
        /// <summary>
        /// verifica un codigo de activacion en el sistema y consume un uso en caso solicitado
        /// </summary>
        /// <param name="Codigo">codigo a validar</param>
        /// <param name="ConsumirCodigo">indica si se consume un uso de este codigo o no</param>
        /// <returns>verificacion</returns>
        public bool Verificar(string Codigo, bool ConsumirCodigo)
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            return _objCodigosDeActivacion.Verificar(Codigo, ConsumirCodigo);
        }
        /// <summary>
        /// Genera el codigo con el cual se hacen las llaves para la aplicación.
        /// </summary>
        /// <param name="NumUsos">Cantidad de usos maximo permitido para esta llave</param>
        /// <returns>llave</returns>
        public string GenerarCodigo(short NumUsos, long? Id_Cuenta)
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            return _objCodigosDeActivacion.GenerarCodigo(NumUsos, Id_Cuenta);
        }

        public string GenerarCodigoCuenta(long? Id_Miembro)
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            return _objCodigosDeActivacion.GenerarCodigoCuenta(Id_Miembro);
        }

        public List<LP_CodigosDeActivacionNuevosUsuariosResult> ListaDeCodigosParaAprobar()
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            return _objCodigosDeActivacion.ListaDeCodigosParaAprobar();
        }

        public void AprobarCodigo(long Id, long Id_Cuenta)
        {
            CodigosDeActivacionLN _objCodigosDeActivacion = new CodigosDeActivacionLN();
            _objCodigosDeActivacion.AprobarCodigo(Id, Id_Cuenta);
        }
    }
}
