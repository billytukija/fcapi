#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Ensure we listen on any IP Address 
ENV DOTNET_URLS=http://+:8002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["found-church-api/found-church-api.csproj", "found-church-api/"]
RUN dotnet restore "found-church-api/found-church-api.csproj"
COPY . .
WORKDIR "/src/found-church-api"
RUN dotnet build "found-church-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "found-church-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "found-church-api.dll"]