﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public class ParametrosBD
    {
        public ParametrosBD(string Nombre_, object Valor_)
        {
            Nombre = Nombre_;
            Valor = Valor_;
        }

        public string Nombre { get; set; }
        public object Valor { get; set; }
    }
}
