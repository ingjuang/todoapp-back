# TodoApp-Back

Este es el backend de la aplicación TodoApp, desarrollado con .NET 9 y C# 13.0. Proporciona una API para gestionar tareas utilizando HMAC para la autenticación.

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalados los siguientes requisitos:

1. **.NET 9 SDK**: Puedes descargarlo e instalarlo desde [aquí](https://dotnet.microsoft.com/download/dotnet/9.0).
2. **Visual Studio 2022**: Descárgalo e instálalo desde [aquí](https://visualstudio.microsoft.com/vs/).

## Configuración del Proyecto

1. **Clonar el repositorio**:

   ```sh
   git clone https://github.com/ingjuang/todoapp-back.git
   ```

2. **Configurar la cadena de conexión (Opcional)**:
   Abre el archivo `appsettings.json` en el proyecto `TodoApp-Back.API` y actualiza la cadena de conexión para que apunte a tu instancia de SQL Server:

   ```sh
   { "ConnectionStrings": { "DefaultConnection": "Server=tu-servidor;Database=TodoAppDb;User Id=tu-usuario;Password=tu-contraseña;" }, "HmacSettings": { "SecretKey": "tu-clave-secreta" } }
   ```
3. **Restaurar paquetes NuGet**:
   Abre el proyecto en Visual Studio 2022 y restaura los paquetes NuGet:

   ```sh
   dotnet restore
   ```

## Ejecución del Proyecto

1. **Compilar y ejecutar**:
   En Visual Studio 2022, selecciona `TodoApp-Back.API` como el proyecto de inicio y presiona `F5` para compilar y ejecutar el proyecto.

2. **Acceder a Swagger**:
   Una vez que el proyecto esté en ejecución, abre tu navegador y navega a `https://localhost:7153/swagger` para acceder a la interfaz de Swagger y probar la API.

## Uso de la API

La API proporciona los siguientes endpoints para gestionar tareas:

- `GET /api/task`: Obtiene todas las tareas.
- `GET /api/task/{id}`: Obtiene una tarea por su ID.
- `POST /api/task`: Crea una nueva tarea.
- `PUT /api/task/{id}`: Actualiza una tarea existente.
- `DELETE /api/task/{id}`: Elimina una tarea por su ID.

## Autenticación HMAC

La API utiliza HMAC para la autenticación. Asegúrate de incluir el encabezado `X-HMAC-Signature` en tus solicitudes con la firma HMAC generada.
