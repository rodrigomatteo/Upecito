using Upecito.Data;
using Upecito.Data.Implementation;
using Upecito.Interface;
using Upecito.Model;

namespace Upecito.Business
{
    public class SolicitudManager : ISolicitud
    {
        public Solicitud CrearSolicitud(int idCanalAtencion, int idAlumno, int? idCurso, string consulta, string usuario)
        {
            return new SolicitudData().Crear(idCanalAtencion, idAlumno, idCurso, consulta, usuario);
        }

        public Solicitud ActualizarEstado(long idSolicitud, string estado)
        {
            return new Solicitud();
        }

        public Solicitud ActualizarRespuesta(long idSolicitud, string respuesta)
        {
            return new Solicitud();
        }

    }
}
