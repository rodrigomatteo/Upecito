using Upecito.Model;

namespace Upecito.Interface
{
    public interface ISesion
    {
        Sesion CrearSesion(long idUsuario);
        Sesion CerrarSesion(long idSesion);
    }
}
