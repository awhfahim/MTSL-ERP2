FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SewingMachineManagement.HttpApi/SewingMachineManagement.HttpApi.csproj", "SewingMachineManagement.HttpApi/"]
RUN dotnet restore "SewingMachineManagement.HttpApi/SewingMachineManagement.HttpApi.csproj"
COPY . .
WORKDIR "/src/SewingMachineManagement.HttpApi"
RUN dotnet build "SewingMachineManagement.HttpApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SewingMachineManagement.HttpApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SewingMachineManagement.HttpApi.dll"]
