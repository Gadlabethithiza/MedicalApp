FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["eMedicalManagementReact.csproj", "."]
RUN dotnet restore "eMedicalManagementReact.csproj"
COPY . .
#WORKDIR "/src/Web/eMedicalManagementRazor"
RUN dotnet build "eMedicalManagementReact.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eMedicalManagementReact.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM node AS node-builder
WORKDIR /node
COPY ./ClientApp /node
RUN npm install
RUN npm run build

FROM base AS final
WORKDIR /app

RUN mkdir /app/wwwroot 
COPY --from=publish /app/publish .
COPY --from=node-builder /node/build ./wwwroot
ENTRYPOINT ["dotnet", "eMedicalManagementReact.dll"]
