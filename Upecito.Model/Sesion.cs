using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upecito.Model
{
    public class Sesion
    {
        public long IdSesion { get; set; }
        public long IdAlumno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
