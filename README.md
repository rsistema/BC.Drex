# BC.Drex

BC.Drex é um projeto de teste que implementa funcionalidades de gerenciamento de usuários, transferência de valores entre usuários, autenticação JWT (Bearer) e segue o padrão de design DDD (Domain-Driven Design).

## Funcionalidades

- **Gerenciamento de Usuários**: Criação, atualização, listagem e exclusão de usuários.
- **Transferência de Valores**: Transferência de valores entre usuários.
- **Autenticação JWT**: Implementação de autenticação e autorização utilizando tokens JWT (Bearer).
- **Design DDD**: Estrutura do projeto seguindo o padrão de design DDD.

## Tecnologias Utilizadas

- **.NET Core**: Framework principal para desenvolvimento da aplicação.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **Npgsql**: Provedor de banco de dados PostgreSQL para Entity Framework Core.
- **AutoMapper**: Biblioteca para mapeamento de objetos.
- **Moq**: Biblioteca para criação de mocks em testes unitários.
- **XUnit**: Framework de testes unitários.
- **Swagger**: Documentação e teste da API.

## Estrutura do Projeto

O projeto segue o padrão de design DDD e está organizado da seguinte forma:

- **BC.Drex.Domain**: Contém as entidades, interfaces de repositório e serviços de domínio.
- **BC.Drex.API**: Contém os controladores, DTOs, configurações de AutoMapper e configurações de autenticação.
- **BC.Drex.Infrastructure**: Contém a implementação dos repositórios e a configuração do Entity Framework Core.
- **BC.Drex.API.Test**: Contém os testes unitários dos controladores e serviços.

## Configuração e Execução

### Pré-requisitos

- Visual Studio 2022
- DotNet SDK 8.0
- Docker

### Passos para Configuração

1. **Clone o repositório**:

    - git clone https://github.com/BC.Drex.git
    - cd BC.Drex
    
2. **Inicialize o Docker**:
    - cd BC.Drex.API\
    - docker-compose up -d

3. **Execute as migrações do banco de dados**:
    - Através do Package Manager Console execute o comand: update-database 
    - Valide a string de conexão no appsettings para localhost ou seu ip local

4. **Inicie a aplicação**:
    - Utilize o IIS, terminal ou docker para executar a aplicação
    - Acesse a URL: https://localhost:5001/swagger/index.html

### Testes

Para executar os testes unitários, utilize o seguinte comando:

## Documentação da API

A documentação da API pode ser acessada através do Swagger. Após iniciar a aplicação, acesse a URL:

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.