# Sistema de Procesamiento de Archivos

## Descripción del Proyecto
Este proyecto es un sistema de procesamiento de archivos que permite guardar y leer archivos mediante una API REST, aplicando principios de arquitectura limpia, desarrollo basado en pruebas (TDD), inyección de dependencias (DI) y el principio de responsabilidad única (SRP).

---

## 📂 Estructura del Proyecto
```
📂 FP.CleanArchitecture
├── 📂 FP.API           # API principal (Presentación)
├── 📂 FP.Application   # Lógica de negocio
├── 📂 FP.Domain        # Entidades y contratos
├── 📂 FP.Infrastructure # Implementaciones concretas
├── 📂 FP.Tests         # Pruebas unitarias con MSTest
```

Cada módulo sigue **Clean Architecture** y está diseñado para ser desacoplado y reutilizable.

---

## 🔹 Técnicas Aplicadas
-  **Clean Architecture**: Organización del código en capas separadas. [**Descargar investigación**](https://github.com/Danielammmm/Clean-Architecture/blob/92c36b2c59002bdfa8eb078e73f9a0b83b6de825/Investigaciones%20y%20aplicaciones/CA.docx) 
-  **TDD (Test-Driven Development)**: Desarrollo basado en pruebas antes de la implementación final. [**Descargar investigación**](https://github.com/Danielammmm/Clean-Architecture/blob/92c36b2c59002bdfa8eb078e73f9a0b83b6de825/Investigaciones%20y%20aplicaciones/TDD.docx)  
-  **Dependency Injection (DI)**: Uso de `ILogger<T>` y `IConfigurationService` en los servicios.  [**Descargar investigación**](https://github.com/Danielammmm/Clean-Architecture/blob/92c36b2c59002bdfa8eb078e73f9a0b83b6de825/Investigaciones%20y%20aplicaciones/DI.docx) 
-  **SRP (Single Responsibility Principle)**: `FileManager` maneja archivos mientras `FileService` se encarga del servicio.  [**Descargar investigación**](https://github.com/Danielammmm/Clean-Architecture/blob/92c36b2c59002bdfa8eb078e73f9a0b83b6de825/Investigaciones%20y%20aplicaciones/SRP.docx) 

---

## 🚀 Cómo Ejecutar el Proyecto

1. **Clonar el repositorio**
```sh
git clone <repo-url>
cd FP.CleanArchitecture
```

2. **Ejecutar la API**
```sh
dotnet run --project FP.API
```

3. **Probar en Swagger**
Abrir `https://localhost:xxxx/swagger` para probar los endpoints:
- `GET /api/config` → Cargar configuración.
- `POST /api/files/save` → Guardar archivo.
- `GET /api/files/read` → Leer archivo.

---

## 🛠 Tecnologías Usadas
- **.NET 9**
- **MSTest** (para pruebas)
- **Swagger** (documentación de API)
- **Microsoft.Extensions.Logging** (logging)
- **Microsoft.Extensions.Configuration** (manejo de configuración)

---

