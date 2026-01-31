# Prueba técnica Desarrollador Full-stack .NET & Angular

## Características del proyecto
- Implementación de una API RESTful con .NET 10.0
- Integración con base de datos SQL Server utilizando Entity Framework Core
- Interfaz de usuario sencilla y dinámica
- Manejo de errores y validaciones

Este proyecto contiene una aplicacón web desarrollada con .NET, en la cual se responden a los requerimientos planteados en la prueba.
## Requisitos previos
- [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Visual Studio 2022 o superior / Visual Studio Code
- SQL Server (puede ser SQL Server Express)
- Navegador web moderno (Chrome, Firefox, Edge)

## Respuesta de preguntas teóricas
1 Estrategia de caché: Se eligió IMemoryCache para almacenar en caché los datos más solicitados, ya que es fácil de implementar
y ofrece un buen rendimiento para aplicaciones web. Esto reduce la carga en la base de datos y mejora los tiempos de respuesta, 
adicionalmente funciona mejor cn datos que cambian con poca frecuencia y que puede ser costoso generar.

2. Solución de Concurrencia: Se implementó un enfoque optimista utilizando un campo de "RowVersion" en las entidad Tareas de la 
base de datos. Esto permite detectar conflictos cuando múltiples usuarios intentan actualizar la misma tarea simultáneamente, 
bloqueando así el acceso.

3. Background Service: Se utilizó un servicio en segundo plano (IHostedService) para manejar tareas periódicas, 
como el envío de notificaciones, este proceso está parametrizado para que sea ejecutado cada 2 minutos realizando anticipadamente
una validación del estado de la misma.