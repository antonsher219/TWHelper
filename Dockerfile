FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./
COPY TWHelp/TWHelp.csproj TWHelp/
COPY PythonAPI/PythonAPI.pyproj PythonAPI/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Core/Domain.csproj Core/
COPY ElasticSearch/ElasticSearch.csproj ElasticSearch/
RUN dotnet restore
COPY . .
WORKDIR /src/TWHelp
RUN dotnet build -c $Configuration -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TWHelp.dll"]