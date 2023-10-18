#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/APIs/eMedicalManagementMinimalAPI/eMedicalManagementMinimalAPI.csproj", "Services/APIs/eMedicalManagementMinimalAPI/"]
COPY ["Core/eMedicalManagementMinimalAPI.DataAccess/eMedicalManagementMinimalAPI.DataAccess.csproj", "Core/eMedicalManagementMinimalAPI.DataAccess/"]
RUN dotnet restore "Services/APIs/eMedicalManagementMinimalAPI/eMedicalManagementMinimalAPI.csproj"
COPY . .
WORKDIR "/src/Services/APIs/eMedicalManagementMinimalAPI"
RUN dotnet build "eMedicalManagementMinimalAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eMedicalManagementMinimalAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eMedicalManagementMinimalAPI.dll"]
