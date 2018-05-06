using SimpleInjector;
using Upecito.Data.Interface;
using Upecito.Interface;
using Upecito.Model;

namespace Upecito.Business
{
    public class SolicitudManager : ISolicitud
    {
        private Container container;

        public SolicitudManager(Container container)
        {
            this.container = container;
        }

        public Solicitud CrearSolicitud(int idCanalAtencion, int idAlumno, int? idCurso, string consulta, string usuario)
        {
            var solicitudData = container.GetInstance<ISolicitudData>();
            return solicitudData.Crear(idCanalAtencion, idAlumno, idCurso, consulta, usuario);
        }

        public Solicitud Actualizar(long idSolicitud, long? idIntencion, string solucion, string estado, string usuario)
        {
            var solicitudData = container.GetInstance<ISolicitudData>();
            return solicitudData.Atender(idSolicitud, idIntencion, solucion, estado, usuario);
        }
    }
}
