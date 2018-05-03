using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upecito.Data.Interface;
using Upecito.Model;

namespace Upecito.Data.Implementation
{
    public class SesionData : BaseData, ISesionData
    {
        public Sesion Crear(string idAlumno)
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
    }
}
