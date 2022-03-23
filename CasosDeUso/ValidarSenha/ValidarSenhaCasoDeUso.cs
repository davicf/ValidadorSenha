using Aplicacao.ValidarSenha;

namespace CasosDeUso.ValidarSenha
{
    public class ValidarSenhaCasoDeUso : IValidarSenhaCasoDeUso
    {
        public void ValidarSenha(ValidarSenhaDto senhaDto)
        {
            ValidarSenhaValidacoes.Criar().ValidarRegras(senhaDto);
        }
    }
}