using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class LP_MiembrosResult
    {
        public string Cumpleanos
        {
            get
            {
                if (FechaDeNacimiento.HasValue)
                {
                    return FechaDeNacimiento.Value.ToString("dd/MM");
                }
                else
                {
                    return "Pendiente ;(";
                }
            }
            set
            {
            }
        }
    }
}
