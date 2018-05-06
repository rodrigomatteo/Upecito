using Upecito.Model;

namespace Upecito.Interface
{
    public interface ISolicitud
    {
        Solicitud CrearSolicitud(int idCanalAtencion, int idAlumno, int? idCurso, string consulta, string usuario);
        Solicitud Actualizar(long idSolicitud, long? idIntencion, string solucion, string estado, string usuario);
    }
}
