#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DemoMicroServices/WebStatus/WebStatus.csproj", "DemoMicroServices/WebStatus/"]
#RUN dotnet restore "DemoMicroServices/WebStatus/WebStatus.csproj"
COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "DemoMicroServices.sln"
COPY . .
WORKDIR "/src/DemoMicroServices/WebStatus"
RUN dotnet build "WebStatus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebStatus.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebStatus.dll"]