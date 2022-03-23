using Aplicacao.ValidarSenha;
using CasosDeUso.Extensoes;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CasosDeUso.ValidarSenha
{
    public class ValidarSenhaValidacoes : AbstractValidator<ValidarSenhaDto>
    {
        private ValidarSenhaValidacoes()
        {
            UsarRegraMinimoCaracteres();
            UsarRegraDigito();
            UsarRegraLetraMinuscula();
            UsarRegraLetraMaiuscula();
            UsarRegraCaracteresEspecial();
            UsarRegraCaracteresRepetidos();
        }

        public void ValidarRegras(ValidarSenhaDto senhaDto) => 
            Validate(senhaDto).Verificar();

        public static ValidarSenhaValidacoes Criar() => 
            new ValidarSenhaValidacoes();

        #region Definição de Regras
        private void UsarRegraMinimoCaracteres()
        {
            RuleFor(dto => dto.Senha)
                .MinimumLength(9)
                .WithMessage("Senha precisa ter um mínimo de 9 caracteres");
        }

        private void UsarRegraDigito()
        {
            RuleFor(dto => dto.Senha)
                .Must(senha => ValidarRegex(senha, @"\d"))
                .WithMessage("Precisa conter pelo menos um dígito");
        }

        private void UsarRegraLetraMinuscula()
        {
            RuleFor(dto => dto.Senha)
                .Must(senha => ValidarRegex(senha, "[a-zç]"))
                .WithMessage("Precisa conter pelo menos uma letra minúscula");
        }

        private void UsarRegraLetraMaiuscula()
        {
            RuleFor(dto => dto.Senha)
                .Must(senha => ValidarRegex(senha, "[A-ZÇ]"))
                .WithMessage("Precisa conter pelo menos uma letra maiúscula");
        }

        private void UsarRegraCaracteresEspecial()
        {
            RuleFor(dto => dto.Senha)
                .Must(senha => ValidarRegex(senha, "[!@#$%^&*()-+]"))
                .WithMessage("Precisa conter pelo menos um caracter especial");
        }

        private void UsarRegraCaracteresRepetidos()
        {
            RuleFor(dto => dto.Senha)
                .Must(senha => !ValidarRegex(senha, @"(.)*.*\1"))
                .WithMessage("Não é permitido caracteres repetidos");
        }
        #endregion

        #region Métodos Auxiliares
        private bool ValidarRegex(string texto, string padrao)
        {
            var regex = new Regex(padrao).Match(texto);

            return regex.Success;
        }
        #endregion
    }
}