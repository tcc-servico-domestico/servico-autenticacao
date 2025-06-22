# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 80

# Etapa de build (SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copia a solução e os projetos (observe o caminho com 'src/')
COPY src/ServicoDomestico.Autenticacao.sln ./
COPY src/ServicoDomestico.Autenticacao.Api/ServicoDomestico.Autenticacao.Api.csproj ./ServicoDomestico.Autenticacao.Api/
COPY src/ServicoDomestico.Autenticacao.Application/ServicoDomestico.Autenticacao.Application.csproj ./ServicoDomestico.Autenticacao.Application/
COPY src/ServicoDomestico.Autenticacao.Domain/ServicoDomestico.Autenticacao.Domain.csproj ./ServicoDomestico.Autenticacao.Domain/
COPY src/ServicoDomestico.Autenticacao.Infrastructure/ServicoDomestico.Autenticacao.Infrastructure.csproj ./ServicoDomestico.Autenticacao.Infrastructure/

RUN dotnet restore

# Copia o restante do código
COPY src/. ./

WORKDIR /src/ServicoDomestico.Autenticacao.Api
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ServicoDomestico.Autenticacao.Api.dll"]
