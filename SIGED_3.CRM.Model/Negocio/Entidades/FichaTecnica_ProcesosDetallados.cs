using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Negocio.Logica;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class FichaTecnica_ProcesosDetallados
    {
        private byte[] _ImagenProceso;
        public long? _Id_Miembro_Salva;
        public string _NombreImagen;
        public string _Extencion;
        public byte[] ImagenProceso
        {
            get
            {
                if (_ImagenProceso == null)
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
                    return _ImagenProceso;
                }
            }
            set
            {
                _ImagenProceso = value;
            }
        }
        public long? Id_Miembro_Salva
        {
            get
            {
                return _Id_Miembro_Salva;
            }
            set
            {
                _Id_Miembro_Salva = value;
            }
        }
        public string NombreImagen
        {
            get
            {
                return _NombreImagen;
            }
            set
            {
                _NombreImagen = value;
            }
        }
        public string Extencion
        {
            get
            {
                return _Extencion;
            }
            set
            {
                _Extencion = value;
            }
        }
        public string DescripcionHTML
        {
            get
            {
                return Descripcion.Replace("\r\n", "<br />");
            }
        }
        public string Proceso
        {
            get
            {
                if (Id_Proceso.HasValue)
                {
                    return new ProcesoDeFabricacionLN().Seleccionar_Id(Id_Proceso.Value).DescripcionHTML;
                }
                else
                {
                    return "-- Sin registro --";
                }
            }
        }
    }
}
