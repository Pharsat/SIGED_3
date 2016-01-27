using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;
using System.Data;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class FichaTecnicaLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica> Seleccionar_All()
        {
            FichaTecnicaOAD objFichaTecnica = new FichaTecnicaOAD();
            return objFichaTecnica.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica Seleccionar_Id(long Id)
        {
            FichaTecnicaOAD objFichaTecnica = new FichaTecnicaOAD();
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
            FichaTecnicaOAD objFichaTecnica = new FichaTecnicaOAD();
            return objFichaTecnica.Seleccionar_LP(id_GrupoDeMiembros, codigo, tipoPrenda);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica objFichaTecnica)
        {
            FichaTecnicaOAD _objFichaTecnica = new FichaTecnicaOAD();
            _objFichaTecnica.Guardar(objFichaTecnica);
        }
        /// <summary>
        /// Guarda la fucha tecnica y obtiene su id
        /// </summary>
        /// <param name="objFichaTecnica">objeto ficha tecnica</param>
        /// <returns>identificador de la ficha</returns>
        public long Guardar_2(FichaTecnica objFichaTecnica)
        {
            try
            {
                long Id;
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Imagenes objImagen;
                    if (objFichaTecnica.ImagenPrenda != null && objFichaTecnica.Id_Miembro_Salva.HasValue)
                    {
                        if (!objFichaTecnica.Id_Imagen.HasValue)
                        {
                            objImagen = new Imagenes();
                        }
                        else
                        {
                            objImagen = new ImagenesOAD().Seleccionar_Id(objFichaTecnica.Id_Imagen.Value)[0];
                        }
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();
                        objImagen.Id_Miembro_Salvado = objFichaTecnica.Id_Miembro_Salva.Value;
                        objImagen.Image = objFichaTecnica.ImagenPrenda;
                        objImagen.NombreOriginal = objFichaTecnica.NombreImagen;
                        objImagen.Tipo = objFichaTecnica.Extencion;
                        if (!objFichaTecnica.Id_Imagen.HasValue)
                        {
                            objFichaTecnica.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                        }
                        else
                        {
                            new ImagenesOAD().Actualizar(objImagen);
                        }
                    }
                    FichaTecnicaOAD _objFichaTecnica = new FichaTecnicaOAD();
                    Id = _objFichaTecnica.Guardar_2(objFichaTecnica);
                    CrearRecursos(Id, "Ref: " + objFichaTecnica.Codigo + " || " + objFichaTecnica.TipoPrenda);
                    objTransaccion.Complete();
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
        public void Eliminar(FichaTecnica objFichaTecnica)
        {
            FichaTecnicaOAD _objFichaTecnica = new FichaTecnicaOAD();
            _objFichaTecnica.Eliminar(objFichaTecnica);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica objFichaTecnica)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Imagenes objImagen;
                    if (objFichaTecnica.ImagenPrenda != null && objFichaTecnica.Id_Miembro_Salva.HasValue)
                    {
                        if (objFichaTecnica.Id_Imagen.HasValue)
                        {
                            objImagen = new ImagenesOAD().Seleccionar_Id(objFichaTecnica.Id_Imagen.Value)[0];
                        }
                        else
                        {
                            objImagen = new Imagenes();
                        }
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();
                        objImagen.Id_Miembro_Salvado = objFichaTecnica.Id_Miembro_Salva.Value;
                        objImagen.Image = objFichaTecnica.ImagenPrenda;
                        objImagen.NombreOriginal = objFichaTecnica.NombreImagen;
                        objImagen.Tipo = objFichaTecnica.Extencion;
                        if (!objFichaTecnica.Id_Imagen.HasValue)
                        {
                            objFichaTecnica.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                        }
                        else
                        {
                            new ImagenesOAD().Actualizar(objImagen);
                        }
                    }
                    CrearRecursos(objFichaTecnica.Id, "Ref: " + objFichaTecnica.Codigo + " || " + objFichaTecnica.TipoPrenda);
                    FichaTecnicaOAD _objFichaTecnica = new FichaTecnicaOAD();
                    _objFichaTecnica.Actualizar(objFichaTecnica);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CrearRecursos(long Id_Ficha, string Nombre)
        {
            List<FichaTecnica_Color> lstColores = new FichaTecnica_ColorLN().Seleccionar_By_FichaTecnica(Id_Ficha);
            List<FichaTecnica_Talla> lstTallas = new FichaTecnica_TallaLN().Seleccionar_By_FichaTecnica(Id_Ficha);
            foreach (FichaTecnica_Color objFichaTecnica_Color in lstColores)
            {
                foreach (FichaTecnica_Talla objFichaTecnica_Talla in lstTallas)
                {
                    Recurso objRecurso = new Recurso();
                    objRecurso.Id_GrupoDeMiembros = SessionManager.Id_GrupoDeMiembros;
                    objRecurso.Id_Color = objFichaTecnica_Color.Id_Color;
                    objRecurso.Id_FichaTecnica = Id_Ficha;
                    objRecurso.Id_TipoDeRecurso = (long)TipoDeRecurso_Enum.ProductoTerminado;
                    objRecurso.Id_UnidadDeMedida = (long)UnidadDeMedida_Enum.UND;
                    objRecurso.Talla = objFichaTecnica_Talla.Talla;
                    objRecurso.Nombre = Nombre;
                    objRecurso.Estado = true;
                    if (!new RecursoOAD().Verificar_Existencia_Recurso(objRecurso.Id_Color, objRecurso.Talla, objRecurso.Id_FichaTecnica))
                    {
                        RecursoOAD _objRecurso = new RecursoOAD();
                        _objRecurso.Guardar(objRecurso);
                    }
                    else
                    {
                        Entidades.Recurso objRecurso2 = new RecursoOAD().Tomar_Existencia_Recurso(objRecurso.Id_Color, objRecurso.Talla, objRecurso.Id_FichaTecnica);
                        objRecurso2.Nombre = Nombre;
                        RecursoOAD _objRecurso = new RecursoOAD();
                        _objRecurso.Actualizar(objRecurso2);
                    }
                }
            }
        }

        public DataTable Impresion_FichaTecnica(long? Id_Ficha)
        {
            FichaTecnicaOAD _objGrupoDeMiembros = new FichaTecnicaOAD();
            return _objGrupoDeMiembros.Impresion_FichaTecnica(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Colores(long? Id_Ficha)
        {
            FichaTecnicaOAD _objGrupoDeMiembros = new FichaTecnicaOAD();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Colores(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Hilos(long? Id_Ficha)
        {
            FichaTecnicaOAD _objGrupoDeMiembros = new FichaTecnicaOAD();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Hilos(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Marquillas(long? Id_Ficha)
        {
            FichaTecnicaOAD _objGrupoDeMiembros = new FichaTecnicaOAD();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Marquillas(Id_Ficha);
        }
        public DataTable Impresion_PasosDeConfeccion(long? Id_Ficha)
        {
            FichaTecnicaOAD _objGrupoDeMiembros = new FichaTecnicaOAD();
            return _objGrupoDeMiembros.Impresion_PasosDeConfeccion(Id_Ficha);
        }
        public DataTable Impresion_ProcesosDetallados(long? Id_Ficha)
        {
            FichaTecnicaOAD _objGrupoDeMiembros = new FichaTecnicaOAD();
            return _objGrupoDeMiembros.Impresion_ProcesosDetallados(Id_Ficha);
        }
        public DataTable Impresion_FichaTecnica_Tallas(long? Id_Ficha)
        {
            FichaTecnicaOAD _objGrupoDeMiembros = new FichaTecnicaOAD();
            return _objGrupoDeMiembros.Impresion_FichaTecnica_Tallas(Id_Ficha);
        }
    }
}