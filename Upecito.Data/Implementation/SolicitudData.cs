using Simple.Data;
using System;
using Upecito.Data.Interface;
using Upecito.Model;

namespace Upecito.Data.Implementation
{
    public class SolicitudData : BaseData, ISolicitudData
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
                    IdAlumno = gsavSolicitud.IDALUMNO,
                    IdCurso = gsavSolicitud.IDCURSO,
                    Consulta = gsavSolicitud.CONSULTA,
                    FechaRegistro = gsavSolicitud.FECHAREGISTRO
                };

                return solicitud;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return null;
        }

        public Solicitud Atender(long idSolicitud, long? idIntencion, string solucion, string estado, string usuario)
        {
            try
            {
                var db = Database.OpenNamedConnection(ConnectionName);

                var result = db.SP_ACTUALIZARSOLICITUD(idSolicitud, idIntencion, solucion, estado, usuario);
                var gsavSolicitud = db.GSAV_SOLICITUD.Get(result.OutputValues["PRPTA"]);

                var solicitud = new Solicitud()
                {
                    IdSolicitud = gsavSolicitud.IDSOLICITUD,
                    IdAlumno = gsavSolicitud.IDALUMNO,
                    IdCurso = gsavSolicitud.IDCURSO,
                    Consulta = gsavSolicitud.CONSULTA,
                    FechaRegistro = gsavSolicitud.FECHAREGISTRO
                };

                return solicitud;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return null;
        }

    }
}
