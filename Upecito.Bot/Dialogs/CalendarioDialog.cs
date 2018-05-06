using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Upecito.Model;

namespace Upecito.Bot.Dialogs
{
    public class CalendarioDialog : BaseDialog
    {
        private const string RESPUESTA = "Esta es una pregunta relacionada a Calendario de Actividades";

        protected override void MostrarRespuesta(IDialogContext context, Result resultado)
        {
            var userName = context.Activity.From.Name;

            resultado.Speech = $"{userName} {RESPUESTA}";
            base.MostrarRespuesta(context, resultado);
        }
    }
}