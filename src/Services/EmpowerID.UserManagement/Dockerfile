#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/EmpowerID.UserManagement/EmpowerID.UserManagement.csproj", "src/Services/EmpowerID.UserManagement/"]
COPY ["src/Core/EmpowerID.Core.Infrastructure/EmpowerID.Core.Infrastructure.csproj", "src/Core/EmpowerID.Core.Infrastructure/"]
COPY ["src/Core/EmpowerID.Core/EmpowerID.Core.csproj", "src/Core/EmpowerID.Core/"]
RUN dotnet restore "./src/Services/EmpowerID.UserManagement/./EmpowerID.UserManagement.csproj"
COPY . .
WORKDIR "/src/src/Services/EmpowerID.UserManagement"
RUN dotnet build "./EmpowerID.UserManagement.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmpowerID.UserManagement.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmpowerID.UserManagement.dll"]