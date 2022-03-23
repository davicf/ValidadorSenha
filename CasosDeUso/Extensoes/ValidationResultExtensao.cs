using Aplicacao.Excecoes;
using FluentValidation.Results;
using System.Linq;

namespace CasosDeUso.Extensoes
{
    public static class ValidationResultExtensao
    {
        public static void Verificar(this ValidationResult validacao)
        {
            if (validacao.IsValid)
                return;

            var errors = validacao.Errors.Select(x => x.ErrorMessage);

            throw new RegraDeNegocioException(errors);
        }
    }
}