# Segurança / Seguridad / Security

---

## Português

### Aviso de Segurança

Este projeto é desenvolvido para fins acadêmicos e de aprendizado, não incluindo nenhuma implementação de autenticação, autorização ou outras medidas de segurança essenciais para aplicações em produção.

### Riscos

-   Nenhuma autenticação: Qualquer usuário pode acessar, modificar e deletar dados.
-   Falta de autorização: Não há controle sobre quem pode acessar ou alterar recursos específicos.
-   Vulnerabilidade a ataques comuns: Sem proteção contra ataques como CSRF, XSS, injeção de SQL, etc.
-   Dados sensíveis não protegidos: Nenhuma encriptação ou proteção especial.

### Recomendações para Produção

-   Implementar autenticação robusta (ex: JWT, OAuth2).
-   Controlar autorização e permissões conforme os papéis de usuário.
-   Validar e sanitizar todas as entradas dos usuários.
-   Habilitar HTTPS com certificados válidos.
-   Registrar e monitorar acessos e erros.
-   Aplicar políticas de segurança adicionais (CORS, CSP, etc).

---

## Español

### Aviso de Seguridad

Este proyecto está desarrollado con fines académicos y de aprendizaje, sin incluir ninguna implementación de autenticación, autorización u otras medidas de seguridad esenciales para aplicaciones en producción.

### Riesgos

-   No hay autenticación: Cualquier usuario puede acceder, modificar y eliminar datos.
-   Falta de autorización: No hay control sobre quién puede acceder o modificar recursos específicos.
-   Vulnerabilidad a ataques comunes: Sin protección contra ataques como CSRF, XSS, inyección SQL, etc.
-   Datos sensibles no protegidos: Sin cifrado ni protección especial.

### Recomendaciones para Producción

-   Implementar autenticación robusta (ej: JWT, OAuth2).
-   Controlar autorización y permisos según roles.
-   Validar y sanitizar todas las entradas de usuario.
-   Habilitar HTTPS con certificados válidos.
-   Registrar y monitorear accesos y errores.
-   Aplicar políticas de seguridad adicionales (CORS, CSP, etc).

---

## English

### Security Notice

This project is developed for academic and learning purposes only, lacking any implementation of authentication, authorization, or other essential security measures required for production applications.

### Risks

-   No authentication: Anyone can access, modify, and delete data.
-   No authorization: No control over who can access or modify specific resources.
-   Vulnerable to common attacks: No protection against attacks such as CSRF, XSS, SQL injection, etc.
-   Sensitive data unprotected: No encryption or special safeguards.

### Recommendations for Production

-   Implement robust authentication (e.g., JWT, OAuth2).
-   Enforce authorization and permissions by roles.
-   Validate and sanitize all user inputs.
-   Enable HTTPS with valid certificates.
-   Log and monitor access and errors.
-   Apply additional security policies (CORS, CSP, etc).

---
