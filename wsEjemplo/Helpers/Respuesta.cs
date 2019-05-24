using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsEjemplo.Helpers
{
    public class Respuesta
    {
        public string estatus { get; set; }
        public string conclusion { get; set; }
        public string motivo { get; set; }
        public string odt { get; set; }
        public string fechaConcluido { get; set; }
    }
}