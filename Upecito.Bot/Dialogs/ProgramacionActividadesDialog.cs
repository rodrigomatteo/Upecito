using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using SimpleInjector;
using Upecito.Model;

namespace Upecito.Bot.Dialogs
{
    public class ProgramacionActividadesDialog : BaseDialog
    {
        private const string  RESPUESTA = "Esta es una pregunta relacionada a Programación Académica";

        protected override void MostrarRespuesta(IDialogContext context, Result resultado)
        {
            var userName = context.Activity.From.Name;

            resultado.Speech = $"{userName} {RESPUESTA}";
            base.MostrarRespuesta(context, resultado);
        }
    }
}