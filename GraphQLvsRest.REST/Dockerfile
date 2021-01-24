#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["GraphQL-Dotnet-Api.REST/GraphQL-Dotnet-Api.REST.csproj", "GraphQL-Dotnet-Api.REST/"]
RUN dotnet restore "GraphQL-Dotnet-Api.REST/GraphQL-Dotnet-Api.REST.csproj"
COPY . .
WORKDIR "/src/GraphQL-Dotnet-Api.REST"
RUN dotnet build "GraphQL-Dotnet-Api.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQL-Dotnet-Api.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQL-Dotnet-Api.REST.dll"]