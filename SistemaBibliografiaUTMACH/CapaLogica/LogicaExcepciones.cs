using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaExcepciones : ApplicationException
    {
        public LogicaExcepciones(string msj, Exception original) : base(msj, original) { }

        public LogicaExcepciones(string msj) : base(msj) { }
    }
}
