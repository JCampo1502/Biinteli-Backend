
# Biinteli 
# Proyecto Dotnet Web API

## Descripción del Proyecto

Este proyecto es una API RESTful construida con .NET que permite realizar peticiones para obtener información sobre distintos viajes almacenados en una base de datos. La aplicación implementa un CRUD sencillo para las rutas de **Transport**, **Flight** y **Journeys**, utilizando una arquitectura de tres capas: **API**, **Business** y **DataAccess**.

## Desafíos y Aprendizajes

Lamentablemente, no logré implementar pruebas unitarias ni la persistencia/acceso a datos como parte del proyecto. Reconozco que fue un reto tratar de desempolvar algunos conocimientos, pero esta experiencia ha sido un gran ejercicio.

## Arquitectura del Proyecto

La arquitectura del proyecto se divide en tres capas principales:

1. **API**: 
   - Contiene la implementación de la API RESTful.
   - Incluye **DTOs** (Data Transfer Objects) para la transferencia de datos.
   - Utiliza **Mapping** para convertir entre entidades y DTOs.

2. **Business**: 
   - Contiene las **entidades** del dominio.
   - Define las **interfaces** de los repositorios que son utilizadas para la gestión de datos.

3. **DataAccess**: 
   - Maneja la información de acceso a la base de datos.
   - Contiene las **migraciones** para la gestión de cambios en la estructura de la base de datos.
  
### Database
![DB](https://github.com/user-attachments/assets/159ccfa6-5ebd-46c5-9264-872ba5997979)


## Migraciones

Las migraciones se subieron al repositorio y se encuentran en la carpeta: `DataAccess/Data/Migrations`. Si es necesario eliminarlas, se recomienda utilizar el siguiente comando para volver a generarlas:

```bash
dotnet ef migrations add InitialCreateMig --project .\\DataAccess --startup-project .\\Biinteli --output-dir .\\Data\Migrations
```

Para actualizar la base de datos con las migraciones, utiliza el siguiente comando:

```bash
dotnet ef database update --project .\\DataAccess\\ --startup-project .\\Biinteli
```

La conexión con la base de datos se encuentra en la siguiente ruta: `Api/appsettings.Development.json`, en el apartado:

```json
"ConnectionStrings": {
   "ConnectionMysql": "server=localhost;user=root;password=123456;database=javier_campo;"
}
```

Por defecto, se establece en modo **Development**.

## Configuración

La configuración del Rate Limiting, CORS y scopes se encuentra en la carpeta: `Api/Extensions/ServicesExtensions.cs`.

## Implementación de Patrones

El proyecto implementa los siguientes patrones:

- **Repository**: Facilita la separación de la lógica de acceso a datos y permite realizar operaciones sobre las entidades de manera más estructurada.
- **Unit of Work**: Permite coordinar la escritura de múltiples repositorios, asegurando que se realicen de manera transaccional.

## Rutas y Endpoints

El proyecto utiliza un **controlador genérico** que proporciona funcionalidad común para cada entidad. Los endpoints implementados son los siguientes:

- **GET /{id}**: Obtiene una entidad por su ID.
- **GET /GetAll**: Obtiene todas las entidades.
- **POST /Add**: Añade una nueva entidad.
- **DELETE /{id}**: Elimina una entidad por su ID.
- **PUT /**: Actualiza una entidad existente.

### Endpoints Específicos para Journeys

- **GET /FilterByOriginAndDestination**: Permite filtrar los viajes por origen y destino.

```csharp
[HttpGet("FilterByOriginAndDestination")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<ActionResult<JourneyDto>> FilterByOriginAndDestination(
    [FromQuery] string origin, 
    [FromQuery] string destination
)
```
![swagger01](https://github.com/user-attachments/assets/7533393b-52ae-4d8e-bee9-f270e54eac76)

![swagger02](https://github.com/user-attachments/assets/1cb1d9d1-ea75-4f6a-9b49-064f2d4ed6a5)


## Dependencias

- **dotnet-ef**: Para la gestión de migraciones y acceso a la base de datos.
- **Microsoft.EntityFrameworkCore.Design**: Herramientas para el diseño y la gestión de EF Core.
- **Pomelo.EntityFrameworkCore.MySql**: Para la conexión con MySQL.
- **Microsoft.EntityFrameworkCore**: Proporciona funcionalidades básicas para trabajar con EF Core.
- **Microsoft.AspNetCore.Cors**: Para la configuración de CORS.
- **AspNetCoreRateLimit**: Para la implementación del Rate Limiting.
- **AutoMapper.Extensions.Microsoft.DependencyInjection**: Integración de AutoMapper con la inyección de dependencias en ASP.NET Core.


## Conclusiones

Este proyecto ha sido una oportunidad valiosa para aplicar y profundizar mis conocimientos en el desarrollo de APIs con .NET, así como para aprender sobre la organización y estructura de un proyecto en capas.
