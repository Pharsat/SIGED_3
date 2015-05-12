using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class Venta
    {
        public string Miembro_Texto
        {
            get
            {
                return new MiembroOAD().Seleccionar_Id(Id_Facturador.Value).NombreCompleto;
            }
        }
    }
}
