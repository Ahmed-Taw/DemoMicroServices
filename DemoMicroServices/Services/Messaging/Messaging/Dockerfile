#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DemoMicroServices/Services/Messaging/Messaging/Messaging.csproj", "DemoMicroServices/Services/Messaging/Messaging/"]
#RUN dotnet restore "DemoMicroServices/Services/Messaging/Messaging/Messaging.csproj"
COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "DemoMicroServices.sln"
COPY . .
WORKDIR "/src/DemoMicroServices/Services/Messaging/Messaging"
RUN dotnet build "Messaging.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messaging.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messaging.dll"]
