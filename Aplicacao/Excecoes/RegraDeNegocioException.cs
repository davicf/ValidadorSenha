using System;
using System.Collections.Generic;

namespace Aplicacao.Excecoes
{
    [Serializable]
    public class RegraDeNegocioException : Exception
    {
        public IEnumerable<string> MensagensErro { get; }

        public RegraDeNegocioException(string mensagem) : base(mensagem)
        {
            MensagensErro = new List<string>() { mensagem };
        }

        public RegraDeNegocioException(IEnumerable<string> mensagens) : base(string.Join(';', mensagens))
        {
            MensagensErro = mensagens;
        }
    }
}