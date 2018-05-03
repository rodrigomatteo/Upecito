using System.Net;
using System.Threading.Tasks;
using Api.Ai.ApplicationService.Factories;
using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.Enum;
using Api.Ai.Domain.Service.Factories;
using Microsoft.Bot.Connector;
using Upecito.Model;

namespace Upecito.Bot
{
    public class DialogEngine
    {
        #region Private Fields

        private readonly IApiAiAppServiceFactory _apiAiAppServiceFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        #endregion

        public DialogEngine(IApiAiAppServiceFactory apiAiAppServiceFactory, IHttpClientFactory httpClientFactory)
        {
            _apiAiAppServiceFactory = apiAiAppServiceFactory;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Result> GetSpeechAsync(Activity message)
        {
            var result = new Result();

            try
            {
                var queryAppService = _apiAiAppServiceFactory.CreateQueryAppService("https://api.api.ai/v1", "adf581038f9a4d3aa7f96479e4ac497e");

                var queryRequest = new QueryRequest
                {
                    Query = new[] { message.Text },
                    Lang = Language.Spanish,
                    SessionId = message.Id
                };

                result.SessionId = message.Id;

                var queryResponse = await queryAppService.GetQueryAsync(queryRequest);

                if (queryResponse?.Result != null)
                    if (queryResponse.Status?.Code == (int)HttpStatusCode.OK)
                    {
                        result.Status = (int)HttpStatusCode.OK;
                        if (queryResponse.Result.Fulfillment != null && string.IsNullOrEmpty(queryResponse.Result.Fulfillment.Speech))
                            result.Speech = "Oooops!";
                        else if (queryResponse.Result.Fulfillment != null)
                        {
                            result.Speech = queryResponse.Result.Fulfillment.Speech;
                            var entity = new Intent()
                            {
                                IntentId = queryResponse.Result.Metadata.IntentId,
                                IntentName = queryResponse.Result.Metadata.IntentName,
                                Score = queryResponse.Result.Score
                            };
                            result.Intents.Add(entity);
                        }
                    }
            }
            catch { }

            return result;
        }
    }
}