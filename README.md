# BC.Drex

BC.Drex � um projeto de teste que implementa funcionalidades de gerenciamento de usu�rios, transfer�ncia de valores entre usu�rios, autentica��o JWT (Bearer) e segue o padr�o de design DDD (Domain-Driven Design).

## Funcionalidades

- **Gerenciamento de Usu�rios**: Cria��o, atualiza��o, listagem e exclus�o de usu�rios.
- **Transfer�ncia de Valores**: Transfer�ncia de valores entre usu�rios.
- **Autentica��o JWT**: Implementa��o de autentica��o e autoriza��o utilizando tokens JWT (Bearer).
- **Design DDD**: Estrutura do projeto seguindo o padr�o de design DDD.

## Tecnologias Utilizadas

- **.NET Core**: Framework principal para desenvolvimento da aplica��o.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **Npgsql**: Provedor de banco de dados PostgreSQL para Entity Framework Core.
- **AutoMapper**: Biblioteca para mapeamento de objetos.
- **Moq**: Biblioteca para cria��o de mocks em testes unit�rios.
- **XUnit**: Framework de testes unit�rios.
- **Swagger**: Documenta��o e teste da API.

## Estrutura do Projeto

O projeto segue o padr�o de design DDD e est� organizado da seguinte forma:

- **BC.Drex.Domain**: Cont�m as entidades, interfaces de reposit�rio e servi�os de dom�nio.
- **BC.Drex.API**: Cont�m os controladores, DTOs, configura��es de AutoMapper e configura��es de autentica��o.
- **BC.Drex.Infrastructure**: Cont�m a implementa��o dos reposit�rios e a configura��o do Entity Framework Core.
- **BC.Drex.API.Test**: Cont�m os testes unit�rios dos controladores e servi�os.

## Configura��o e Execu��o

### Pr�-requisitos

- Visual Studio 2022
- DotNet SDK 8.0
- Docker

### Passos para Configura��o

1. **Clone o reposit�rio**:

    - git clone https://github.com/BC.Drex.git
    - cd BC.Drex
    
2. **Inicialize o Docker**:
    - cd BC.Drex.API\
    - docker-compose up -d

3. **Execute as migra��es do banco de dados**:
    - Atrav�s do Package Manager Console execute o comand: update-database 
    - Valide a string de conex�o no appsettings para localhost ou seu ip local

4. **Inicie a aplica��o**:
    - Utilize o IIS, terminal ou docker para executar a aplica��o
    - Acesse a URL: https://localhost:5001/swagger/index.html

### Testes

Para executar os testes unit�rios, utilize o seguinte comando:

## Documenta��o da API

A documenta��o da API pode ser acessada atrav�s do Swagger. Ap�s iniciar a aplica��o, acesse a URL:

## Contribui��o

Contribui��es s�o bem-vindas! Sinta-se � vontade para abrir issues e pull requests.

## Licen�a

Este projeto est� licenciado sob a licen�a MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.