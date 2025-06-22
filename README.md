# Oh My Cash API - C# Edition

## Índice de Idiomas / Language Index / Índice de Idiomas

-   [Português](#português)
-   [Español](#español)
-   [English](#english)

---

## Português

### Descrição

Esta é uma API simples de controle financeiro pessoal, desenvolvida como projeto acadêmico.

Ela permite o gerenciamento de:

-   Contas (accounts)
-   Categorias (categories)
-   Transações (transactions)
-   Orçamentos (budgets)

### Aviso Importante

**Esta API não possui autenticação ou qualquer camada de segurança. Não é recomendada para uso em produção sem modificações significativas de segurança.**

### Documentação Swagger

A documentação detalhada da API está disponível em `/swagger` após iniciar a aplicação.

O projeto usa PostgreSQL.  
O arquivo de inicialização do banco de dados está em `Infrastructure/Data/init.sql`.  
Certifique-se de configurar corretamente a connection string `DefaultConnection` em `appsettings.json`, que possui uma configuração padrão.

---

## Español

### Descripción

Esta es una API simple de control financiero personal, desarrollada como proyecto académico.

Permite la gestión de:

-   Cuentas (accounts)
-   Categorías (categories)
-   Transacciones (transactions)
-   Presupuestos (budgets)

### Aviso Importante

**Esta API no tiene autenticación ni ninguna capa de seguridad. No se recomienda su uso en producción sin modificaciones significativas de seguridad.**

### Documentación Swagger

La documentación detallada de la API está disponible en `/swagger` después de iniciar la aplicación.

El proyecto usa PostgreSQL.  
El archivo de inicialización de la base de datos está en `Infrastructure/Data/init.sql`.  
Asegúrese de configurar correctamente la cadena de conexión `DefaultConnection` en `appsettings.json`, que tiene una configuración estándar.

---

## English

### Description

This is a simple personal finance management API, developed as an academic project.

It allows managing:

-   Accounts
-   Categories
-   Transactions
-   Budgets

### Important Notice

**This API lacks authentication and any security layer. It is not recommended for production use without significant security modifications.**

### Swagger Documentation

Full API documentation is available at `/swagger` after running the application.

The project uses PostgreSQL.  
The database initialization file is located at `Infrastructure/Data/init.sql`.  
Make sure to properly configure the `DefaultConnection` connection string in `appsettings.json`, which has a standard configuration.

---
