using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosExepciones : ApplicationException
    {
        public DatosExepciones(string msj, Exception original) : base(msj, original){}

        public DatosExepciones(string msj) : base(msj) { }
    }
}
