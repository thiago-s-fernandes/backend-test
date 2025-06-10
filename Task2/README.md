# Sistema de Recomendação de Livros – Arquitetura

## Visão Geral

Este projeto apresenta a arquitetura de um sistema escalável, altamente disponível e performático para um serviço de recomendação de livros que atende milhões de usuários simultaneamente, fornecendo recomendações personalizadas.

## Tecnologias e Padrões de Design Utilizados

### 1. **Clientes (Web / Mobile)**

- Interfaces responsivas desenvolvidas em frameworks modernos (React, Flutter, etc).
- Consomem APIs REST/gRPC para exibir recomendações e gerenciar dados do usuário.

### 2. **CloudFront + API Gateway**

- **Amazon CloudFront** atua como CDN global para reduzir latência e distribuir conteúdo estático.
- **AWS API Gateway** oferece gerenciamento centralizado das APIs, incluindo autenticação, throttling e roteamento.

### 3. **Application Load Balancer (ALB)**

- Balanceia o tráfego entre múltiplas instâncias de backend, distribuindo carga de forma eficiente.

### 4. **Backend Services em AWS ECS (Fargate)**

- Microsserviços isolados para:

  - Gestão de livros (BookService)
  - Gestão de usuários (UserService)
  - Recomendação (Recommendation Engine)

- Containerizados, facilitando escalabilidade horizontal e implantação contínua.

### 5. **Amazon SQS**

- Fila de mensagens para comunicação assíncrona entre microsserviços, garantindo desacoplamento e resiliência.

### 6. **Banco de Dados**

- **Amazon RDS (PostgreSQL)** para dados relacionais como perfis de usuários, histórico e preferências.
- **Amazon DynamoDB** para armazenamento rápido e escalável de metadados dos livros.

### 7. **Amazon SageMaker**

- Plataforma gerenciada para treinar e hospedar modelos de machine learning que geram recomendações personalizadas.
- Permite processamento em batch e em tempo real.

### 8. **ElastiCache (Redis)**

- Cache distribuído para acelerar a entrega das recomendações mais recentes e dados de sessão.

### 9. **Amazon S3**

- Armazenamento escalável para conteúdos estáticos, como capas de livros, PDFs e dados de mídia.

---

## Considerações sobre Escalabilidade, Disponibilidade e Desempenho

### Escalabilidade

- **Escalabilidade Horizontal:** Microsserviços e bancos são dimensionados automaticamente com base na demanda, usando AWS ECS Fargate e mecanismos de auto-scaling.
- **Sharding e Indexação:** DynamoDB e RDS utilizam técnicas de sharding e índices para alta performance em consultas.
- **Desacoplamento:** Uso de SQS para comunicação assíncrona reduz acoplamento e permite processamento paralelo e tolerante a falhas.

### Alta Disponibilidade

- **Multi-AZ Deployments:** RDS, DynamoDB, ElastiCache e ECS são configurados para operar em múltiplas zonas de disponibilidade, evitando downtime.
- **Load Balancing:** ALB distribui a carga e detecta instâncias com falha, removendo-as automaticamente.
- **Backup e Recovery:** Backups automáticos e snapshots são configurados para bancos de dados e S3, garantindo recuperação rápida.

### Desempenho

- **Cache em Redis:** Reduz latência, servindo dados frequentemente acessados sem necessidade de consulta ao banco.
- **CDN (CloudFront):** Minimiza a latência de conteúdo estático para usuários globais.
- **Modelos ML Otimizados:** Recomendações pré-calculadas e atualizadas em batch combinadas com inferência em tempo real permitem respostas rápidas e personalizadas.

### Segurança

- Comunicação segura via TLS em todas as camadas.
- Autenticação e autorização via API Gateway e tokens JWT/OAuth2.
- Políticas de IAM rigorosas para acesso aos recursos AWS.
