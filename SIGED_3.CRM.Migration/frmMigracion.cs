using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace SIGED_3.CRM.Migration
{
    public partial class frmMigracion : Form
    {
        public frmMigracion()
        {
            InitializeComponent();
        }

        public static string EncriptarContrasena(string Texto)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(Texto);
            byte[] hash = sha1.ComputeHash(inputBytes);
            return Convert.ToBase64String(hash);
        }

        private void frmMigracion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NewDataContext objNew = new NewDataContext())
            {
                using (OldDataContext objOld = new OldDataContext())
                {
                    //Fichas Tecnicas
                    List<tbl_FichaTecnica> lstFichasConImagenes = objOld.tbl_FichaTecnica.Where(p => p.Display != null).ToList();
                    foreach (tbl_FichaTecnica objFichaVieja in lstFichasConImagenes)
                    {
                        Imagenes objImagen = new Imagenes();
                        objImagen.Image = objFichaVieja.Display;
                        objImagen.Tipo = objFichaVieja.Tipo;
                        objImagen.NombreOriginal = "Migración";
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();

                        objNew.Imagenes.InsertOnSubmit(objImagen);
                        objNew.SubmitChanges();
                        long Id_Imagen = objNew.Imagenes.Max(p => p.Id);

                        FichaTecnica objFichaNueva = objNew.FichaTecnica.Single(p => p.Id == objFichaVieja.Id);
                        objFichaNueva.Id_Imagen = Id_Imagen;

                        objNew.SubmitChanges();
                    }

                    //Marquillas
                    List<tbl_FichaTecnica_Marquilla> lstFichasMarquillaConImagenes = objOld.tbl_FichaTecnica_Marquilla.Where(p => p.Display != null).ToList();
                    foreach (tbl_FichaTecnica_Marquilla objFichaMarquillaVieja in lstFichasMarquillaConImagenes)
                    {
                        Imagenes objImagen = new Imagenes();
                        objImagen.Image = objFichaMarquillaVieja.Display;
                        objImagen.Tipo = objFichaMarquillaVieja.imgTipo;
                        objImagen.NombreOriginal = "Migración";
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();

                        objNew.Imagenes.InsertOnSubmit(objImagen);
                        objNew.SubmitChanges();
                        long Id_Imagen = objNew.Imagenes.Max(p => p.Id);

                        FichaTecnica_Marquilla objFichaNueva = objNew.FichaTecnica_Marquilla.Single(p => p.Id == objFichaMarquillaVieja.Id);
                        objFichaNueva.Id_Imagen = Id_Imagen;

                        objNew.SubmitChanges();
                    }


                    //ProcesosDetallados
                    List<tbl_FichaTecnica_ProcesosDetallados> lstFichasProcesosDetalladosConImagenes = objOld.tbl_FichaTecnica_ProcesosDetallados.Where(p => p.Display != null).ToList();
                    foreach (tbl_FichaTecnica_ProcesosDetallados objFichaProcesosDetalladosVieja in lstFichasProcesosDetalladosConImagenes)
                    {
                        Imagenes objImagen = new Imagenes();
                        objImagen.Image = objFichaProcesosDetalladosVieja.Display;
                        objImagen.Tipo = objFichaProcesosDetalladosVieja.imgTipo;
                        objImagen.NombreOriginal = "Migración";
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();

                        objNew.Imagenes.InsertOnSubmit(objImagen);
                        objNew.SubmitChanges();
                        long Id_Imagen = objNew.Imagenes.Max(p => p.Id);

                        FichaTecnica_ProcesosDetallados objFichaNueva = objNew.FichaTecnica_ProcesosDetallados.Single(p => p.Id == objFichaProcesosDetalladosVieja.Id);
                        objFichaNueva.Id_Imagen = Id_Imagen;

                        objNew.SubmitChanges();
                    }

                    //GrupoDeMiembros.
                    List<tbl_GrupoDeMiembros> lstGruposDeMiembrosConImagenes = objOld.tbl_GrupoDeMiembros.Where(p => p.Display != null).ToList();
                    foreach (tbl_GrupoDeMiembros objGrupoDeMiembrosVieja in lstGruposDeMiembrosConImagenes)
                    {
                        Imagenes objImagen = new Imagenes();
                        objImagen.Image = objGrupoDeMiembrosVieja.Display;
                        objImagen.Tipo = objGrupoDeMiembrosVieja.Tipo;
                        objImagen.NombreOriginal = "Migración";
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();

                        objNew.Imagenes.InsertOnSubmit(objImagen);
                        objNew.SubmitChanges();
                        long Id_Imagen = objNew.Imagenes.Max(p => p.Id);

                        GrupoDeMiembros objFichaNueva = objNew.GrupoDeMiembros.Single(p => p.Id == objGrupoDeMiembrosVieja.Id);
                        objFichaNueva.Id_Imagen = Id_Imagen;

                        objNew.SubmitChanges();
                    }

                    //Miembros
                    List<tbl_Miembro> lstMiembrosConImagenes = objOld.tbl_Miembro.Where(p => p.Display != null).ToList();
                    foreach (tbl_Miembro objMiembrosVieja in lstMiembrosConImagenes)
                    {
                        Imagenes objImagen = new Imagenes();
                        objImagen.Image = objMiembrosVieja.Display;
                        objImagen.Tipo = objMiembrosVieja.Tipo;
                        objImagen.NombreOriginal = "Migración";
                        objImagen.Fecha_Salvado = DateTime.Now.ToUniversalTime();

                        objNew.Imagenes.InsertOnSubmit(objImagen);
                        objNew.SubmitChanges();
                        long Id_Imagen = objNew.Imagenes.Max(p => p.Id);

                        Miembro objMiembro = objNew.Miembro.Single(p => p.Id == objMiembrosVieja.Id);
                        objMiembro.Id_Imagen = Id_Imagen;

                        objNew.SubmitChanges();
                    }

                    List<Color> lstColores = objNew.Color.ToList();
                    lstColores.ForEach(p => p.Color1 = "ffffff");
                    objNew.SubmitChanges();

                    List<tbl_Miembro> lstMiembros = objOld.tbl_Miembro.ToList();

                    foreach (tbl_Miembro objMiembro in lstMiembros)
                    {
                        Cuentas objCuenta = new Cuentas();
                        objCuenta.Usuario = objMiembro.Usuario;
                        objCuenta.Contrasena = EncriptarContrasena(objMiembro.Contrasena);
                        objCuenta.dtFechaApertura = DateTime.Now.ToUniversalTime();
                        objCuenta.EstadoDeActivacion = true;
                        objCuenta.Id_Miembro = objMiembro.Id;
                        objCuenta.Id_GrupoDeMiembros = objMiembro.Id_GrupoDeMiembros;
                        objNew.Cuentas.InsertOnSubmit(objCuenta);
                    }
                    objNew.SubmitChanges();

                    List<Venta_Detalle> lstVentasDetalle = objNew.Venta_Detalle.ToList();
                    foreach (Venta_Detalle objVentaDetalle in lstVentasDetalle)
                    {
                        tbl_Venta objVenta = objOld.tbl_Venta.Single(p => p.Id == objVentaDetalle.Id_Venta);
                        objVentaDetalle.Id_Bodega = objVenta.Id_Bodega;
                    }
                    objNew.SubmitChanges();

                    List<tbl_Pedido> lstPedidos = objOld.tbl_Pedido.ToList();
                    foreach (tbl_Pedido objPedido in lstPedidos)
                    {
                        Pedido objPedidoNew = objNew.Pedido.Single(p => p.Id == objPedido.Id);
                        objPedidoNew.Estado = 5;
                        switch (objPedido.TipoPrecioVenta)
                        {
                            case "PU":
                                objPedidoNew.TipoPrecioVenta = 1;
                                break;
                            case "DI":
                                objPedidoNew.TipoPrecioVenta = 3;
                                break;
                            case "ES":
                                objPedidoNew.TipoPrecioVenta = 2;
                                break;
                        }
                        objNew.SubmitChanges();
                    }


                    List<tbl_Pedido_Detalle> lstPedidosDetalle = objOld.tbl_Pedido_Detalle.ToList();
                    for (int i = 0; i < lstPedidosDetalle.Count(); i++)
                    {
                        FichaTecnica_Color objFichaTecnicaColor = objNew.FichaTecnica_Color.Single(p => p.Id == lstPedidosDetalle[i].Id_FichaTecnica_Color);
                        if (objNew.Recurso.Where(p => p.Id_FichaTecnica == objFichaTecnicaColor.Id_FichaTecnica && p.Id_Color == objFichaTecnicaColor.Id_Color && p.Talla == lstPedidosDetalle[i].Talla).ToList().Count == 1)
                        {
                            Recurso objRecurso = objNew.Recurso.Single(p => p.Id_FichaTecnica == objFichaTecnicaColor.Id_FichaTecnica && p.Id_Color == objFichaTecnicaColor.Id_Color && p.Talla == lstPedidosDetalle[i].Talla);

                            Pedido_Detalle objPedidoDetalleNew = objNew.Pedido_Detalle.Single(p => p.Id == lstPedidosDetalle[i].Id);
                            objPedidoDetalleNew.Id_Recurso = objRecurso.Id;
                            objPedidoDetalleNew.Id_UnidadDeMedida = objRecurso.Id_UnidadDeMedida;
                            objNew.SubmitChanges();
                        }
                        else if (objNew.Recurso.Where(p => p.Id_FichaTecnica == objFichaTecnicaColor.Id_FichaTecnica && p.Id_Color == objFichaTecnicaColor.Id_Color && p.Talla == lstPedidosDetalle[i].Talla).ToList().Count > 1)
                        {
                            Recurso objRecurso = objNew.Recurso.Where(p => p.Id_FichaTecnica == objFichaTecnicaColor.Id_FichaTecnica && p.Id_Color == objFichaTecnicaColor.Id_Color && p.Talla == lstPedidosDetalle[i].Talla).ToList()[0];

                            Pedido_Detalle objPedidoDetalleNew = objNew.Pedido_Detalle.Single(p => p.Id == lstPedidosDetalle[i].Id);
                            objPedidoDetalleNew.Id_Recurso = objRecurso.Id;
                            objPedidoDetalleNew.Id_UnidadDeMedida = objRecurso.Id_UnidadDeMedida;
                            objNew.SubmitChanges();
                        }
                    }

                    List<OrdenesDeTrabajo> lstOrdenes = objNew.OrdenesDeTrabajo.ToList();
                    foreach (OrdenesDeTrabajo objOrden in lstOrdenes)
                    {
                        objOrden.Id_Estado = 5;
                        objOrden.FechaInicio = objOrden.FechaGeneracion;
                    }
                    objNew.SubmitChanges();

                    List<OrdenesDeTrabajo_Recursos> lstOrdenesRecursos = objNew.OrdenesDeTrabajo_Recursos.ToList();
                    foreach (OrdenesDeTrabajo_Recursos objOrdenRecurso in lstOrdenesRecursos)
                    {
                        Pedido_Detalle objPedidoDetalle = objNew.Pedido_Detalle.Single(p => p.Id == objOrdenRecurso.Id_Pedido_Detalle);
                        objOrdenRecurso.Id_Recurso = objPedidoDetalle.Id_Recurso;
                        if (objPedidoDetalle.Id_Recurso.HasValue)
                        {
                            Recurso objRecurso = objNew.Recurso.Single(p => p.Id == objPedidoDetalle.Id_Recurso);
                            objOrdenRecurso.Id_UnidadDeMedida = objRecurso.Id_UnidadDeMedida;
                        }
                    }
                    objNew.SubmitChanges();

                    objNew.Cuentas.ToList().ForEach(p => p.dtFechaCierre = DateTime.Now.ToUniversalTime().AddYears(1));
                    objNew.SubmitChanges();

                    List<tbl_Costo> lstCostos = objOld.tbl_Costo.ToList();
                    foreach (tbl_Costo objCosto in lstCostos)
                    {
                        FichaTecnica_Color objFichaTecnicaColor = objNew.FichaTecnica_Color.Single(p => p.Id == objCosto.Id_FichaTecnica_Color);
                        List<Recurso> lstRecursos = objNew.Recurso.Where(p => p.Id_FichaTecnica == objFichaTecnicaColor.Id_FichaTecnica && p.Id_Color == objFichaTecnicaColor.Id_Color).ToList();
                        if (lstRecursos.Count > 0)
                        {
                            Costo objCostoN = objNew.Costo.Single(p => p.Id == objCosto.Id);
                            objCostoN.Id_Recurso = lstRecursos[0].Id;
                            objNew.SubmitChanges();
                        }
                    }
                }
            }

        }
    }
}
