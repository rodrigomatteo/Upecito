using Api.Ai.ApplicationService.Factories;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Infrastructure.Factories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;
using Upecito.Business;
using Upecito.Data.Implementation;
using Upecito.Data.Interface;
using Upecito.Interface;

namespace Upecito.Bot.App_Start
{
    public class BotAppBootstrap
    {
        public static Container RegisterContainer(HttpConfiguration config)
        {
            var container = new Container();

            container.RegisterWebApiControllers(config);

            container.RegisterInstance<IServiceProvider>(container);

            container.RegisterSingleton<IApiAiAppServiceFactory, ApiAiAppServiceFactory>();
            container.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();
            container.RegisterSingleton<ISolicitud, SolicitudManager>();
            container.RegisterSingleton<IIntencion, IntencionManager>();

            container.Register<ISomeServiceFactory, SomeServiceFactory>();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }
    }
}