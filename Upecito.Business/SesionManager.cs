using SimpleInjector;
using Upecito.Data.Interface;
using Upecito.Interface;
using Upecito.Model;

namespace Upecito.Business
{
    public class SesionManager : ISesion
    {
        private Container container;

        public SesionManager(Container container)
        {
            this.container = container;
        }

        public Sesion CrearSesion(long idAlumno)
        {
            var sesionData = container.GetInstance<ISesionData>();
            return sesionData.Crear(idAlumno);
        }

        public Sesion CerrarSesion(long idSesion)
        {
            var sesionData = container.GetInstance<ISesionData>();
            return sesionData.Cerrar(idSesion);
        }
    }
}
