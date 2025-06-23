# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 80

# Etapa de build (SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copia a solução e os projetos com a estrutura original
COPY src/ServicoDomestico.Autenticacao.sln ./
COPY src/ServicoDomestico.Autenticacao.Api/ ./ServicoDomestico.Autenticacao.Api/
COPY src/ServicoDomestico.Autenticacao.Application/ ./ServicoDomestico.Autenticacao.Application/
COPY src/ServicoDomestico.Autenticacao.Domain/ ./ServicoDomestico.Autenticacao.Domain/
COPY src/ServicoDomestico.Autenticacao.Infrastructure/ ./ServicoDomestico.Autenticacao.Infrastructure/

# Restaura os pacotes para toda a solução
RUN dotnet restore ServicoDomestico.Autenticacao.sln

# Copia o restante do código mantendo estrutura
COPY src/. ./

# Publica o projeto API
WORKDIR /src/ServicoDomestico.Autenticacao.Api
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ServicoDomestico.Autenticacao.Api.dll"]
