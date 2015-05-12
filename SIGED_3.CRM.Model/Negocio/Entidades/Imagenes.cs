using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class Imagenes
    {
        public byte[] ImageneByte
        {
            get
            {
                if (Image != null)
                {
                    return Image.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
