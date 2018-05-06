using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using SimpleInjector;
using Upecito.Business;
using Upecito.Data.Implementation;
using Upecito.Data.Interface;
using Upecito.Interface;
using Upecito.Model;

namespace Upecito.Bot.Dialogs
{
    public class CerrarSesionDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            var container = new Container();
            container.RegisterSingleton<ISesion, SesionManager>();
            container.Register<ISesionData, SesionData>();

            var sesion = context.UserData.GetValueOrDefault<Sesion>("sesion");

            if (sesion != null)
            {
                var sesionManager = container.GetInstance<ISesion>();
                sesionManager.CerrarSesion(sesion.IdSesion);
            }

            context.Done(true);
            return Task.CompletedTask;
        }
    }
}