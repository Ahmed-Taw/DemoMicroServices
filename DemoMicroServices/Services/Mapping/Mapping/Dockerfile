#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DemoMicroServices/Services/Mapping/Mapping/Mapping.csproj", "DemoMicroServices/Services/Mapping/Mapping/"]
COPY ["DemoMicroServices/CommunicationComponents/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "DemoMicroServices/CommunicationComponents/EventBusRabbitMQ/"]
COPY ["DemoMicroServices/CommunicationComponents/BaseEventBus/BaseEventBus.csproj", "DemoMicroServices/CommunicationComponents/BaseEventBus/"]
COPY ["DemoMicroServices/Services/Mapping/Mapping.Data.Entities/Mapping.Data.Entities.csproj", "DemoMicroServices/Services/Mapping/Mapping.Data.Entities/"]
COPY ["DemoMicroServices/Services/Mapping/Mapping.DataAccessLayer/Mapping.DataAccessLayer.csproj", "DemoMicroServices/Services/Mapping/Mapping.DataAccessLayer/"]
COPY ["DemoMicroServices/Services/Mapping/Mapping.Business/Mapping.Business.csproj", "DemoMicroServices/Services/Mapping/Mapping.Business/"]
#RUN dotnet restore "DemoMicroServices/Services/Mapping/Mapping/Mapping.csproj"
COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "DemoMicroServices.sln"
COPY . .
WORKDIR "/src/DemoMicroServices/Services/Mapping/Mapping"
RUN dotnet build "Mapping.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mapping.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mapping.dll"]