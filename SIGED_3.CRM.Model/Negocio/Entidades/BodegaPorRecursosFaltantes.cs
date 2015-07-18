using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public class BodegaPorRecursosFaltantes
    {
        public Bodega Bodega { get; set; }
        public List<Recurso> Faltantes { get; set; }
        public int RecursosQueYaTieneLABodega { get; set; }
        public int RecursosQueFaltaban { get; set; }
    }
}
