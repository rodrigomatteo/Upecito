
using Microsoft.Bot.Builder.Dialogs;
using Upecito.Model;

namespace Upecito.Bot.Dialogs
{
    public class NoRespuestaDialog : BaseDialog
    {
        protected override void MostrarRespuesta(IDialogContext context, Result resultado)
        {
            if (resultado.Speech.Equals(string.Empty))
                resultado.Speech = "EStoy entrenando...";

            base.MostrarRespuesta(context, resultado);
        }
    }
}