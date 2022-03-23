using Aplicacao.ValidarSenha;
using CasosDeUso.ValidarSenha;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensoes.Startup
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection servicos)
        {
            servicos.AddScoped<IValidarSenhaCasoDeUso, ValidarSenhaCasoDeUso>();
        }
    }
}