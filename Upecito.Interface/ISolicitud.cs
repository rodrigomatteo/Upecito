using Upecito.Model;

namespace Upecito.Interface
{
    public interface ISolicitud
    {
        Solicitud CrearSolicitud(int idCanalAtencion, int idAlumno, int? idCurso, string consulta, string usuario);
        Solicitud ActualizarEstado(long idSolicitud, string estado);
        Solicitud ActualizarRespuesta(long idSolicitud, string respuesta);
    }
}
