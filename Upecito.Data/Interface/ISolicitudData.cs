using Upecito.Model;

namespace Upecito.Data.Interface
{
    public interface ISolicitudData
    {
        Solicitud Crear(int idCanalAtencion, int idAlumno, int? idCurso, string consulta, string usuario);
        Solicitud Atender(long idSolicitud, long? idIntencion, string solucion, string estado, string usuario);
    }
}
