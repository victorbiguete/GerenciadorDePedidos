# 🛒 MyStore API

> **MyStore** é uma API desenvolvida em **.NET 8** com arquitetura limpa (Clean Architecture), seguindo os princípios **DDD**, **SOLID**, e utilizando **MongoDB** como banco de dados.  
> O sistema simula uma aplicação de gestão de pedidos de uma loja, permitindo operações completas de CRUD para **Clientes**, **Produtos** e **Pedidos**.

---

## 🚀 Tecnologias Utilizadas

| Camada | Tecnologias / Padrões |
|--------|------------------------|
| **Backend** | ASP.NET Core Web API |
| **Banco de Dados** | MongoDB |
| **Padrões** | Clean Architecture, DDD, CQRS, SOLID |
| **Mensageria / Mediator** | MediatR |
| **Mapper** | AutoMapper |
| **Validações** | FluentValidation |
| **Documentação** | Swagger (Swashbuckle) |
| **Autenticação (futuro)** | JWT Token |

---

## 🧩 Estrutura do Projeto
MyStore/
├── MyStore.API/ # Camada de apresentação (Controllers)
├── MyStore.Application/ # Casos de uso, Handlers e Queries/Commands
├── MyStore.Communication/ # DTOs, Requests e Responses
├── MyStore.Domain/ # Entidades e Regras de Negócio
├── MyStore.Infrastructure/ # Persistência e Configurações do MongoDB
└── MyStore.Tests/ # Testes unitários e de integração


---

## ⚙️ Configuração do Ambiente

### 1️⃣ Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### 2️⃣ Configurar o MongoDB
Edite o arquivo se achar necessario **`appsettings.Development.json`**:

```json
{
  "ConnectionStrings": {
  "SqlServerConnection": "Server=localhost;Database=OrderSystemDB; Trusted_Connection=True; TrustServerCertificate=true;",
  "MongoConnection": "mongodb://localhost:27017/"
},
"MongoDatabaseName": "OrderReadDB"
}
```
## 🧠 Domínios e Rotas

### 🧍‍♂️ Customer
| Método | Endpoint | Descrição |
|--------|---------|-----------|
| GET    | /Customer | Retorna todos os clientes |
| GET    | /Customer/GetById/{id} | Retorna um cliente específico pelo ID |

### 📦 Product
| Método | Endpoint | Descrição |
|--------|---------|-----------|
| GET    | /Product | Retorna todos os produtos |
| GET    | /Product/GetById/{id} | Retorna um produto pelo ID |

### 🧾 Order
| Método | Endpoint | Descrição |
|--------|---------|-----------|
| POST   | /Order/register | Registra um novo pedido |
| GET    | /Order/GetAllOrder | Retorna todos os pedidos |
| GET    | /Order/GetAllOrderStatus/{status} | Retorna todos os pedidos filtrados por status |
| GET    | /Order/GetById/{id} | Retorna um pedido específico |
| PUT    | /Order/UpdateOrderStatus | Atualiza o status de um pedido |
| DELETE | /Order/DeleteOrder/{id} | Remove um pedido e seus itens relacionados |

---

## 🔄 Funcionalidade Especial

✅ **Cascade Delete:**  
Ao deletar uma `Order`, todos os `OrderItems` vinculados a ela também são automaticamente removidos do MongoDB.

---

## 📜 Licença

Este projeto é de código aberto sob a licença **MIT**.  
Sinta-se livre para usar, melhorar e contribuir!


## 💼 Autor
**Victor Hugo Nunes Biguete**  
👨‍💻 Desenvolvedor .NET | Clean Architecture | DDD | API REST | MongoDB  
🔗 [LinkedIn](https://www.linkedin.com/in/victorbiguete)
