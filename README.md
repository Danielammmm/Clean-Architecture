# FP.API - Clean Architecture Base

## 📌 Descripción
Este proyecto implementa **Clean Architecture** con una estructura modular que permite escalabilidad y facilidad de mantenimiento. Actualmente, proporciona un servicio de configuración expuesto a través de una API.

## 🏗 Estructura del Proyecto
El código está organizado en **cuatro capas principales**:

- **Domain**: Contiene las entidades y contratos del sistema.
- **Application**: Define la lógica de negocio y las interfaces de los servicios.
- **Infrastructure**: Implementa la lógica concreta, como el acceso a datos y la configuración.
- **API (Presentation)**: Expone los endpoints de la aplicación.

## 🚀 Características Implementadas
- **Carga de configuración desde `appsettings.json`**.
- **Exposición de la configuración a través del endpoint `/api/config`**.
- **Uso de Swagger para documentación de la API**.
- **Logging con `ILogger<T>` para registrar eventos importantes**.

## ⚙ Instalación y Ejecución
### 1. Clonar el Repositorio
```sh
 git clone https://github.com/tu-repo/FP.API.git](https://github.com/Danielammmm/Clean-Architecture.git
 cd FP.API
```

### 2. Restaurar Dependencias
```sh
dotnet restore
```

### 3. Ejecutar la Aplicación
```sh
dotnet run --project FP.API
```

### 4. Probar la API en Swagger
Abrir en el navegador:
```
https://localhost:5001/swagger
```

## 📌 Siguientes Mejoras
- Implementar **Dependency Injection** en otros servicios.
- Agregar **pruebas unitarias** con TDD.
- Aplicar **Single Responsibility Principle** en nuevas funcionalidades.
- Integrar almacenamiento con una base de datos.


