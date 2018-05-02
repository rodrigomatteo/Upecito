using Simple.Data;
using System;
using Upecito.Model;

namespace Upecito.Data.Implementation
{
    public class SolicitudData : BaseData
    {
        public Solicitud Crear(int idCanalAtencion, int idAlumno, int? idCurso, string consulta, string usuario)
        {
            try
            {
                var db = Database.OpenNamedConnection(ConnectionName);

                var result = db.SP_CREARSOLICITUD(idCanalAtencion, idAlumno, idCurso, consulta, usuario);
                var gsavSolicitud = db.GSAV_SOLICITUD.Get(result.OutputValues["PRPTA"]);

                var solicitud = new Solicitud()
                {
                    IdSolicitud = gsavSolicitud.IDSOLICITUD,
                    IdCanalAtencion = gsavSolicitud.IDCANALATENCION,
                    IdAlumno = gsavSolicitud.IDALUMNO,
                    IdCurso = gsavSolicitud.IDCURSO,
                    Consulta = gsavSolicitud.CONSULTA,
                    FechaRegistro = gsavSolicitud.FECHAREGISTRO
                };

                return solicitud;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
