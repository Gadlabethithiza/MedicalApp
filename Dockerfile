#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/APIs/eMedicalManagementMinimalAPI/eMedicalManagementMinimalAPI.csproj", "Services/APIs/eMedicalManagementMinimalAPI/"]
COPY ["Core/eMedicalManagementMinimalAPI.DataAccess/eMedicalManagementMinimalAPI.DataAccess.csproj", "Core/eMedicalManagementMinimalAPI.DataAccess/"]
#COPY ["Web/eMedicalManagementMVC/eMedicalManagementMVC.csproj", "Web/eMedicalManagementMVC/"]
#RUN dotnet restore "Web/eMedicalManagementMVC/eMedicalManagementMVC.csproj"
RUN dotnet restore "Services/APIs/eMedicalManagementMinimalAPI/eMedicalManagementMinimalAPI.csproj"
#RUN dotnet restore "eMedicalManagementMinimalAPI/eMedicalManagementMinimalAPI.csproj"
COPY . .
WORKDIR "/src/Services/APIs/eMedicalManagementMinimalAPI"
RUN dotnet build "eMedicalManagementMinimalAPI.csproj" -c Release -o /app

#SOLUTION 1
#COPY *.csproj ./
#RUN dotnet restore



FROM build AS publish
RUN dotnet publish "eMedicalManagementMinimalAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "eMedicalManagementMinimalAPI.dll"]

