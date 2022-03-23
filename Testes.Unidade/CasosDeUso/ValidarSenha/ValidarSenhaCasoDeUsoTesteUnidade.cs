using Aplicacao.Excecoes;
using Aplicacao.ValidarSenha;
using CasosDeUso.ValidarSenha;
using FluentAssertions;
using System;
using Xunit;

namespace Testes.Unidade.CasosDeUso.ValidarSenha
{
    public class ValidarSenhaCasoDeUsoTesteUnidade
    {
        #region Cenários de sucesso

        [Theory(DisplayName = "Deve validar senha sem exceção usando caracteres especiais especificados")]
        [InlineData("Ab!123456")]
        [InlineData("Ab@123456")]
        [InlineData("Ab#123456")]
        [InlineData("Ab$123456")]
        [InlineData("Ab%123456")]
        [InlineData("Ab^123456")]
        [InlineData("Ab&123456")]
        [InlineData("Ab*123456")]
        [InlineData("Ab(123456")]
        [InlineData("Ab)123456")]
        [InlineData("Ab&-123456")]
        [InlineData("Ab&+123456")]
        public void DeveValidarSenhaSemExcecao(string senha)
        {
            // Arrange
            var instancia = new ValidarSenhaCasoDeUso();

            // Act
            Action erro = () => instancia.ValidarSenha(new ValidarSenhaDto { Senha = senha });

            // Assert
            erro.Should().NotThrow();
        }

        #endregion

        #region Cenários de erro

        [Fact(DisplayName = "Deve disparar Exceção mínimo de caracteres não alcançado")]
        public void DeveDispararExcecaoMinimoCaracteresNaoAlcancado()
        {
            // Arrange
            var senha = "Ab#12345";

            var instancia = new ValidarSenhaCasoDeUso();

            // Act
            Action erro = () => instancia.ValidarSenha(new ValidarSenhaDto { Senha = senha });

            // Assert
            erro.Should().Throw<RegraDeNegocioException>().And.Message.Should().Be("Senha precisa ter um mínimo de 9 caracteres");
        }

        [Fact(DisplayName = "Deve disparar Exceção por não conter dígito")]
        public void DeveDispararExcecaoNaoContemDigito()
        {
            // Arrange
            var senha = "Abcdefgh#";

            var instancia = new ValidarSenhaCasoDeUso();

            // Act
            Action erro = () => instancia.ValidarSenha(new ValidarSenhaDto { Senha = senha });

            // Assert
            erro.Should().Throw<RegraDeNegocioException>().And.Message.Should().Be("Precisa conter pelo menos um dígito");
        }

        [Fact(DisplayName = "Deve disparar Exceção por não conter letra maiúscula")]
        public void DeveDispararExcecaoNaoContemLetraMaiuscula()
        {
            // Arrange
            var senha = "abcdefg1#";

            var instancia = new ValidarSenhaCasoDeUso();

            // Act
            Action erro = () => instancia.ValidarSenha(new ValidarSenhaDto { Senha = senha });

            // Assert
            erro.Should().Throw<RegraDeNegocioException>().And.Message.Should().Be("Precisa conter pelo menos uma letra maiúscula");
        }

        [Fact(DisplayName = "Deve disparar Exceção por não conter caractere especial")]
        public void DeveDispararExcecaoNaoContemCaractereEspecial()
        {
            // Arrange
            var senha = "Abcdefg12";

            var instancia = new ValidarSenhaCasoDeUso();

            // Act
            Action erro = () => instancia.ValidarSenha(new ValidarSenhaDto { Senha = senha });

            // Assert
            erro.Should().Throw<RegraDeNegocioException>().And.Message.Should().Be("Precisa conter pelo menos um caracter especial");
        }

        [Theory(DisplayName = "Deve disparar Exceção por conter caractere repetido")]
        [InlineData("Abcdef1#b")]
        [InlineData("Abcdef1#1")]
        [InlineData("Abcdef1##")]
        [InlineData("Abcdef1#A")]
        public void DeveDispararExcecaoContemCaractereRepetido(string senha)
        {
            // Arrange
            var instancia = new ValidarSenhaCasoDeUso();

            // Act
            Action erro = () => instancia.ValidarSenha(new ValidarSenhaDto { Senha = senha });

            // Assert
            erro.Should().Throw<RegraDeNegocioException>().And.Message.Should().Be("Não é permitido caracteres repetidos");
        }

        #endregion
    }
}