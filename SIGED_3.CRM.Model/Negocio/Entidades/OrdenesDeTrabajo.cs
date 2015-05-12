using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Negocio.Logica;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class OrdenesDeTrabajo
    {
        public string Miembro_Texto
        {
            get
            {
                return new MiembroOAD().Seleccionar_Id(Id_Solicitante.Value).NombreCompleto;
            }
        }
        public string Estado_Texto
        {
            get
            {
                return new EstadosDelProcesoLN().Seleccionar_Id(Id_Estado.Value).Descripcion;
            }
        }
    }
}
