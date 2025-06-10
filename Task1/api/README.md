# API de Transações - .NET Core 9

Uma API RESTful robusta para gerenciamento de transações financeiras, construída com .NET Core 9, implementando padrões CQRS, Dapper para acesso a dados e Oracle como banco de dados.

## Índice

- [Características](#características)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Pré-requisitos](#pré-requisitos)
- [Instalação e Configuração](#instalação-e-configuração)
- [Executando a Aplicação](#executando-a-aplicação)

## Características

- **CRUD Completo** para transações financeiras
- **Padrão CQRS** (Command Query Responsibility Segregation)
- **Validação de entrada** com FluentValidation
- **Tratamento de erros** global
- **Acesso a dados** otimizado com Dapper
- **Suporte ao Oracle Database**
- **Arquitetura limpa** e escalável

## Tecnologias Utilizadas

- **.NET 9** - Framework principal
- **ASP.NET Core** - Framework web
- **Dapper** - Micro ORM para acesso a dados
- **Oracle Database** - Banco de dados
- **FluentValidation** - Validação de modelos

## Pré-requisitos

Antes de executar a aplicação, certifique-se de ter instalado:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Oracle Database](https://www.oracle.com/database/) (versão 12c ou superior)

## Instalação e Configuração

### 1. Restaure as dependências

```bash
dotnet restore
```

### 2. Configure o banco de dados

#### 2.1. Crie a tabela no Oracle

Execute o seguinte script SQL no seu banco Oracle:

```sql
CREATE TABLE Transactions (
AccountID VARCHAR2(100) NOT NULL,
TransactionID VARCHAR2(100) PRIMARY KEY,
TransactionAmount NUMBER(18,2) NOT NULL,
TransactionCurrencyCode VARCHAR2(3) NOT NULL,
LocalHour NUMBER(2) NOT NULL,
TransactionScenario VARCHAR2(100) NOT NULL,
TransactionType VARCHAR2(100) NOT NULL,
TransactionIPaddress VARCHAR2(50) NOT NULL,
IpState VARCHAR2(100),
IpPostalCode VARCHAR2(20),
IpCountry VARCHAR2(100) NOT NULL,
IsProxyIP NUMBER(1) DEFAULT 0 NOT NULL,
BrowserLanguage VARCHAR2(50),
PaymentInstrumentType VARCHAR2(100),
CardType VARCHAR2(50),
PaymentBillingPostalCode VARCHAR2(20),
PaymentBillingState VARCHAR2(100),
PaymentBillingCountryCode VARCHAR2(3),
ShippingPostalCode VARCHAR2(20),
ShippingState VARCHAR2(100),
ShippingCountry VARCHAR2(100),
CvvVerifyResult VARCHAR2(50),
DigitalItemCount NUMBER(10) DEFAULT 0 NOT NULL,
PhysicalItemCount NUMBER(10) DEFAULT 0 NOT NULL,
TransactionDateTime TIMESTAMP NOT NULL
);

-- Índices para melhor performance
CREATE INDEX idx_account_id ON Transactions(AccountID);
CREATE INDEX idx_transaction_date ON Transactions(TransactionDateTime);
```

#### 2.2. Configure a string de conexão

Edite o arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "OracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=localhost:1521/XEPDB1;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Executando a Aplicação

### Usando .NET CLI

```bash
# Compilar o projeto

dotnet build

# Executar a aplicação

dotnet run
```

### URLs da aplicação

- **HTTP**: http://localhost:5273

## Documentação da API

### Endpoints Disponíveis

| Método | Endpoint                 | Descrição                 |
| ------ | ------------------------ | ------------------------- |
| GET    | `/api/transactions`      | Obter todas as transações |
| GET    | `/api/transactions/{id}` | Obter transação por ID    |
| POST   | `/api/transactions`      | Criar nova transação      |
| PUT    | `/api/transactions/{id}` | Atualizar transação       |
| DELETE | `/api/transactions/{id}` | Deletar transação         |

### Modelo de Dados

```json
{
  "accountID": "string",
  "transactionID": "string",
  "transactionAmount": 0.0,
  "transactionCurrencyCode": "string (3 chars)",
  "localHour": 0,
  "transactionScenario": "string",
  "transactionType": "string",
  "transactionIPaddress": "string",
  "ipState": "string",
  "ipPostalCode": "string",
  "ipCountry": "string",
  "isProxyIP": false,
  "browserLanguage": "string",
  "paymentInstrumentType": "string",
  "cardType": "string",
  "paymentBillingPostalCode": "string",
  "paymentBillingState": "string",
  "paymentBillingCountryCode": "string",
  "shippingPostalCode": "string",
  "shippingState": "string",
  "shippingCountry": "string",
  "cvvVerifyResult": "string",
  "digitalItemCount": 0,
  "physicalItemCount": 0,
  "transactionDateTime": "2023-06-18T10:30:00"
}
```

### Códigos de Resposta

| Código | Descrição                       |
| ------ | ------------------------------- |
| 200    | Sucesso                         |
| 201    | Criado com sucesso              |
| 204    | Atualizado/Deletado com sucesso |
| 400    | Requisição inválida             |
| 404    | Recurso não encontrado          |
| 500    | Erro interno do servidor        |

## Exemplos de Uso

### 1. Obter todas as transações

```bash
curl -X GET http://localhost:5000/api/transactions
```

**Resposta:**

```json
[
  {
    "accountID": "ACC123456",
    "transactionID": "TRX001",
    "transactionAmount": 125.99,
    "transactionCurrencyCode": "USD",
    "localHour": 14,
    "transactionScenario": "Online Purchase",
    "transactionType": "Payment",
    "transactionIPaddress": "192.168.1.1",
    "ipCountry": "USA",
    "isProxyIP": false,
    "digitalItemCount": 0,
    "physicalItemCount": 2,
    "transactionDateTime": "2023-06-15T14:30:00"
  }
]
```

### 2. Obter transação por ID

```bash
curl -X GET http://localhost:5000/api/transactions/TRX001
```

### 3. Criar nova transação

```bash
curl -X POST http://localhost:5000/api/transactions \
 -H "Content-Type: application/json" \
 -d '{
"accountID": "ACC789012",
"transactionID": "TRX004",
"transactionAmount": 75.50,
"transactionCurrencyCode": "BRL",
"localHour": 15,
"transactionScenario": "Online Purchase",
"transactionType": "Payment",
"transactionIPaddress": "187.45.123.45",
"ipState": "SP",
"ipPostalCode": "01310-200",
"ipCountry": "Brasil",
"isProxyIP": false,
"browserLanguage": "pt-BR",
"paymentInstrumentType": "Credit Card",
"cardType": "MASTERCARD",
"paymentBillingPostalCode": "01310-200",
"paymentBillingState": "SP",
"paymentBillingCountryCode": "BR",
"shippingPostalCode": "01310-200",
"shippingState": "SP",
"shippingCountry": "Brasil",
"cvvVerifyResult": "Match",
"digitalItemCount": 0,
"physicalItemCount": 1,
"transactionDateTime": "2023-06-18T10:30:00"
}'
```

### 4. Atualizar transação

```bash
curl -X PUT http://localhost:5000/api/transactions/TRX004 \
 -H "Content-Type: application/json" \
 -d '{
"accountID": "ACC789012",
"transactionID": "TRX004",
"transactionAmount": 85.75,
"transactionCurrencyCode": "BRL",
"localHour": 16,
"transactionScenario": "Online Purchase Updated",
"transactionType": "Payment",
"transactionIPaddress": "187.45.123.45",
"ipCountry": "Brasil",
"isProxyIP": false,
"digitalItemCount": 0,
"physicalItemCount": 1,
"transactionDateTime": "2023-06-18T10:30:00"
}'
```

## Validações Implementadas

- **AccountID**: Obrigatório
- **TransactionID**: Obrigatório e único
- **TransactionAmount**: Obrigatório e maior que 0
- **TransactionCurrencyCode**: Obrigatório e deve ter 3 caracteres
- **LocalHour**: Deve estar entre 0 e 23
- **TransactionIPaddress**: Formato de IP válido
- **DigitalItemCount/PhysicalItemCount**: Não podem ser negativos
- **TransactionDateTime**: Não pode ser no futuro

## Tratamento de Erros

A API implementa tratamento global de erros que retorna respostas consistentes:

```json
{
  "statusCode": 500,
  "message": "Internal Server Error.",
  "detailedMessage": "Detalhes do erro (apenas em desenvolvimento)"
}
```

## Configurações Avançadas

### Desabilitar HTTPS em desenvolvimento

No `Program.cs`, comente a linha:

```csharp
// app.UseHttpsRedirection();
```
