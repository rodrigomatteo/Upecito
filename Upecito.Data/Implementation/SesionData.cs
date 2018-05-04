using Simple.Data;
using System;
using Upecito.Data.Interface;
using Upecito.Model;

namespace Upecito.Data.Implementation
{
    public class SesionData : BaseData, ISesionData
    {
        public Sesion Crear(long idAlumno)
        {
            try
            {
                var db = Database.OpenNamedConnection(ConnectionName);

                var result = db.SP_CREARSESION(idAlumno);
                var gsavSesion = db.GSAV_SESION.Get(result.OutputValues["PRPTA"]);

                var sesion = new Sesion()
                {
                    IdSesion = gsavSesion.IDSESION,
                    IdAlumno = gsavSesion.IDALUMNO,
                    FechaInicio = gsavSesion.FECHAINICIO
                };

                return sesion;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return null;
        }

        public Sesion Cerrar(long idSesion)
        {
            try
            {
                var db = Database.OpenNamedConnection(ConnectionName);

                var result = db.SP_CERRARSESION(idSesion);
                var gsavSesion = db.GSAV_SESION.Get(result.OutputValues["PRPTA"]);

                var sesion = new Sesion()
                {
                    IdSesion = gsavSesion.IDSESION,
                    IdAlumno = gsavSesion.IDALUMNO,
                    FechaInicio = gsavSesion.FECHAINICIO
                };

                return sesion;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return null;
        }
    }
}
