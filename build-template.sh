sudo apt-get install mono-complete -y
wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
dotnet new -u WebApiNSwagTemplate
mono nuget.exe pack Wigo4It.WebApiNSwagTemplate.CSharp.nuspec
dotnet new -i Wigo4It.WebApiNSwagTemplate.CSharp.0.0.1.nupkg
