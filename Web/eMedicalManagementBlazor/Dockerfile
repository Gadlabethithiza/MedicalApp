#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["eMedicalManagementBlazor.csproj", "."]
RUN dotnet restore "eMedicalManagementBlazor.csproj"
COPY . .
#WORKDIR "/src/Web/eMedicalManagementBlazor"
RUN dotnet build "eMedicalManagementBlazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eMedicalManagementBlazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eMedicalManagementBlazor.dll"]
