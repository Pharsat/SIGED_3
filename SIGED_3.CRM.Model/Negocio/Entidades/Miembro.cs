using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class Miembro
    {
        private byte[] _ImagenMiembro;
        public string NombreCompleto
        {
            get
            {
                return Nombres + " " + Apellidos;
            }
        }
        public byte[] ImagenMiembro
        {
            get
            {
                if (_ImagenMiembro == null)
                {
                    if (Id_Imagen.HasValue)
                    {
                        return new ImagenesOAD().Seleccionar_Id(Id_Imagen.Value)[0].Image.ToArray();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return _ImagenMiembro;
                }
            }
            set
            {
                _ImagenMiembro = value;
            }
        }
    }
}
