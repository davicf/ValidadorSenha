# ValidadorSenha

### É uma Web API que faz validações de senhas

#### Validações feitas pela API:
+ Ter nove ou mais caracteres
+ Ter ao menos 1 dígito
+ Ter ao menos 1 letra minúscula
+ Ter ao menos 1 letra maiúscula
+ Ter ao menos 1 caractere especial (!@#$%^&*()-+)
+ Não possuir caracteres repetidos dentro do conjunto


## Validar Senha

`Get validacoes/senha`

#### Exemplo
`localhost:8080/validacoes/Ab123`

### Retorno

+ Senha atingiu os critérios - status 200
+ Senha não atingiu um dos critérios - mensagem de erro

### Passar caracteres especiais pela url

#### Tabela de codificação percentual
![image](https://user-images.githubusercontent.com/48035880/159801581-b61c1c46-4d63-41e6-9b01-887dd336ff41.png)

#### Exemplo
`localhost:8080/validacoes/Ab%23123456`
##### É igual a:
`localhost:8080/validacoes/Ab#123456`

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
