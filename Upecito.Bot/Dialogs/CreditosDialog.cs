using Microsoft.Bot.Builder.Dialogs;
using Upecito.Model;

namespace Upecito.Bot.Dialogs
{
    public class CreditosDialog : BaseDialog
    {
        private const string RESPUESTA = "Esta es una pregunta relacionada a Creditos";

        protected override void MostrarRespuesta(IDialogContext context, Result resultado)
        {
            var userName = context.Activity.From.Name;

            resultado.Speech = $"{userName} {RESPUESTA}";
            base.MostrarRespuesta(context, resultado);
        }
    }
}