# OpenAPI Templates

ASP.NET Core Web API Template with Swagger toolchain

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

* .NET core https://github.com/dotnet/core/releases
* nuget command line tools available at https://www.nuget.org/downloads

## Install template
```
nuget pack Wigo4It.WebApiNSwagTemplate.CSharp.nuspec
dotnet new -i Wigo4It.WebApiNSwagTemplate.CSharp::*
```
The template **W4WebAPiNSwag** should now appear in the .NET core template list

| Templates |  Short Name | Language |Tags|
|:---|:---|:---|:---|
|Console Application|console|[C#], F#, VB|Common/Console| 
Class library| classlib| [C#], F#, VB |Common/Library|
|.......|....... |....... |...... |
|**WIGO4IT NSwag OpenAPI**| **W4WebApiNSwag**|**[C#]**| **WebAPI/OpenAPI/Swagger**
ASP . NET Core with Angular|angular|[C#]|Web/MVC/SPA|
|.......|....... |....... |...... |

## Uninstall template
```
dotnet new -u Wigo4It.WebApiNSwagTemplate.CSharp
```

## Using the template

Create a folder that reflects the name of your api i.e. MyApi (and your namespace).
From within the folder execute the following command:

```
dotnet new W4WebApiNSwag
```

MyApi.csproj should now have been created, and the namespace should also reflect MyAPI in the source code files.


## Built With

* [VSCODE](hhttps://code.visualstudio.com/) - The IDE used

## Contributing

Pull requests are accepted

## Authors

* **Sjef van Leeuwen** - *Initial work* - [github](https://github.com/sjefvanleeuwen)

## License

This project is licensed under the GPL-V3 License - see the [LICENSE.md](LICENSE.md) file for details
