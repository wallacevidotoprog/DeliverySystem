# DeliverySystem 🚚

Sistema completo de gerenciamento de entregas, desenvolvido em .NET com Clean Architecture e suporte para múltiplas plataformas:

* ✅ API (ASP.NET Core)
* ✅ Web (Blazor)
* ✅ Desktop (WPF)
* ✅ Mobile (MAUI)

---

## 🔧 Tecnologias Utilizadas

* .NET 8
* Entity Framework Core
* ASP.NET Core Web API
* Blazor WebAssembly
* WPF
* .NET MAUI
* SQLite / SQL Server / PostgreSQL
* Swagger
* Docker
* GitHub Actions (CI/CD)

---

## 🧱 Estrutura do Projeto

```
DeliverySystem.sln
├── Core
│   ├── Domain
│   └── Application
├── Infrastructure
├── Shared
├── API
├── WebApp
├── DesktopApp
├── MobileApp
/tests
├── UnitTests
└── IntegrationTests
```

---

## 🚀 Como Executar Localmente

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/DeliverySystem.git
cd DeliverySystem
```

### 2. Abrir no Visual Studio 2022

* Abra o arquivo `DeliverySystem.sln`
* Defina o projeto `DeliverySystem.API` como o projeto de inicialização

### 3. Executar Migrations (opcional)

```bash
cd Infrastructure
# Ajustar se estiver usando SQLite ou outro
```



## 🧪 Testes

```bash
dotnet test tests/UnitTests
```

---

## ⚙️ CI/CD 

Pipeline automatizado de build, testes e deploy (em breve).

---

## ✨ Funcionalidades

* Cadastro de entregadores e clientes
* Criação e acompanhamento de entregas
* Histórico e status das entregas
* Notificações push (mobile)

---

## 📜 Licença

MIT License © 2025 Seu Nome
