FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY src/ServicoAutenticacao.Api/ServicoAutenticacao.Api.csproj src/ServicoAutenticacao.Api/
COPY src/ServicoAutenticacao.Domain/ServicoAutenticacao.Domain.csproj src/ServicoAutenticacao.Domain/
COPY src/ServicoAutenticacao.Infra.Data/ServicoAutenticacao.Infra.Data.csproj src/ServicoAutenticacao.Infra.Data/
COPY src/ServicoAutenticacao.Infra.CrossCutting/ServicoAutenticacao.Infra.CrossCutting.csproj src/ServicoAutenticacao.Infra.CrossCutting/
COPY src/ServicoAutenticacao.Infra.IoC/ServicoAutenticacao.Infra.IoC.csproj src/ServicoAutenticacao.Infra.IoC/

RUN dotnet restore src/ServicoAutenticacao.Api/ServicoAutenticacao.Api.csproj

COPY . .

WORKDIR /src/src/ServicoAutenticacao.Api
RUN dotnet build ServicoAutenticacao.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish ServicoAutenticacao.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER root

RUN apt-get update && apt-get install -y wget \
    && wget https://github.com/jwilder/dockerize/releases/download/v0.6.1/dockerize-linux-amd64-v0.6.1.tar.gz \
    && tar -C /usr/local/bin -xzvf dockerize-linux-amd64-v0.6.1.tar.gz \
    && rm dockerize-linux-amd64-v0.6.1.tar.gz

USER $APP_UID

ENTRYPOINT ["dockerize", "-wait", "tcp://services-autenticacao.db:5432", "-timeout", "60s", "dotnet", "ServicoAutenticacao.Api.dll"]
