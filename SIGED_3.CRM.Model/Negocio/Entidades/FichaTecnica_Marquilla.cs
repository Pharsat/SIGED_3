﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class FichaTecnica_Marquilla
    {
        private byte[] _ImagenMarquilla;
        public long? _Id_Miembro_Salva;
        public string _NombreImagen;
        public string _Extencion;
        public byte[] ImagenMarquilla
        {
            get
            {
                if (_ImagenMarquilla == null)
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
                    return _ImagenMarquilla;
                }
            }
            set
            {
                _ImagenMarquilla = value;
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
    }
}