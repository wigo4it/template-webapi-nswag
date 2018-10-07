sudo apt-get install mono-complete -y
wget https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
dotnet new -u WebApiNSwagEfTemplate
mono nuget.exe pack WebApiNSwagEfTemplate.nuspec
dotnet new -i WebApiNSwagEfTemplate.0.0.1.nupkg
