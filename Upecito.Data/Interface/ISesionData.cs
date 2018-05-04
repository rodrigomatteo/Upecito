using Upecito.Model;

namespace Upecito.Data.Interface
{
    public interface ISesionData
    {
        Sesion Crear(long idAlumno);
        Sesion Cerrar(long idSesion);
    }
}
