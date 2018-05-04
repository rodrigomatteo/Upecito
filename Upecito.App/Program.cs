using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Upecito.Business;
using Upecito.Data.Implementation;
using Upecito.Data.Interface;
using Upecito.Interface;

namespace Upecito.App
{
    class Program
    {
        private static Container container;

        static Program()
        {
            container = new Container();
        }

        static void Main(string[] args)
        {
            container.Register<ISesion, SesionManager>();
            container.Register<ISesionData, SesionData>();

            container.GetInstance<ISesion>().CrearSesion(1);
        }
    }
}
