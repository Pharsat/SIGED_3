using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class FichaTecnica_TallaLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Talla> Seleccionar_All()
        {
            FichaTecnica_TallaOAD objFichaTecnica_Talla = new FichaTecnica_TallaOAD();
            return objFichaTecnica_Talla.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Talla Seleccionar_Id(long Id)
        {
            FichaTecnica_TallaOAD objFichaTecnica_Talla = new FichaTecnica_TallaOAD();
            return objFichaTecnica_Talla.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae una lista de fichatecnica Talla por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de Tallaes</returns>
        public List<FichaTecnica_Talla> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            FichaTecnica_TallaOAD objFichaTecnica_Talla = new FichaTecnica_TallaOAD();
            return objFichaTecnica_Talla.Seleccionar_By_FichaTecnica(Id_FichaTecnica);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Talla objFichaTecnica_Talla)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    FichaTecnica_TallaOAD _objFichaTecnica_Talla = new FichaTecnica_TallaOAD();
                    _objFichaTecnica_Talla.Guardar(objFichaTecnica_Talla);
                    FichaTecnicaLN objFicha = new FichaTecnicaLN();
                    objFicha.CrearRecursos(objFichaTecnica_Talla.Id_FichaTecnica.Value);
                    objTransaccion.Complete();
                }
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
        public void Eliminar(FichaTecnica_Talla objFichaTecnica_Talla)
        {
            FichaTecnica_TallaOAD _objFichaTecnica_Talla = new FichaTecnica_TallaOAD();
            _objFichaTecnica_Talla.Eliminar(objFichaTecnica_Talla);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Talla objFichaTecnica_Talla)
        {
            FichaTecnica_TallaOAD _objFichaTecnica_Talla = new FichaTecnica_TallaOAD();
            _objFichaTecnica_Talla.Actualizar(objFichaTecnica_Talla);
        }
    }
}