# 🏛️ CleanArchMvc

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

Um projeto web de catálogo de Produtos e Categorias desenvolvido com **ASP.NET Core MVC**, aplicando rigorosamente os conceitos de **Clean Architecture (Arquitetura Limpa)** e **CQRS**. O objetivo principal é demonstrar a construção de um software altamente escalável, testável e com baixo acoplamento, focado em boas práticas de engenharia de software.

---

## 🚀 Tecnologias e Padrões Utilizados

* **Framework:** .NET 8
* **Apresentação:** ASP.NET Core MVC
* **Banco de Dados:** Microsoft SQL Server
* **ORM:** Entity Framework Core
* **Mapeamento de Objetos:** AutoMapper
* **Padrão CQRS:** MediatR
* **Injeção de Dependência:** Native .NET DI
* **Padrões de Projeto:** Repository Pattern, CQRS, Clean Architecture

---

## 📁 Estrutura da Arquitetura

O projeto foi dividido em camadas lógicas para garantir a separação de responsabilidades (*Separation of Concerns*), onde a regra de negócio não depende de frameworks externos.

### 1. `CleanArchMvc.Domain`
O coração do software. Contém as Entidades (`Category`, `Product`), regras de negócio centrais, validações (*Domain Validation*) e as interfaces dos repositórios. Não possui dependência de nenhuma outra camada.

### 2. `CleanArchMvc.Application`
Responsável pelos Casos de Uso (*Use Cases*). Contém:
* **DTOs:** Objetos de transferência de dados para a View.
* **Mappings:** Perfis do AutoMapper para conversão entre Entidades, DTOs e Commands.
* **Services:** Orquestração das regras de negócio.
* **CQRS (Commands e Queries):** Utilização do MediatR para separar as operações de leitura e escrita dos produtos.

### 3. `CleanArchMvc.Infra.Data`
Camada de persistência. Contém a implementação do contexto do Entity Framework (`ApplicationDbContext`), as configurações de mapeamento das tabelas (*Fluent API*) e as implementações concretas dos repositórios.

### 4. `CleanArchMvc.Infra.IoC`
Camada transversal (*Cross-Cutting*). Responsável por centralizar toda a configuração de Injeção de Dependência (DI) do sistema, registrando serviços, repositórios, AutoMapper e MediatR.

### 5. `CleanArchMvc.WebUI`
A camada de apresentação. Contém os Controllers e Views do padrão MVC, interagindo exclusivamente com a camada de `Application`.

---

## ⚙️ Como executar o projeto localmente

1. **Clone o repositório:**
   Faça o clone deste projeto para a sua máquina local utilizando o comando `git clone` com a URL fornecida pelo GitHub.

2. **Configure o Banco de Dados:**
   Abra o arquivo `appsettings.json` no projeto `CleanArchMvc.WebUI` e ajuste a string de conexão `DefaultConnection` para apontar para a sua instância local do SQL Server.

3. **Aplique as Migrations:**
   Abra o Console do Gerenciador de Pacotes (*Package Manager Console*) no Visual Studio, defina o projeto padrão como `CleanArchMvc.Infra.Data` e execute o comando:
   ```powershell
   Update-Database
