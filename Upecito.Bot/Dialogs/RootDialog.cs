using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using SimpleInjector;

namespace Upecito.Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var message = context.MakeMessage();
            var attachment = GetInfoCard();

            message.Attachments.Add(attachment);
            await context.PostAsync(message);

            context.Wait(this.ShowStartButton);
        }

        public enum StartOptions
        {
            Iniciar
        }

        public virtual async Task ShowStartButton(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            var message = await activity;

            PromptDialog.Choice(
                context: context,
                resume: ChoiceReceivedAsync,
                options: (IEnumerable<StartOptions>)Enum.GetValues(typeof(StartOptions)),
                prompt: "Presiona el botón para iniciar",
                retry: "Por favor intenta de nuevo"
            );
        }

        public virtual async Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<StartOptions> activity)
        {
            context.Call<object>(new WelcomeDialog(), ChildDialogComplete);

        }

        public virtual async Task ChildDialogComplete(IDialogContext context, IAwaitable<object> response)
        {
            context.Done(this);
        }

        private static Attachment GetInfoCard()
        {
            var infoCard = new HeroCard
            {
                Title = "Asesor del Aula Virtual ",
                Text = "Este es UPECITO bla bla bla",
                Images = new List<CardImage> { new CardImage("https://cde.peru.com//ima/0/0/9/8/4/984607/611x458/upc.jpg") }
            };

            return infoCard.ToAttachment();
        }
    }
}