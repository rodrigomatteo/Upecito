using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upecito.Model
{
    public class Solicitud
    {
        public long IdSolicitud { get; set; }
        public int IdCanalAtencion { get; set; }
        public long IdAlumno { get; set; }
        public int? IdCurso { get; set; }
        public string Consulta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string LogUsuario { get; set; }
        public DateTime LogFecha { get; set; }
    }
}
