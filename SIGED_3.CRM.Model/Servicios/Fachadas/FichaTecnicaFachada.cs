using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
using System.Data;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class FichaTecnicaFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica> Seleccionar_All()
        {
            FichaTecnicaLN objFichaTecnica = new FichaTecnicaLN();
            return objFichaTecnica.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica Seleccionar_Id(long Id)
        {
            FichaTecnicaLN objFichaTecnica = new FichaTecnicaLN();
            return objFichaTecnica.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Lista principal de fichas tecnicas.
        /// </summary>
        /// <param name="estado">estado de la ficha tecnica</param>
        /// <param name="id_GrupoDeMiembros">identificador del grupo de miembros</param>
        /// <param name="codigo">codigo de la prenda</param>
        /// <param name="tipoPrenda">tipo de prenda</param>
        /// <returns>Lista resultado de ficha tecnica</returns>
        public List<LP_FichasTecnicasResult> Seleccionar_LP(int? id_GrupoDeMiembros, string codigo, string tipoPrenda)
        {
            FichaTecnicaLN objFichaTecnica = new FichaTecnicaLN();
            return objFichaTecnica.Seleccionar_LP(id_GrupoDeMiembros, codigo, tipoPrenda);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica objFichaTecnica)
        {
            FichaTecnicaLN _objFichaTecnica = new FichaTecnicaLN();
            _objFichaTecnica.Guardar(objFichaTecnica);
        }
        /// <summary>
        /// Guarda la fucha tecnica y obtiene su id
        /// </summary>
        /// <param name="objFichaTecnica">objeto ficha tecnica</param>
        /// <returns>identificador de la ficha</returns>
        public long Guardar_2(FichaTecnica objFichaTecnica)
        {
            FichaTecnicaLN _objFichaTecnica = new FichaTecnicaLN();
            return _objFichaTecnica.Guardar_2(objFichaTecnica);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica objFichaTecnica)
        {
            FichaTecnicaLN _objFichaTecnica = new FichaTecnicaLN();
            _objFichaTecnica.Eliminar(objFichaTecnica);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica objFichaTecnica)
        {
            FichaTecnicaLN _objFichaTecnica = new FichaTecnicaLN();
            _objFichaTecnica.Actualizar(objFichaTecnica);
        }

        public DataTable Impresion_FichaTecnica(long? Id_Ficha)
        {
            FichaTecnicaLN _objGrupoDeMiembros = new FichaTecnicaLN();
            return _objGrupoDeMiembros.Impresion_FichaTecnica(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Colores(long? Id_Ficha)
        {
            FichaTecnicaLN _objGrupoDeMiembros = new FichaTecnicaLN();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Colores(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Hilos(long? Id_Ficha)
        {
            FichaTecnicaLN _objGrupoDeMiembros = new FichaTecnicaLN();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Hilos(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Marquillas(long? Id_Ficha)
        {
            FichaTecnicaLN _objGrupoDeMiembros = new FichaTecnicaLN();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Marquillas(Id_Ficha);
        }
        public DataTable Impresion_PasosDeConfeccion(long? Id_Ficha)
        {
            FichaTecnicaLN _objGrupoDeMiembros = new FichaTecnicaLN();
            return _objGrupoDeMiembros.Impresion_PasosDeConfeccion(Id_Ficha);
        }
        public DataTable Impresion_ProcesosDetallados(long? Id_Ficha)
        {
            FichaTecnicaLN _objGrupoDeMiembros = new FichaTecnicaLN();
            return _objGrupoDeMiembros.Impresion_ProcesosDetallados(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Tallas(long? Id_Ficha)
        {
            FichaTecnicaLN _objGrupoDeMiembros = new FichaTecnicaLN();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Tallas(Id_Ficha);
        }
    }
}