using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Upecito.Model;

namespace Upecito.Bot.Dialogs
{
    [Serializable]
    public class SinScoreDialog : BaseDialog
    {
        protected override void MostrarRespuesta(IDialogContext context, Result resultado)
        {
            var userName = context.Activity.From.Name;

            resultado.Speech =
                $"Uhmmm... {userName} estoy entrenándome para ayudarte más adelante con este tipo de dudas.{Environment.NewLine}. Pero recuerda que vía Contacto UPC: http://www.upc.edu.pe/servicios/contacto-upc puedes resolver tus dudas o consultas";
            base.MostrarRespuesta(context, resultado);
        }
    }
}