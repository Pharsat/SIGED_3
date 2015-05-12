using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
namespace SIGED_3.CRM.Model.Util.Genericos
{
    public class Genericos
    {
        public decimal? ConvercionDeUnidadesValor(UnidadDeMedida AConvertir, decimal ValorAConvertir, UnidadDeMedida Origen)
        {
            if (Origen.Tipo == AConvertir.Tipo)
            {
                if (AConvertir.Posicionamiento == Origen.Posicionamiento)
                {
                    return ValorAConvertir;
                }
                else if (AConvertir.Posicionamiento > Origen.Posicionamiento)
                {
                    for (int i = AConvertir.Posicionamiento.Value; i > Origen.Posicionamiento; i--)
                    {
                        ValorAConvertir = (ValorAConvertir / AConvertir.Base.Value);
                    }
                    return ValorAConvertir;
                }
                else
                {
                    for (int i = AConvertir.Posicionamiento.Value; i < Origen.Posicionamiento; i++)
                    {
                        ValorAConvertir = (ValorAConvertir * AConvertir.Base.Value);
                    }
                    return ValorAConvertir;
                }
            }
            else
            {
                return null;
            }
        }
        public string ValorATexto(decimal value)
        {
            string str = String.Empty;
            value = Math.Truncate(value);
            if (value == 0m)
            {
                return "CERO";
            }
            if (value == 1m)
            {
                return "UNO";
            }
            if (value == 2m)
            {
                return "DOS";
            }
            if (value == 3m)
            {
                return "TRES";
            }
            if (value == 4m)
            {
                return "CUATRO";
            }
            if (value == 5m)
            {
                return "CINCO";
            }
            if (value == 6m)
            {
                return "SEIS";
            }
            if (value == 7m)
            {
                return "SIETE";
            }
            if (value == 8m)
            {
                return "OCHO";
            }
            if (value == 9m)
            {
                return "NUEVE";
            }
            if (value == 10m)
            {
                return "DIEZ";
            }
            if (value == 11m)
            {
                return "ONCE";
            }
            if (value == 12m)
            {
                return "DOCE";
            }
            if (value == 13m)
            {
                return "TRECE";
            }
            if (value == 14m)
            {
                return "CATORCE";
            }
            if (value == 15m)
            {
                return "QUINCE";
            }
            if (value < 20m)
            {
                return ("DIECI" + this.ValorATexto(value - 10m));
            }
            if (value == 20m)
            {
                return "VEINTE";
            }
            if (value < 30m)
            {
                return ("VEINTI" + this.ValorATexto(value - 20m));
            }
            if (value == 30m)
            {
                return "TREINTA";
            }
            if (value == 40m)
            {
                return "CUARENTA";
            }
            if (value == 50m)
            {
                return "CINCUENTA";
            }
            if (value == 60m)
            {
                return "SESENTA";
            }
            if (value == 70m)
            {
                return "SETENTA";
            }
            if (value == 80m)
            {
                return "OCHENTA";
            }
            if (value == 90m)
            {
                return "NOVENTA";
            }
            if (value < 100m)
            {
                return (this.ValorATexto(Math.Truncate((decimal)(value / 10m)) * 10m) + " Y " + this.ValorATexto(value % 10m));
            }
            if (value == 100m)
            {
                return "CIEN";
            }
            if (value < 200m)
            {
                return ("CIENTO " + this.ValorATexto(value - 100m));
            }
            if (((value == 200m) || (value == 300m)) || (((value == 400m) || (value == 600m)) || (value == 800m)))
            {
                return (this.ValorATexto(Math.Truncate((decimal)(value / 100m))) + "CIENTOS");
            }
            if (value == 500m)
            {
                return "QUINIENTOS";
            }
            if (value == 700m)
            {
                return "SETECIENTOS";
            }
            if (value == 900m)
            {
                return "NOVECIENTOS";
            }
            if (value < 1000m)
            {
                return (this.ValorATexto(Math.Truncate((decimal)(value / 100m)) * 100m) + " " + this.ValorATexto(value % 100m));
            }
            if (value == 1000m)
            {
                return "MIL";
            }
            if (value < 2000m)
            {
                return ("MIL " + this.ValorATexto(value % 1000m));
            }
            if (value < 1000000m)
            {
                str = this.ValorATexto(Math.Truncate((decimal)(value / 1000m))) + " MIL";
                if ((value % 1000m) > 0m)
                {
                    str = str + " " + this.ValorATexto(value % 1000m);
                }
                return str;
            }
            if (value == 1000000m)
            {
                return "UN MILLON";
            }
            if (value < 2000000m)
            {
                return ("UN MILLON " + this.ValorATexto(value % 1000000m));
            }
            if (value < 1000000000000)
            {
                str = this.ValorATexto(Math.Truncate((decimal)(value / 1000000m))) + " MILLONES ";
                if ((value - (Math.Truncate((decimal)(value / 1000000m)) * 1000000m)) > 0m)
                {
                    str = str + " " + this.ValorATexto(value - (Math.Truncate((decimal)(value / 1000000m)) * 1000000m));
                }
                return str;
            }
            if (value == 1000000000000)
            {
                return "UN BILLON";
            }
            if (value < 2000000000000)
            {
                return ("UN BILLON " + this.ValorATexto(value - (Math.Truncate((decimal)(value / 1000000000000)) * 1000000000000)));
            }
            str = this.ValorATexto(Math.Truncate((decimal)(value / 1000000000000))) + " BILLONES";
            if ((value - (Math.Truncate((decimal)(value / 1000000000000)) * 1000000000000)) > 0m)
            {
                str = str + " " + this.ValorATexto(value - (Math.Truncate((decimal)(value / 1000000000000)) * 1000000000000));
            }
            return str;
        }
        public string AgregarBRs(string Texto)
        {
            return Texto.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }
        public void ConfigurarPermisosLista(ImageButton btnNuevo, ImageButton btnEliminar, ImageButton btnBuscar, DataControlField clmEditar, int Modulo)
        {
            if (btnNuevo != null)
            {
                btnNuevo.Visible = new PermisosFachada().PermisosDeUsuario(Modulo).CrearRegistro.Value;
            }
            if (btnEliminar != null)
            {
                btnEliminar.Visible = new PermisosFachada().PermisosDeUsuario(Modulo).EliminarRegistro.Value;
            }
            if (btnBuscar != null)
            {
                btnBuscar.Visible = new PermisosFachada().PermisosDeUsuario(Modulo).ConsultarLista.Value;
            }
            if (clmEditar != null)
            {
                clmEditar.Visible = new PermisosFachada().PermisosDeUsuario(Modulo).ConsultarDetalle.Value;
            }
        }
        public void ConfigurarPermisosDetalle(FormView frmForma, string Crear, string Actualizar, int Modulo, int Modo)
        {
            switch (Modo)
            {
                case 1:
                    if (frmForma.CurrentMode == FormViewMode.Edit)
                    {
                        ((ImageButton)frmForma.FindControl(Actualizar)).Visible = new PermisosFachada().PermisosDeUsuario(Modulo).ActualizarDetalle.Value;
                    }
                    else if (frmForma.CurrentMode == FormViewMode.Insert)
                    {
                        ((ImageButton)frmForma.FindControl(Crear)).Visible = new PermisosFachada().PermisosDeUsuario(Modulo).CrearRegistro.Value;
                    }
                    break;
                case 2:
                    if (frmForma.CurrentMode == FormViewMode.Edit)
                    {
                        ((ImageButton)frmForma.FindControl(Actualizar)).Visible = new PermisosFachada().PermisosDeUsuario(Modulo).ActualizarDetalle.Value;
                    }
                    else if (frmForma.CurrentMode == FormViewMode.Insert)
                    {
                        ((ImageButton)frmForma.FindControl(Crear)).Visible = new PermisosFachada().PermisosDeUsuario(Modulo).ActualizarDetalle.Value;
                    }
                    break;
                default:
                    if (frmForma.CurrentMode == FormViewMode.Edit)
                    {
                        ((ImageButton)frmForma.FindControl(Actualizar)).Visible = false;
                    }
                    else if (frmForma.CurrentMode == FormViewMode.Insert)
                    {
                        ((ImageButton)frmForma.FindControl(Crear)).Visible = false;
                    }
                    break;
            }
        }
        public void ConfigurarPermisosLista(ImageButton btnActualizar, int Modulo)
        {
            if (btnActualizar != null)
            {
                btnActualizar.Visible = new PermisosFachada().PermisosDeUsuario(Modulo).ActualizarDetalle.Value;
            }
        }
    }
}
