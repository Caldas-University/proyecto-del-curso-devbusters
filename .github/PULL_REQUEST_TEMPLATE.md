## 📌 Descripción del Cambio

### 🛠 Problema Resuelto

* **Issue relacionado**: N/A (implementación inicial del caso de uso CU-GE-02.1).
* **Contexto**:

  > Se implementó el primer sprint del caso de uso **CU-GE-02: Programar actividades dentro del evento**, permitiendo a los organizadores crear actividades como sesiones, dinámicas o conferencias, asociadas a un evento específico.

---

### 🚀 Nueva Funcionalidad

* **Descripción técnica**:

  > Se agregó soporte para la creación de actividades con validación y persistencia. Incluye capa de presentación (controller), DTOs, servicio de aplicación, entidad de dominio, repositorio e integración con Entity Framework Core.
  > También se configuró AutoMapper para convertir entre DTOs y entidades.

* **Impacto en el usuario**:

  > Los organizadores ahora pueden registrar actividades en eventos ya existentes desde el endpoint `POST /api/activity`, y recibir una respuesta clara con los datos almacenados.

---

### 📄 Cambios Realizados

* **Archivos agregados**:

  * `Application/DTO/CreateRequestActivityDTO.cs`
  * `Application/DTO/CreateResponseActivityDTO.cs`
  * `Application/Contracts/Services/IActivityServiceApp.cs`
  * `Application/Services/ActivityServiceApp.cs`
  * `Application/Mappers/ActivityProfile.cs`
  * `Domain/Repositories/IActivityRepository.cs`
  * `Infrastructure/Repositories/ActivityRepository.cs`
  * `Api/Controllers/ActivityController.cs`

* **Archivos modificados**:

  * `Infrastructure/Persistence/EventManagementDbContext.cs` (agregado `DbSet<Activity>`)
  * `Program.cs` (registro de `IActivityServiceApp` y `IActivityRepository`)
  * `Infrastructure/Migrations/` (se generó y aplicó la migración `AddActivityTable`)

---

## ✅ Checklist

Antes de solicitar revisión, verifica lo siguiente:

* [x] **Pruebas locales**: Ejecuté el proyecto y validé la creación y consulta de actividades.
* [x] **Migraciones**: Se generó y aplicó la migración `AddActivityTable` con EF Core.
* [x] **AutoMapper**: Se configuró correctamente el perfil `ActivityProfile`.
* [x] **Dependencias**: No se agregaron nuevas dependencias externas.

---

## 🖼 Capturas de Pantalla / GIFs (si aplica)

### Caso: Creación de actividad exitosa

**Solicitud POST**:

```json
{
  "name": "Taller de Diseño",
  "type": "Dinámica",
  "date": "2025-08-01T10:00:00",
  "duration": 60,
  "description": "Exploración creativa de ideas",
  "location": "Sala A",
  "eventId": "REEMPLAZAR_CON_ID_REAL"
}
```

**Respuesta esperada**:

```json
{
  "id": "generated-guid",
  "name": "Taller de Diseño",
  "type": "Dinámica",
  "date": "2025-08-01T10:00:00",
  "duration": 60,
  "description": "Exploración creativa de ideas",
  "location": "Sala A"
}
```

---

## 🔍 Pasos para probar los cambios

1. Clona esta rama:

   ```bash
   git checkout feature/create-activity
   ```

2. Ejecuta migraciones:

   ```bash
   dotnet ef database update --project EventManagement.Infrastructure --startup-project EventManagement.Api
   ```

3. Levanta el servidor:

   ```bash
   dotnet run --project EventManagement.Api
   ```

4. Abre Swagger en `https://localhost:5001/swagger`.

5. Usa el endpoint `POST /api/event` para crear un evento, copia su `id`.

6. Usa `POST /api/activity` para crear una actividad asociada.
