using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Logica;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class FichaTecnica_Color
    {
        public string Nombre
        {
            get
            {
                if (Id_Color.HasValue)
                {
                    return new ColorLN().Seleccionar_Id(Id_Color.Value).Nombre;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string Color1
        {
            get
            {
                if (Id_Color.HasValue)
                {
                    return new ColorLN().Seleccionar_Id(Id_Color.Value).Color1;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
    }
}
