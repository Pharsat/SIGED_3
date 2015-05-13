using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Session;
using System.Data;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class GrupoDeMiembrosLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<GrupoDeMiembros> Seleccionar_All()
        {
            GrupoDeMiembrosOAD objGrupoDeMiembros = new GrupoDeMiembrosOAD();
            return objGrupoDeMiembros.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public GrupoDeMiembros Seleccionar_Id(long Id)
        {
            GrupoDeMiembrosOAD objGrupoDeMiembros = new GrupoDeMiembrosOAD();
            return objGrupoDeMiembros.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(GrupoDeMiembros objGrupoDeMiembros)
        {
            GrupoDeMiembrosOAD _objGrupoDeMiembros = new GrupoDeMiembrosOAD();
            _objGrupoDeMiembros.Guardar(objGrupoDeMiembros);
        }
        /// <summary>
        /// Guarda el objeto GrupoDeMiembros y obtiene su Id
        /// </summary>
        /// <param name="objGrupoDeMiembros">Licnete a guardar</param>
        public long Guardar_2(GrupoDeMiembros objGrupoDeMiembros)
        {
            GrupoDeMiembrosOAD _objGrupoDeMiembros = new GrupoDeMiembrosOAD();
            return _objGrupoDeMiembros.Guardar_2(objGrupoDeMiembros);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(GrupoDeMiembros objGrupoDeMiembros)
        {
            GrupoDeMiembrosOAD _objGrupoDeMiembros = new GrupoDeMiembrosOAD();
            _objGrupoDeMiembros.Eliminar(objGrupoDeMiembros);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(GrupoDeMiembros objGrupoDeMiembros)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Imagenes objImagen;
                    if (objGrupoDeMiembros.ImagenGrupo != null && objGrupoDeMiembros.Id_Miembro_Salva.HasValue)
                    {
                        if (!objGrupoDeMiembros.Id_Imagen.HasValue)
                        {
                            objImagen = new Imagenes();
                        }
                        else
                        {
                            objImagen = new ImagenesOAD().Seleccionar_Id(objGrupoDeMiembros.Id_Imagen.Value)[0];
                        }
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();
                        objImagen.Id_Miembro_Salvado = objGrupoDeMiembros.Id_Miembro_Salva.Value;
                        objImagen.Image = objGrupoDeMiembros.ImagenGrupo;
                        objImagen.NombreOriginal = objGrupoDeMiembros.NombreImagen;
                        objImagen.Tipo = objGrupoDeMiembros.Extencion;
                        if (!objGrupoDeMiembros.Id_Imagen.HasValue)
                        {
                            objGrupoDeMiembros.Id_Imagen = new ImagenesOAD().Guardar_2(objImagen);
                        }
                        else
                        {
                            new ImagenesOAD().Actualizar(objImagen);
                        }
                    }
                    GrupoDeMiembrosOAD _objGrupoDeMiembros = new GrupoDeMiembrosOAD();
                    _objGrupoDeMiembros.Actualizar(objGrupoDeMiembros);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<R_ImagenDelGrupoResult> RelatorioGrupo(long? Id_Grupo)
        {
            GrupoDeMiembrosOAD _objGrupoDeMiembros = new GrupoDeMiembrosOAD();
            return _objGrupoDeMiembros.RelatorioGrupo(Id_Grupo);
        }
        public DataTable RelatorioGrupo_Tabla(long? Id_Grupo)
        {
            GrupoDeMiembrosOAD _objGrupoDeMiembros = new GrupoDeMiembrosOAD();
            return _objGrupoDeMiembros.RelatorioGrupo_Tabla(Id_Grupo);
        }
    }
}