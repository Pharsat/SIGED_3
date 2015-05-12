using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class ProcesoDeFabricacion
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
        public string DescripcionHTML
        {
            get
            {
                return Descripcion.Replace("\r\n", "<br />");
            }
        }
    }
}
