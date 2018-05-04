using System;
using Simple.Data;
using Upecito.Data.Interface;
using Upecito.Model;

namespace Upecito.Data.Implementation
{
    public class IntencionData : BaseData, IIntencionData
    {
        public Intencion BuscarIntencionConsulta(string intencion)
        {
            try
            {
                var db = Database.OpenNamedConnection(ConnectionName);

                var result = db.SP_BUSCARINTENCIONCONSULTA(intencion);
                var gsavIntencion = db.GSAV_INTENCION_CONSULTA.Get(result.OutputValues["RESULTADO"]);

                var categoria = new Intencion()
                {
                    IdIntencion = gsavIntencion.IDINTENCIONCONSULTA,
                    Nombre = gsavIntencion.NOMBRE
                };

                return categoria;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return null;
        }
    }
}
