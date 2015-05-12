using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Logica;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class FichaTecnica_PasosDeConfeccion
    {
        public string NombreRecurso
        {
            get
            {
                if (Id_Recurso.HasValue)
                {
                    return new RecursoLN().Seleccionar_Id(Id_Recurso.Value).Nombre;
                }
                else
                {
                    return "-- Sin registro --";
                }
            }
        }
        public string Descrion_HTML
        {
            get
            {
                return Descripcion.Replace("\r\n", "<br />");
            }
        }
    }
}
