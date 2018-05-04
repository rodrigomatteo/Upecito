using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Upecito.Data;
using Upecito.Data.Implementation;
using Upecito.Data.Interface;
using Upecito.Interface;
using Upecito.Model;

namespace Upecito.Business
{
    public class IntencionManager : IIntencion
    {
        private readonly Container container;

        public IntencionManager(Container container)
        {
            this.container = container;
        }

        public Intencion ObtenerCategoria(string intent)
        {
            var intencionData = container.GetInstance<IIntencionData>();
            return intencionData.BuscarIntencionConsulta(intent);
        }
    }
}
