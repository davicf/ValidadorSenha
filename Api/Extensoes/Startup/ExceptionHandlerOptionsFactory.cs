using Api.Shared;
using Aplicacao.Excecoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Threading.Tasks;

namespace Api.Extensoes.Startup
{
    public static class ExceptionHandlerOptionsFactory
    {
        public static ExceptionHandlerOptions Criar()
        {
            return new ExceptionHandlerOptions
            {
                ExceptionHandler = Handle,
                ExceptionHandlingPath = null
            };
        }

        private static async Task Handle(this HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is RegraDeNegocioException)
            {
                await HandleExceptionAsync(context, exceptionHandlerPathFeature?.Error.Message, HttpStatusCode.UnprocessableEntity);
            }
            else
            {
                await HandleExceptionAsync(context, "Internal server error", HttpStatusCode.InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string mensage, HttpStatusCode httpStatusCode)
        {
            var err = new ErroDto { Status = ((int)httpStatusCode).ToString(), Mensagem = mensage };
            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(err, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }
    }
}