# ValidadorSenha

## É uma Web API que faz validações de senhas

### Validações feitas pela API:
+ Ter nove ou mais caracteres
+ Ter ao menos 1 dígito
+ Ter ao menos 1 letra minúscula
+ Ter ao menos 1 letra maiúscula
+ Ter ao menos 1 caractere especial (!@#$%^&*()-+)
+ Não possuir caracteres repetidos dentro do conjunto

## Validar Senha

`Get validacoes/senha`

### Retorno

+ Senha atingiu os critérios - status 200
+ Senha não atingiu um dos critérios - mensagem de erro

## Tecnologias utilizadas

+ .Net Core 3.1
+ XUnit
+ FluentValidation
+ FluentAssert

## Rodando o Projeto
### Utilizando o Visual Studio
Processo todo automatizado pela IDE
### Link IDE
https://visualstudio.microsoft.com/pt-br/downloads/
