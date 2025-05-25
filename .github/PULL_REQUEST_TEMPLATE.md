## 📌 Descripción del Cambio

### 🛠 Problema Resuelto
- **Issue relacionado**: Closes #123 (vincula el número del issue que resuelve).
- **Contexto**: 
  > Ejemplo: "Los usuarios no podían restablecer su contraseña porque el endpoint `/api/reset-password` no validaba correctamente el formato del correo electrónico, lo que generaba errores 500 en el servidor."

### 🚀 Nueva Funcionalidad
- **Descripción técnica**: 
  > Ejemplo: "Se ha agregado un servicio de validación de correos electrónicos usando expresiones regulares en el módulo `AuthService`. Además, se implementó un nuevo método `IsValidEmailAsync` que verifica dominios bloqueados en la base de datos."
- **Impacto en el usuario**: 
  > Ejemplo: "Los usuarios ahora recibirán un mensaje claro si su correo no es válido o si el dominio está bloqueado (ej: `@spam.com`)."

### 📄 Cambios Realizados
- **Archivos modificados**:
  - `src/Controllers/AuthController.cs` (lógica de validación).
  - `src/Services/AuthService.cs` (nuevo método).
- **Archivos agregados**:
  - `tests/UnitTests/AuthServiceTests.cs` (pruebas para el nuevo método).

---

## ✅ Checklist

Antes de solicitar revisión, verifica lo siguiente:
- [ ] **Pruebas locales**: Ejecuté `dotnet test` y todos los tests pasan (incluyendo los nuevos).
- [ ] **Documentación**: Actualicé el archivo `docs/AUTH_API.md` con los nuevos parámetros del endpoint.
- [ ] **Código limpio**: Seguí las guías de estilo (ej: nombres de variables en `PascalCase`).
- [ ] **Revisión de pares**: Asigné a `@usuario-dev` como revisor principal.
- [ ] **Dependencias**: No introduje nuevas dependencias sin aprobación del equipo.
- [ ] **Linting**: Ejecuté `dotnet format` para asegurar el formato consistente.
- [ ] **Migrations**: Si hay cambios en la base de datos, adjunté el script SQL de migración.

---

## 🖼 Capturas de Pantalla / GIFs (si aplica)

### Caso 1: Error de correo inválido
**Antes**:  
![Error genérico](https://ejemplo.com/error-antiguo.png)  
**Después**:  
![Mensaje claro](https://ejemplo.com/error-nuevo.png)

### Caso 2: Flujo de restablecimiento exitoso
![GIF del flujo](https://ejemplo.com/flujo-exitoso.gif)

---

## 🔍 Pasos para probar los cambios
1. Clona la rama: `git checkout feature/email-validation`.
2. Ejecuta el servidor: `dotnet run --project src/Api`.
3. Usa Postman para enviar una solicitud POST a `http://localhost:5000/api/reset-password` con:
   ```json
   {
     "email": "usuario@spam.com"
   }