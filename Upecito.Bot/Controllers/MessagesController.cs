using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Http.Description;
using System.Net.Http;
using System.Linq;
using Upecito.Bot.Dialogs;
using System.Net;
using SimpleInjector;

namespace Upecito.Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        #region Private Fields

        private readonly Container container;

        #endregion

        #region Constructor

        public MessagesController(Container container)
        {
            this.container = container;
        }

        #endregion

        /// <summary>
        /// POST: api/Messages
        /// receive a message from a user and send replies
        /// </summary>
        /// <param name="activity"></param>
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            // check if activity is of type message
            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
                    await Conversation.SendAsync(activity, () => new WelcomeDialog());
            else
                HandleSystemMessage(activity);

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        private async void HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
                if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
                {
                    var bot = message.MembersAdded.FirstOrDefault();
                    if (bot != null && bot.Name.Equals("Upecito Bot"))
                    {
                        var dialog = container.GetInstance<RootDialog>();
                        await Conversation.SendAsync(message, () => dialog);
                    }
                }

                if (message.MembersRemoved.Count > 1)
                    await Conversation.SendAsync(message, () => new CerrarSesionDialog());
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
        }
    }
}