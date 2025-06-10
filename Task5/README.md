Claro! Aqui está o trecho do README ajustado para refletir que **agora há tratamento de exceções** no bloco PL/SQL:

---

# Tarefa 5: Consulta PL/SQL Complexa

Este projeto utiliza PL/SQL para identificar os **5 clientes que mais gastaram nos últimos 6 meses**, além de listar os **produtos comprados** e a **quantidade de unidades adquiridas** por cada um deles.

## Estrutura do Projeto

O projeto está dividido em três partes principais:

1. **Criação de Tabelas** (`CREATE TABLE`)
2. **Inserção de Dados de Exemplo** (`INSERT INTO`)
3. **Bloco PL/SQL para consulta e exibição dos resultados**

---

## Pré-requisitos

- Oracle Database (qualquer versão compatível com PL/SQL)
- Acesso via SQL\*Plus, SQL Developer ou ambiente equivalente
- Permissão para executar comandos DDL (CREATE TABLE) e DML (INSERT, SELECT)

---

## Como Executar

1. **Conecte-se** ao Oracle usando sua ferramenta de preferência.
2. **Execute o script de criação das tabelas.**
3. **Insira os dados de exemplo.**
4. **Execute o bloco PL/SQL para visualizar os resultados.**

> **Certifique-se de que `SET SERVEROUTPUT ON` está ativado**, para que os resultados apareçam corretamente no console.

---

## Lógica da Consulta

- O sistema identifica os 5 clientes que mais gastaram nos últimos 6 meses (180 dias a partir da data atual).
- Para cada um desses clientes, são listados:

  - Nome do produto adquirido
  - Quantidade total comprada nos últimos 6 meses

---

## Suposições e Considerações

- O script assume que **os dados estão consistentes** e que não há valores nulos em campos importantes (`total_amount`, `quantity`, etc).
- **Data de corte:** Utiliza `SYSDATE - 180` para representar os últimos 6 meses.
- **Gasto do cliente:** Calculado somando o campo `total_amount` da tabela `Orders`.
- **Quantidade de produtos:** Calculada somando o campo `quantity` da tabela `Order_Items`.
- **Relações:**
  - Cada pedido pertence a um cliente (`Orders.customer_id`)
  - Cada item de pedido está vinculado a um pedido e a um produto
- **O bloco PL/SQL possui tratamento de exceções**, o que garante:
  - Continuidade da execução mesmo que ocorra erro em um cliente ou produto específico.
  - Exibição de mensagens de erro amigáveis via `DBMS_OUTPUT`.

---

## Exemplo de Saída Esperada

```text
Customer ID: 10
Customer Name: Arthur
Total Amount Spent: $3,500.00
Products Purchased:
  - Product E: 7 units
------------------------------
Customer ID: 9
Customer Name: Lucas
Total Amount Spent: $2,700.00
Products Purchased:
  - Product D: 5 units
------------------------------
...
```
