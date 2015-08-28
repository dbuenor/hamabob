using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_Hamma_Beads.Librerias
{
    public class cExcepcionControlada : System.Exception
    {
        public cExcepcionControlada(string Mensaje, System.Exception ex) : base(Mensaje, ex)
        {

        }
    }
}
