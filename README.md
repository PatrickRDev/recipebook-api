# MyRecipeBook API
 
API REST em .NET para gerenciamento de receitas. Projeto de estudo, em desenvolvimento, criado para praticar boas práticas de backend.
 
## Tecnologias
 
- .NET 10 / C#
- Entity Framework Core + MySQL
- Arquitetura em camadas com princípios de DDD
- FluentValidation (validação) e Argon2id (hash de senha)
- Testes de unidade (Bogus, Shouldly, Moq) e de integração (WebApplicationFactory, Testcontainers)
- Integração contínua com GitHub Actions
## Funcionalidades
 
- [x] Cadastro de usuário
- [x] Testes de unidade e de integração
- [x] Pipeline de CI
- [ ] Login com JWT
- [ ] CRUD de receitas
## Como executar
 
Pré-requisitos: .NET 10 SDK, Docker e MySQL.
 
```bash
# Rodar os testes (os de integração usam Docker)
dotnet test
```
 
Configure a connection string no `appsettings` antes de rodar a API.
 
## Autor
 
Patrick Rodrigues Juvêncio · [github.com/PatrickRDev](https://github.com/PatrickRDev)
