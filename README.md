# OpenAPI Templates (Entity Framework with Rebus)

ASP.NET Core Web API Template with Swagger, ODATA and Entity Framework toolchain.  
Rebus is included as a lean service bus.

![Rebus lean service bus](./doc/rebus.png)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

* .NET core https://github.com/dotnet/core/releases
* nuget command line tools available at https://www.nuget.org/downloads

## Install template
```
nuget pack Wigo4It.WebApiNSwagEfTemplate.CSharp.nuspec
dotnet new -i Wigo4It.WebApiNSwagEfTemplate.CSharp.1.0.0.nupkg
```
The template **W4WebAPiNSwagEfRebus** should now appear in the .NET core template list

| Templates |  Short Name | Language |Tags|
|:---|:---|:---|:---|
|Console Application|console|[C#], F#, VB|Common/Console| 
Class library| classlib| [C#], F#, VB |Common/Library|
|.......|....... |....... |...... |
|**NSwag EF with Rebus OpenAPI**| **W4WebApiNSwagEfRebus**|**[C#]**| **WebAPI/OpenAPI/Swagger/EF/Rebus**
ASP . NET Core with Angular|angular|[C#]|Web/MVC/SPA|
|.......|....... |....... |...... |

You can also run the build-template.bat file from the command line.

## Uninstall template
```
dotnet new -u WebApiNSwagEfRebusTemplate.CSharp
```

## Using the template

Create a folder that reflects the name of your api i.e. my-api (and your namespace).
From within the folder execute the following command:

```
dotnet new W4WebApiNSwagEfRebus
```

may-api.csproj should now have been created, and the namespace should also reflect my-api in the source code files.

### Building Docker Images

The docker compose yaml will automatically reflect your namespaces/projectname.

```
docker-compose up --build -d
```

The API should now be reachable from:

* [SWAGGER](http://localhost:5080/swagger) - Swagger API documentation page
* [REDOC](http://localhost:5080/redoc) - Redoc API documentation page

## Available API Endpoints

### ODATA

OData is added as a common data format, often used by low code platforms.
* OData JSON Schema http://localhost:5080/odata
* OData Metadata Schema http://localhost:5080/odata/$metadata
* OData Retrieve Data Sample List http://localhost:5080/odata/sampleefodata
* OData Retrieve Sata Sample http://localhost:5080/odata/sampleefodata/1

### OpenAPI

* OpenAPI JSON Schema http://localhost:5080/swagger/v1/swagger.json
* OpenAPI Swagger UI http://localhost:5080/swagger
* OpenAPI Retrieve Data Sample List http://localhost:5080/api/sampleef
* OpenAPI Retrieve Sata Sample http://localhost:5080/api/sampleef/1

### Metrics (APP-Metrics)

 * http://localhost:5080/metrics	Exposes a metrics snapshot using the configured metrics formatter.
 * http://localhost:5080/metrics-text	Exposes a metrics snapshot using the configured text formatter.
 * http://localhost:5080/env	Exposes environment information about the application e.g. OS, Machine Name, Assembly Name, Assembly Version etc.

## Mapper

There's a simple mapper (AutoMapper) example. The Entity Book, is mapped to a DTO. As a sample
it changes the format of the ISBN, populates an extra field in the DTO with displayedPrice. 
Also introduces a last query date time.

```csharp

CreateMap<Book, BookDTO>()
    .ForMember(dest => dest.ISBN, m => m.MapFrom(src => src.ISBN.Replace("-","")))
    .ForMember(dest => dest.PriceDisplay, m => m.MapFrom(p=> "$"+ p.Price.ToString()))
    .ForMember(p=>p.LastQuery,m=>m.UseValue(DateTime.Now));

```
## Metrics Monitoring

As part of OpenAPM standard we suggest to use Prometheus as a distributor to Grafana dashboards. 

Below you will find an example of the openAPM eco system

![OpenAPM](./doc/openAPM-Landscape.png)

Pleas visit [OpenAPM](https://openaom.io) for more information.

### Metrics

[APP-METRICS](https://www.app-metrics.io/web-monitoring/aspnet-core/) Metrics Dashboard for .NET Core
The sample project contains a couple of counters for the Sample API Controller

#### Get Book

```json
        {
          "name": "Get Book Timer|server:IDE2,app:template-identifier,env:development",
          "unit": "items",
          "activeSessions": 0,
          "count": 3,
          "durationUnit": "ms",
          "histogram": {
            "lastValue": 0.7673,
            "max": 69.5817,
            "mean": 23.248790664825354,
            "median": 2.1208,
            "min": 0.7673,
            "percentile75": 69.5817,
            "percentile95": 69.5817,
            "percentile98": 69.5817,
            "percentile99": 69.5817,
            "percentile999": 69.5817,
            "sampleSize": 3,
            "stdDev": 31.797149030432504,
            "sum": 72.469799999999992
          }
```

#### Get Books

reports the timer on querying books from the database.

```json
        {
          "name": "Get Books Timer|server:IDE2,app:template-identifier,env:development",
          "unit": "items",
          "activeSessions": 0,
          "count": 2,
          "durationUnit": "ms",
          "histogram": {
            "lastValue": 21.156399999999998,
            "max": 244.2301,
            "mean": 120.1980241848166,
            "median": 21.156399999999998,
            "min": 21.156399999999998,
            "percentile75": 244.2301,
            "percentile95": 244.2301,
            "percentile98": 244.2301,
            "percentile99": 244.2301,
            "percentile999": 244.2301,
            "sampleSize": 2,
            "stdDev": 110.83473390481015,
            "sum": 265.3865
        }
```
## Built With

* [VSCODE](https://code.visualstudio.com/) - The IDE used
* [DOCKER](https://www.docker.com/) - Build, Ship, and Run Any App, Anywhere

## Contributing

Pull requests are accepted

## Authors

* **Sjef van Leeuwen** - *Initial work* - [github](https://github.com/sjefvanleeuwen)

## License

This project is licensed under the GPL-V3 License - see the [LICENSE](LICENSE) file for details
