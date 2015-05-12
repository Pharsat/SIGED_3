using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class Proveedor
    {
        public bool EstadoInv
        {
            get
            {
                return !Estado.Value;
            }
            set
            {
            }
        }
        public bool ProveedorPpalInv
        {
            get
            {
                return !ProveedorPrincipal.Value;
            }
            set
            {
            }
        }
    }
}
