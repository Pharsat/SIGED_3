using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class Color
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
    }
}
