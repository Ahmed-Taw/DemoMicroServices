#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DemoMicroServices/Services/Formulary/Formulary/Formulary.csproj", "DemoMicroServices/Services/Formulary/Formulary/"]
COPY ["DemoMicroServices/Services/Formulary/Formulary.DataAccesslayer/Formulary.DataAccesslayer.csproj", "DemoMicroServices/Services/Formulary/Formulary.DataAccesslayer/"]
COPY ["DemoMicroServices/Services/Formulary/Formulary.Data.Entities/Formulary.Data.Entities.csproj", "DemoMicroServices/Services/Formulary/Formulary.Data.Entities/"]
COPY ["DemoMicroServices/CommunicationComponents/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "DemoMicroServices/CommunicationComponents/EventBusRabbitMQ/"]
COPY ["DemoMicroServices/CommunicationComponents/BaseEventBus/BaseEventBus.csproj", "DemoMicroServices/CommunicationComponents/BaseEventBus/"]
COPY ["DemoMicroServices/Services/Formulary/Formulary.Business/Formulary.Business.csproj", "DemoMicroServices/Services/Formulary/Formulary.Business/"]
#RUN dotnet restore "DemoMicroServices/Services/Formulary/Formulary/Formulary.csproj"

COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "DemoMicroServices.sln"

COPY . .
WORKDIR "/src/DemoMicroServices/Services/Formulary/Formulary"
RUN dotnet build "Formulary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Formulary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Formulary.dll"]