#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:9.0
ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:9.0

FROM $DOTNET_RUNTIME AS base
USER $APP_UID
WORKDIR /app
EXPOSE 811
EXPOSE 633

FROM $DOTNET_SDK AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ManageStudents.API/ManageStudents.API.csproj", "ManageStudents.API/"]
COPY ["ManageStudents.Contracts/ManageStudents.Contracts.csproj", "ManageStudents.Contracts/"]
COPY ["ManageStudents.Domain.Entities/ManageStudents.Domain.Entities.csproj", "ManageStudents.Domain.Entities/"]
COPY ["ManageStudents.Domain/ManageStudents.Domain.csproj", "ManageStudents.Domain/"]
COPY ["ManageStudents.Helpers/ManageStudents.Helpers.csproj", "ManageStudents.Helpers/"]
COPY ["ManageStudents.Infrastructure/ManageStudents.Infrastructure.csproj", "ManageStudents.Infrastructure/"]

COPY ["ManageStudents.Tests/ManageStudents.Tests.csproj", "ManageStudents.Tests/"]

RUN dotnet restore "./ManageStudents.API/ManageStudents.API.csproj"
COPY . .
WORKDIR "/src/ManageStudents.API"
RUN dotnet build "./ManageStudents.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ManageStudents.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManageStudents.API.dll"]
