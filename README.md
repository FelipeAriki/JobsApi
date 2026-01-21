# JobsAPI

📌 API de Gerenciamento de Empregos

📖 Visão Geral:
 Esta API foi desenvolvida com o objetivo de resolver um desafio técnico proposto e, além disso, consolidar e aplicar novos conhecimentos adquiridos durante a mentoria, servindo como preparação para a resolução de desafios futuros. O projeto adota Arquitetura Limpa (Clean Architecture), além dos padrões CQRS e Repository, promovendo organização, escalabilidade e facilidade de manutenção.

🎯 Objetivo da API:
  A API tem como finalidade gerenciar e auxiliar clientes na criação e divulgação de empregos, em que é possível realizar seu cadastro, atualização, exclusão e listagem. Porém, a API conta com sistema de login, com isso, apenas usuários logados podem realizar estas operações e, caso o cliente esqueça sua senha, há a possibilidade de realizar a troca por uma nova (instruções serão enviadas por email).

🏗️ Arquitetura e Padrões:
-Clean Architecture
-CQRS (Command Query Responsibility Segregation)
-Repository Pattern
-Separação de responsabilidades
-Comunicação desacoplada via MediatR

🛠️ Tecnologias Utilizadas:
-ASP.NET Core
-.NET 8
-Dapper
-SQL Server
-MediatR
-FluentValidation
-Notifications Pattern (via email)

✅ Benefícios do Projeto:
-Código organizado e de fácil manutenção
-Alta testabilidade
-Baixo acoplamento entre camadas
-Preparado para evolução e novos requisitos
